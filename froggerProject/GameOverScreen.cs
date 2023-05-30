using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Security.Cryptography.X509Certificates;

namespace froggerProject
{
    public partial class GameOverScreen : UserControl
    {
        public GameOverScreen()
        {
            InitializeComponent();

            //play loose sound
            SoundPlayer player = new SoundPlayer(Properties.Resources.gameOverSound);

            player.Play();

             
             
                //displya mess if crashed into box
                titelLabel.Text = "GAME OVER";
                gameScoreLabel.Text = $"your score was {gameScoreLabel}";
 
            
        }

        

        

        private void menuButton_Click(object sender, EventArgs e)
        {
            //change screen to menue screen 
            Form1.ChangeScreen(this, new MenuScreen());
        }
    }
}
;