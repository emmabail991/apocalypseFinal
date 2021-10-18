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

            if (GameScreen.gameTime/15 >= 20)
            {
                //display out of time message if out of time 
                titelLabel.Text = "OUT OF TIME";
                gameScoreLabel.Text="Time limmet is 20 seconds";
            }
            else
            {
                //displya mess if crashed into box
                titelLabel.Text = "GAME OVER";
                gameScoreLabel.Text = "You Died";
 
            }
        }

        

        private void menuButton_Click(object sender, EventArgs e)
        {
            //change screen to menue screen 
            Form f = this.FindForm();
            f.Controls.Remove(this);
            MenuScreen ms = new MenuScreen();
            f.Controls.Add(ms);
        }
    }
}
;