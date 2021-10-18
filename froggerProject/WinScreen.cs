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
    public partial class WinScreen : UserControl
    {
        public WinScreen()
        {
            InitializeComponent();

            //play win sound
            SoundPlayer player = new SoundPlayer(Properties.Resources.winSound);

            player.Play();

            // display game time 
            gameScoreLabel.Text = $"you won at {GameScreen.gameTime / 15} seconds";


        }
        private void menuButton_Click(object sender, EventArgs e)
        {
            //change scrren to menu
            Form f = this.FindForm();
            f.Controls.Remove(this);
            MenuScreen ms = new MenuScreen();
            f.Controls.Add(ms);
        }
    }
}
