using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;


namespace froggerProject
{
    public partial class GameScreen : UserControl
    {

        //player1 button control keys
        Boolean leftArrowDown, rightArrowDown, upArrowDown, downArrowDown, spaceDown;
        Boolean keyDown = false;

        //create a list to hold a column of boxes   
        List<Box> boxLeft = new List<Box>();
        List<Box> boxRight = new List<Box>();

        //starting x positions for boxes
        int yDown = 130 ;
        int gap = 140;

        int speed = 10;
        public static int score;



        //pattern values
        int newBoxCounter = 0;

        //game time left
        public static int gameTime = 0;

        //hero values
        Box hero;

        Random randGen = new Random();

        public GameScreen()
        {
            InitializeComponent();
            OnStart();
        }

        /// <summary>
        /// Set initial game values here
        /// </summary>
        public void OnStart()
        {

            // clear boxes on start
            boxLeft.Clear();
            boxRight.Clear();

            gameTime = 0;

            // spawn box paths
            CreateLeftBox(yDown);
            CreateRightBox(yDown + gap);
            CreateLeftBox(yDown + gap + gap);
            CreateRightBox(yDown + gap + gap + gap);

            //hero
            hero = new Box(this.Width / 2 - 15, this.Height - 120, 30, 4);

            
        }

        //box spawn
        public void CreateLeftBox(int y)
        {
            //Box(x, y, size, speed, brush)
            Box left = new Box(0, y, 50, speed);
            boxLeft.Add(left);
        }

        public void CreateRightBox(int y)
        {
            //Box(x, y, size, speed, brush)
            Box right = new Box(this.Width, y, 50, speed);
            boxRight.Add(right);

        }

        

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;

                //restart 
                case Keys.Space:
                    spaceDown = true;
                    break;


            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    keyDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    keyDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    keyDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    keyDown = false;
                    break;
                //resatrt key
                case Keys.Space:
                    spaceDown = false;
                    break;
            }
        }


        private void gameTimer_Tick(object sender, EventArgs e)
        {
            newBoxCounter++;
            gameTime++;

            //move hero
            if (keyDown == false && leftArrowDown)
            {
                hero.Move("left");
                keyDown = true;
            }
            else if (keyDown == false && rightArrowDown)
            {
                hero.Move("right");
                keyDown = true;
            }
            else if (keyDown == false && upArrowDown)
            {
                hero.Move("up");
                keyDown = true;
            }
            else if (keyDown == false && downArrowDown)
            {
                hero.Move("down");
                keyDown = true;
            }

            if (spaceDown == true)
            {
                OnStart();

            }


            //update location of all boxes  
            foreach (Box left in boxLeft)
            {
                left.MoveRight();
            }

            foreach (Box Right in boxRight)
            {
                Right.MoveLeft();
            }


            //remove box if it has gone of screen
            if (boxLeft[0].x > this.Width)
            {
                boxLeft.RemoveAt(0);
            }

            if (boxRight[0].x < 0)
            {
                boxRight.RemoveAt(0);
            }



            //randomly spawn boxes
            newBoxCounter = randGen.Next(8, 17);


            //add new box if it is time
            if (newBoxCounter == 10)
            {
                CreateLeftBox(yDown);

                newBoxCounter = 0;

            }

            if (newBoxCounter == 12)
            {
                CreateRightBox(yDown + gap);

                newBoxCounter = 0;

            }

            if (newBoxCounter == 14)
            {
                CreateLeftBox(yDown + gap + gap);

                newBoxCounter = 0;

            }

            if (newBoxCounter == 16)
            {
                CreateRightBox(yDown + gap + gap + gap);

                newBoxCounter = 0;

            }

            //display time
            timeOutPutLabel.Text = $"{gameTime / 15}";

            //check for collisions between hero and boxes
            foreach (Box b in boxLeft)
            {
                if (hero.Collision(b))
                {
                    // play crash sound
                    SoundPlayer player = new SoundPlayer(Properties.Resources.crashSound);

                    player.Play();

                    gameTimer.Enabled = false;

                    Thread.Sleep(1000);

                    //change screens
                    Form1.ChangeScreen(this, new GameOverScreen());
                    break;
                }
            }

            foreach (Box b in boxRight)
            {
                if (hero.Collision(b))
                {
                    // play crash sound
                    SoundPlayer player = new SoundPlayer(Properties.Resources.crashSound);

                    player.Play();

                    gameTimer.Enabled = false;

                    Thread.Sleep(1000);

                    //change screens
                    Form1.ChangeScreen(this, new GameOverScreen());
                }
            }

            //Speed up cars and reset frog and show score 
            if (hero.y < 0)
            {
                score++;
                speed += 2;

                hero = new Box(this.Width / 2 - 15, this.Height - 120, 30, 4);

                scoreLabel.Text = $"{score}";
            }

            if(score == 10)
            {
                Form1.ChangeScreen(this, new WinScreen());
            }


            Refresh();
        }
        


        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw boxes to screen
            foreach (Box b in boxRight)
            {
                e.Graphics.DrawImage(Properties.Resources.carLeft, b.x, b.y, b.size, b.size);
            }

            foreach (Box b in boxLeft)
            {
                e.Graphics.DrawImage(Properties.Resources.carRight, b.x, b.y, b.size, b.size);
            }

            e.Graphics.DrawImage(Properties.Resources.frog, hero.x, hero.y, hero.size, hero.size);
        }
    }

}

