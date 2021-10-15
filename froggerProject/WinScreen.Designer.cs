
namespace froggerProject
{
    partial class WinScreen
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
            this.winLabel = new System.Windows.Forms.Label();
            this.gameScoreLabel = new System.Windows.Forms.Label();
            this.menuButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // winLabel
            // 
            this.winLabel.BackColor = System.Drawing.Color.Transparent;
            this.winLabel.Font = new System.Drawing.Font("Mongolian Baiti", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.winLabel.ForeColor = System.Drawing.Color.Green;
            this.winLabel.Location = new System.Drawing.Point(114, 315);
            this.winLabel.Name = "winLabel";
            this.winLabel.Size = new System.Drawing.Size(714, 87);
            this.winLabel.TabIndex = 5;
            this.winLabel.Text = "YOU WIN";
            this.winLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameScoreLabel
            // 
            this.gameScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.gameScoreLabel.Font = new System.Drawing.Font("Mongolian Baiti", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameScoreLabel.ForeColor = System.Drawing.Color.Green;
            this.gameScoreLabel.Location = new System.Drawing.Point(114, 402);
            this.gameScoreLabel.Name = "gameScoreLabel";
            this.gameScoreLabel.Size = new System.Drawing.Size(714, 87);
            this.gameScoreLabel.TabIndex = 6;
            this.gameScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuButton
            // 
            this.menuButton.BackColor = System.Drawing.Color.YellowGreen;
            this.menuButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButton.Location = new System.Drawing.Point(114, 572);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(714, 50);
            this.menuButton.TabIndex = 7;
            this.menuButton.Text = "Go to Menu";
            this.menuButton.UseVisualStyleBackColor = false;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // WinScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::froggerProject.Properties.Resources.flipedRoad;
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.gameScoreLabel);
            this.Controls.Add(this.winLabel);
            this.Name = "WinScreen";
            this.Size = new System.Drawing.Size(923, 777);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label winLabel;
        private System.Windows.Forms.Label gameScoreLabel;
        private System.Windows.Forms.Button menuButton;
    }
}
