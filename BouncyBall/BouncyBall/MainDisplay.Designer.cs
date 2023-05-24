namespace BouncyBall
{
    partial class MainDisplay
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Title = new System.Windows.Forms.Label();
            this.picture_block = new System.Windows.Forms.PictureBox();
            this.button_start = new System.Windows.Forms.Button();
            this.picture_ball = new System.Windows.Forms.PictureBox();
            this.pictureBox_mainbg = new System.Windows.Forms.PictureBox();
            this.pictureBox_ball3 = new System.Windows.Forms.PictureBox();
            this.pictureBox_ball2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picture_block)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mainbg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ball3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ball2)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Title.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Title.Location = new System.Drawing.Point(113, 60);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(492, 73);
            this.Title.TabIndex = 0;
            this.Title.Text = "BOUNCE BALL";
            // 
            // picture_block
            // 
            this.picture_block.BackgroundImage = global::BouncyBall.Properties.Resources.plate2;
            this.picture_block.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picture_block.Location = new System.Drawing.Point(313, 240);
            this.picture_block.Name = "picture_block";
            this.picture_block.Size = new System.Drawing.Size(57, 53);
            this.picture_block.TabIndex = 1;
            this.picture_block.TabStop = false;
            // 
            // button_start
            // 
            this.button_start.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button_start.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_start.Location = new System.Drawing.Point(290, 324);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(112, 55);
            this.button_start.TabIndex = 2;
            this.button_start.Text = "Play!";
            this.button_start.UseVisualStyleBackColor = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click_1);
            // 
            // picture_ball
            // 
            this.picture_ball.BackColor = System.Drawing.Color.Transparent;
            this.picture_ball.BackgroundImage = global::BouncyBall.Properties.Resources.yellowball;
            this.picture_ball.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picture_ball.Location = new System.Drawing.Point(363, 152);
            this.picture_ball.Name = "picture_ball";
            this.picture_ball.Size = new System.Drawing.Size(89, 82);
            this.picture_ball.TabIndex = 5;
            this.picture_ball.TabStop = false;
            // 
            // pictureBox_mainbg
            // 
            this.pictureBox_mainbg.Image = global::BouncyBall.Properties.Resources.c_background;
            this.pictureBox_mainbg.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox_mainbg.Name = "pictureBox_mainbg";
            this.pictureBox_mainbg.Size = new System.Drawing.Size(803, 451);
            this.pictureBox_mainbg.TabIndex = 7;
            this.pictureBox_mainbg.TabStop = false;
            // 
            // pictureBox_ball3
            // 
            this.pictureBox_ball3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_ball3.BackgroundImage = global::BouncyBall.Properties.Resources.yellowball2;
            this.pictureBox_ball3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_ball3.Location = new System.Drawing.Point(204, 152);
            this.pictureBox_ball3.Name = "pictureBox_ball3";
            this.pictureBox_ball3.Size = new System.Drawing.Size(67, 68);
            this.pictureBox_ball3.TabIndex = 9;
            this.pictureBox_ball3.TabStop = false;
            // 
            // pictureBox_ball2
            // 
            this.pictureBox_ball2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_ball2.BackgroundImage = global::BouncyBall.Properties.Resources.yellowball1;
            this.pictureBox_ball2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_ball2.Location = new System.Drawing.Point(290, 136);
            this.pictureBox_ball2.Name = "pictureBox_ball2";
            this.pictureBox_ball2.Size = new System.Drawing.Size(80, 73);
            this.pictureBox_ball2.TabIndex = 8;
            this.pictureBox_ball2.TabStop = false;
            // 
            // MainDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(714, 461);
            this.Controls.Add(this.pictureBox_ball3);
            this.Controls.Add(this.pictureBox_ball2);
            this.Controls.Add(this.picture_ball);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.picture_block);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.pictureBox_mainbg);
            this.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.Name = "MainDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BouncyBall";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainDisplay_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.picture_block)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_mainbg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ball3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_ball2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.PictureBox picture_block;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.PictureBox picture_ball;
        private System.Windows.Forms.PictureBox pictureBox_mainbg;
        private System.Windows.Forms.PictureBox pictureBox_ball3;
        private System.Windows.Forms.PictureBox pictureBox_ball2;
    }
}
