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
    public partial class MenuScreen : UserControl
    {
        public MenuScreen()
        {
            InitializeComponent();

            //game starting sound
            SoundPlayer player = new SoundPlayer(Properties.Resources.menuSound);

            player.Play();

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // close program
            Application.Exit();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //change screens if start is pressed
            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameScreen cs = new GameScreen();
            f.Controls.Add(cs);
            cs.Focus();
        }

        private void exitButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
