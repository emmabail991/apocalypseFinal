
namespace froggerProject
{
    partial class GameScreen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.scoreLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.healthOutputLabel = new System.Windows.Forms.Label();
            this.scoreOutputLabel = new System.Windows.Forms.Label();
            this.ammoLeftoutput = new System.Windows.Forms.Label();
            this.magSizeoutput = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 50;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.Red;
            this.scoreLabel.Location = new System.Drawing.Point(821, 52);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(0, 29);
            this.scoreLabel.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::froggerProject.Properties.Resources.ICON;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // healthOutputLabel
            // 
            this.healthOutputLabel.AutoSize = true;
            this.healthOutputLabel.BackColor = System.Drawing.Color.Transparent;
            this.healthOutputLabel.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.healthOutputLabel.ForeColor = System.Drawing.Color.Maroon;
            this.healthOutputLabel.Location = new System.Drawing.Point(54, 10);
            this.healthOutputLabel.Name = "healthOutputLabel";
            this.healthOutputLabel.Size = new System.Drawing.Size(48, 34);
            this.healthOutputLabel.TabIndex = 6;
            this.healthOutputLabel.Text = "♥5";
            // 
            // scoreOutputLabel
            // 
            this.scoreOutputLabel.AutoSize = true;
            this.scoreOutputLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreOutputLabel.Font = new System.Drawing.Font("Segoe Print", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreOutputLabel.ForeColor = System.Drawing.Color.Maroon;
            this.scoreOutputLabel.Location = new System.Drawing.Point(3, 52);
            this.scoreOutputLabel.Name = "scoreOutputLabel";
            this.scoreOutputLabel.Size = new System.Drawing.Size(106, 51);
            this.scoreOutputLabel.TabIndex = 7;
            this.scoreOutputLabel.Text = "1000";
            // 
            // ammoLeftoutput
            // 
            this.ammoLeftoutput.AutoSize = true;
            this.ammoLeftoutput.BackColor = System.Drawing.Color.Transparent;
            this.ammoLeftoutput.ForeColor = System.Drawing.Color.Yellow;
            this.ammoLeftoutput.Location = new System.Drawing.Point(44, 397);
            this.ammoLeftoutput.Name = "ammoLeftoutput";
            this.ammoLeftoutput.Size = new System.Drawing.Size(35, 13);
            this.ammoLeftoutput.TabIndex = 8;
            this.ammoLeftoutput.Text = "label1";
            // 
            // magSizeoutput
            // 
            this.magSizeoutput.AutoSize = true;
            this.magSizeoutput.BackColor = System.Drawing.Color.Transparent;
            this.magSizeoutput.ForeColor = System.Drawing.Color.Yellow;
            this.magSizeoutput.Location = new System.Drawing.Point(3, 397);
            this.magSizeoutput.Name = "magSizeoutput";
            this.magSizeoutput.Size = new System.Drawing.Size(35, 13);
            this.magSizeoutput.TabIndex = 9;
            this.magSizeoutput.Text = "label2";
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::froggerProject.Properties.Resources.GameScreenBackround;
            this.Controls.Add(this.magSizeoutput);
            this.Controls.Add(this.ammoLeftoutput);
            this.Controls.Add(this.scoreOutputLabel);
            this.Controls.Add(this.healthOutputLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.scoreLabel);
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(1248, 415);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.GameScreen_PreviewKeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label healthOutputLabel;
        private System.Windows.Forms.Label scoreOutputLabel;
        private System.Windows.Forms.Label ammoLeftoutput;
        private System.Windows.Forms.Label magSizeoutput;
    }
}
