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

        //play image direction
        Boolean LookRight = true;
        Boolean lookLeft = false;

        //create a list to hold a column of boxes   
        List<zombie> boxLeft = new List<zombie>();
        List<zombie> boxRight = new List<zombie>();
        List<bullet> bulletList = new List<bullet>();
         
        //gmae brushes
        SolidBrush redBrush = new SolidBrush(Color.Red);

        //starting x positions for boxes
        int ground = 350;
         
        //player values
        int waveSpawn = 30;
        int life = 5;
        int shotCounter;
        int shotLimit = 30;
        int speed = 4;
        
        public static int score;

        //bullet values
        static int bulletWidth, bulletHeight, bulletSpeed;


        //pattern values
        int newBoxCounter = 0;

        //game time left
        public static int gameTime = 0;

        //hero 
        zombie hero;

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

             

            //hero
            hero = new zombie(this.Width / 2 - 15, this.Height - 90, 70, 4);

            bulletWidth = 10;
            bulletHeight = 5;
            bulletSpeed = 50;
        }

        //box spawn
        public void CreateLeftBox(int y)
        {
            //Box(x, y, size, speed, brush)
            zombie left = new zombie(0, y, 50, speed);
            boxLeft.Add(left);
        }

        public void CreateRightBox(int y)
        {
            //Box(x, y, size, speed, brush)
            zombie right = new zombie(this.Width, y, 50, speed);
            boxRight.Add(right);

        }

        public void MakeBullet()
        {
            //play hun sound
            SoundPlayer player = new SoundPlayer(Properties.Resources.shot);
            player.Play();

            //spawn bullets
            bullet bullet = new bullet(hero.x + 22, hero.y + 20, bulletWidth, bulletHeight,bulletSpeed);
            bulletList.Add(bullet);
            shotCounter++;
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    lookLeft = true;
                    LookRight = false;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    lookLeft = false;
                    LookRight = true;
                    break;
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
                     
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                     
                    break;
                case Keys.Space:
                    spaceDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //ammo left and mag size
            ammoLeftoutput.Text = $"{shotCounter}";
            newBoxCounter++;
            gameTime++;

            //move hero
            if (keyDown == false && leftArrowDown)
            {
                hero.Move("left");
                 
            }
            else if (keyDown == false && rightArrowDown)
            {
                hero.Move("right");
                 
            }
            //bullet shoot
            if (spaceDown == true && shotCounter < shotLimit)
            {
                shotCounter = 0;
                MakeBullet();
                 
                
            }
            //bullet shoot direction
            foreach (bullet bullet in bulletList)
            {
                if(lookLeft == true)
                {
                    bullet.MoveBulletLeft(bulletSpeed);
                }
                if (LookRight == true)
                {
                    bullet.MoveBulletRight(bulletSpeed);
                }
            }

            //update location of all boxes  
            foreach (zombie left in boxLeft)
            {
                left.MoveRight();
            }

            foreach (zombie Right in boxRight)
            {
                Right.MoveLeft();
            }

            //randomly spawn boxes
            newBoxCounter = randGen.Next(0, waveSpawn);


            //add new box if it is time
            if (newBoxCounter == 1)
            {
                CreateLeftBox(ground);

                newBoxCounter = 0;

            }

            if (newBoxCounter == 2)
            {
                CreateRightBox(ground);

                newBoxCounter = 0;

            }

            

            //check for collisions between hero and boxes and play sounds if player is hit
            foreach (zombie b in boxLeft)
            {
                if (hero.Collision(b))
                {
                    SoundPlayer player = new SoundPlayer(Properties.Resources.hurt);

                    player.Play();
                    life--;
                    healthOutputLabel.Text = $"♥{life}";
                    Thread.Sleep(1000);

                }
                if (life == 0)
                {
                    Form1.ChangeScreen(this, new GameOverScreen());
                }
            }

            foreach (zombie b in boxRight)
            {
                if (hero.Collision(b))
                {
                    SoundPlayer player = new SoundPlayer(Properties.Resources.hurt);

                    player.Play();
                    life--;
                    healthOutputLabel.Text = $"♥{life}";
                    Thread.Sleep(1000);

                }
                // go to death screen if player is hit 
                if (life == 0)
                {
                    SoundPlayer player = new SoundPlayer(Properties.Resources.gameOverSound);

                    player.Play();
                    gameTimer.Enabled = false;
                    Form1.ChangeScreen(this, new GameOverScreen());
                }
            }

            Refresh();
        }


        //paint bullets and players
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw boxes to screen
            foreach (zombie b in boxRight)
            {
                e.Graphics.DrawImage(Properties.Resources.kingZombie, b.x, b.y, b.size, b.size);

            }

            foreach (zombie b in boxLeft)
            {
                e.Graphics.DrawImage(Properties.Resources.kingZombie, b.x, b.y, b.size, b.size);
            }

            if (lookLeft == true)
            {
                e.Graphics.DrawImage(Properties.Resources.Shot_2, hero.x, hero.y, hero.size, hero.size);
            }
            else if(LookRight == true) 
            {
                e.Graphics.DrawImage(Properties.Resources.Shot_1, hero.x, hero.y, hero.size, hero.size);
            }
            

            foreach (bullet b in bulletList)
            {
                e.Graphics.FillRectangle(redBrush, b.x, b.y, b.width, b.height);
            }
        }
    }

}

