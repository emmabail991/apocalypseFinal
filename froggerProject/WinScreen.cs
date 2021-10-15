using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace froggerProject
{
    public partial class WinScreen : UserControl
    {
        public WinScreen()
        {
            InitializeComponent();
            gameScoreLabel.Text = $"you won at {GameScreen.gameTime}";
        }

        
        private void menuButton_Click(object sender, EventArgs e)
        {
            Form f = this.FindForm();
            f.Controls.Remove(this);
            MenuScreen ms = new MenuScreen();
            f.Controls.Add(ms);
        }
    }
}
