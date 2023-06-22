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
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            //change screen to menue screen 
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void menuButtton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new MenuScreen());
        }

        private void playagainButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void scoreboardButton_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
;