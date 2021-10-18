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
        List<Box> boxes = new List<Box>();

        //starting x positions for boxes
       int yDown = 210;
        int gap = 120;

        //pattern values
        int newBoxCounter = 0;

        //game time left
       public static int gameTime =0;

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
            boxes.Clear();

            gameTime = 0;

            // spawn box paths
            CreateBox(yDown);
            CreateBox(yDown + gap);
            CreateBox(yDown + gap);
            CreateBox(yDown + gap + gap);
            CreateBox(yDown + gap + gap + gap);

            //hero
            hero = new Box(this.Width / 2 - 15, this.Height - 120, 30, 4, new SolidBrush(Color.Goldenrod));
        }

        // hero movment
        public void CreateBox(int y)
        {
            SolidBrush redBrush = new SolidBrush(Color.Red);

            //Box(x, y, size, speed, brush)
            Box b = new Box(0, y, 50, 10, redBrush);
            boxes.Add(b);
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
            if (keyDown == false && leftArrowDown  )
            {
                hero.Move("left");
                keyDown = true;
            }
            else if (keyDown == false && rightArrowDown  )
            {
                hero.Move("right");
                keyDown = true;
            }
            else if (keyDown == false && upArrowDown )
            {
                hero.Move("up");
                keyDown = true;
            }
            else if (keyDown == false && downArrowDown )
            {
                hero.Move("down");
                keyDown = true;
            }

            if(spaceDown==true)
            {
                OnStart();
                
            }


            //update location of all boxes  
            foreach (Box b in boxes)
            {
                b.Move();
            }

            //remove box if it has gone of screen
            if (boxes[0].x > this.Width)
            {
                boxes.RemoveAt(0);
            }

            //randomly spawn boxes
            newBoxCounter = randGen.Next(10, 17);

            //add new box if it is time
            if (newBoxCounter == 10)
            {
                CreateBox(yDown);

                newBoxCounter = 0;
            }

            if (newBoxCounter == 12)
            {
                CreateBox(yDown + gap);

                newBoxCounter = 0;
            }

            if (newBoxCounter == 14)
            {
                CreateBox(yDown + gap + gap);

                newBoxCounter = 0;
            }

            if (newBoxCounter == 16)
            {
                CreateBox(yDown + gap + gap + gap);

                newBoxCounter = 0;
            }
            //display time
           timeOutPutLabel.Text = $"{gameTime/15}";

            //check for collisions between hero and boxes
            foreach (Box b in boxes)
            {
                if (hero.Collision(b))
                {
                    // play crash sound
                    SoundPlayer player = new SoundPlayer(Properties.Resources.crashSound);

                    player.Play();

                    gameTimer.Enabled = false;

                    Thread.Sleep(1000);

                    //change screens
                    Form f = this.FindForm();
                    f.Controls.Remove(this);
                    GameOverScreen over = new GameOverScreen();
                    f.Controls.Add(over);
                    break;       
                }
            }

            //show win screen if hero reaches top of the screen
            if (hero.y <0)
            {
                gameTimer.Enabled = false; ;

                Form f = this.FindForm();
                f.Controls.Remove(this);
                WinScreen win = new WinScreen();
                f.Controls.Add(win);
            }

            //add gameover screen if time hits 20 
            if (gameTime/15 > 20)
            {
                gameTimer.Enabled = false;
                Thread.Sleep(1000);
                Form f = this.FindForm();
                f.Controls.Remove(this);
                GameOverScreen over = new GameOverScreen();
                f.Controls.Add(over);
                
            }
            
            Refresh();
        }


      

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw boxes to screen
            foreach (Box b in boxes)
            {
                e.Graphics.FillRectangle(b.brushColour, b.x, b.y, b.size, b.size);
            }

            e.Graphics.FillRectangle(hero.brushColour, hero.x, hero.y, hero.size, hero.size);
        }
    }
    
}
