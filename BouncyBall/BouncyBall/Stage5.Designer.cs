namespace BouncyBall
{
    partial class Stage5
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Ball = new System.Windows.Forms.PictureBox();
            this.Star1 = new System.Windows.Forms.PictureBox();
            this.Star2 = new System.Windows.Forms.PictureBox();
            this.Star3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OneJump1 = new System.Windows.Forms.PictureBox();
            this.DoubleJump1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.OneJump2 = new System.Windows.Forms.PictureBox();
            this.OneJump4 = new System.Windows.Forms.PictureBox();
            this.OneJump3 = new System.Windows.Forms.PictureBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.OneJump5 = new System.Windows.Forms.PictureBox();
            this.Teleport1 = new System.Windows.Forms.PictureBox();
            this.DoubleJump2 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OneJump1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoubleJump1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OneJump2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OneJump4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OneJump3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OneJump5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Teleport1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoubleJump2)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BouncyBall.Properties.Resources.plate2;
            this.pictureBox1.Location = new System.Drawing.Point(67, 385);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Ball
            // 
            this.Ball.BackColor = System.Drawing.Color.Transparent;
            this.Ball.Image = global::BouncyBall.Properties.Resources.ball;
            this.Ball.Location = new System.Drawing.Point(16, 44);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(20, 20);
            this.Ball.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Ball.TabIndex = 7;
            this.Ball.TabStop = false;
            // 
            // Star1
            // 
            this.Star1.Image = global::BouncyBall.Properties.Resources.star1;
            this.Star1.Location = new System.Drawing.Point(73, 213);
            this.Star1.Name = "Star1";
            this.Star1.Size = new System.Drawing.Size(28, 33);
            this.Star1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Star1.TabIndex = 8;
            this.Star1.TabStop = false;
            // 
            // Star2
            // 
            this.Star2.Image = global::BouncyBall.Properties.Resources.star1;
            this.Star2.Location = new System.Drawing.Point(431, 234);
            this.Star2.Name = "Star2";
            this.Star2.Size = new System.Drawing.Size(28, 33);
            this.Star2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Star2.TabIndex = 9;
            this.Star2.TabStop = false;
            // 
            // Star3
            // 
            this.Star3.Image = global::BouncyBall.Properties.Resources.star1;
            this.Star3.Location = new System.Drawing.Point(649, 154);
            this.Star3.Name = "Star3";
            this.Star3.Size = new System.Drawing.Size(28, 33);
            this.Star3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Star3.TabIndex = 10;
            this.Star3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(624, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 45);
            this.label1.TabIndex = 11;
            this.label1.Text = "0 / 3";
            // 
            // OneJump1
            // 
            this.OneJump1.BackgroundImage = global::BouncyBall.Properties.Resources.Disappear;
            this.OneJump1.Location = new System.Drawing.Point(16, 258);
            this.OneJump1.Name = "OneJump1";
            this.OneJump1.Size = new System.Drawing.Size(34, 34);
            this.OneJump1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OneJump1.TabIndex = 13;
            this.OneJump1.TabStop = false;
            // 
            // DoubleJump1
            // 
            this.DoubleJump1.BackgroundImage = global::BouncyBall.Properties.Resources.Double;
            this.DoubleJump1.Location = new System.Drawing.Point(145, 332);
            this.DoubleJump1.Name = "DoubleJump1";
            this.DoubleJump1.Size = new System.Drawing.Size(33, 33);
            this.DoubleJump1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DoubleJump1.TabIndex = 15;
            this.DoubleJump1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::BouncyBall.Properties.Resources.thorn;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(129, 387);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(49, 34);
            this.panel2.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::BouncyBall.Properties.Resources.thorn;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(201, 387);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(38, 34);
            this.panel3.TabIndex = 17;
            // 
            // OneJump2
            // 
            this.OneJump2.BackgroundImage = global::BouncyBall.Properties.Resources.Disappear;
            this.OneJump2.Location = new System.Drawing.Point(16, 154);
            this.OneJump2.Name = "OneJump2";
            this.OneJump2.Size = new System.Drawing.Size(34, 34);
            this.OneJump2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OneJump2.TabIndex = 18;
            this.OneJump2.TabStop = false;
            // 
            // OneJump4
            // 
            this.OneJump4.BackgroundImage = global::BouncyBall.Properties.Resources.Disappear;
            this.OneJump4.Location = new System.Drawing.Point(425, 154);
            this.OneJump4.Name = "OneJump4";
            this.OneJump4.Size = new System.Drawing.Size(34, 34);
            this.OneJump4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OneJump4.TabIndex = 19;
            this.OneJump4.TabStop = false;
            // 
            // OneJump3
            // 
            this.OneJump3.BackgroundImage = global::BouncyBall.Properties.Resources.Disappear;
            this.OneJump3.Location = new System.Drawing.Point(352, 154);
            this.OneJump3.Name = "OneJump3";
            this.OneJump3.Size = new System.Drawing.Size(34, 34);
            this.OneJump3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OneJump3.TabIndex = 20;
            this.OneJump3.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.BackgroundImage = global::BouncyBall.Properties.Resources.thorn;
            this.panel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel5.Location = new System.Drawing.Point(129, 214);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(34, 32);
            this.panel5.TabIndex = 21;
            // 
            // OneJump5
            // 
            this.OneJump5.BackgroundImage = global::BouncyBall.Properties.Resources.Disappear;
            this.OneJump5.Location = new System.Drawing.Point(271, 154);
            this.OneJump5.Name = "OneJump5";
            this.OneJump5.Size = new System.Drawing.Size(34, 34);
            this.OneJump5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OneJump5.TabIndex = 22;
            this.OneJump5.TabStop = false;
            // 
            // Teleport1
            // 
            this.Teleport1.BackColor = System.Drawing.SystemColors.Control;
            this.Teleport1.Image = global::BouncyBall.Properties.Resources.reverse2;
            this.Teleport1.Location = new System.Drawing.Point(271, 388);
            this.Teleport1.Name = "Teleport1";
            this.Teleport1.Size = new System.Drawing.Size(32, 33);
            this.Teleport1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Teleport1.TabIndex = 23;
            this.Teleport1.TabStop = false;
            // 
            // DoubleJump2
            // 
            this.DoubleJump2.BackgroundImage = global::BouncyBall.Properties.Resources.Double;
            this.DoubleJump2.Location = new System.Drawing.Point(352, 234);
            this.DoubleJump2.Name = "DoubleJump2";
            this.DoubleJump2.Size = new System.Drawing.Size(33, 33);
            this.DoubleJump2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DoubleJump2.TabIndex = 28;
            this.DoubleJump2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::BouncyBall.Properties.Resources.thorn;
            this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel4.Location = new System.Drawing.Point(164, 387);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(42, 34);
            this.panel4.TabIndex = 17;
            // 
            // Stage5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BouncyBall.Properties.Resources.BackGround;
            this.ClientSize = new System.Drawing.Size(714, 461);
            this.Controls.Add(this.DoubleJump2);
            this.Controls.Add(this.Teleport1);
            this.Controls.Add(this.OneJump5);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.OneJump3);
            this.Controls.Add(this.OneJump4);
            this.Controls.Add(this.OneJump2);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DoubleJump1);
            this.Controls.Add(this.OneJump1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Star3);
            this.Controls.Add(this.Star2);
            this.Controls.Add(this.Star1);
            this.Controls.Add(this.Ball);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Stage5";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stage5";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Stage5_FormClosed);
            this.Load += new System.EventHandler(this.Stage4_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Stage4_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Stage4_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Star3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OneJump1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoubleJump1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OneJump2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OneJump4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OneJump3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OneJump5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Teleport1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoubleJump2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox Ball;
        private System.Windows.Forms.PictureBox Star1;
        private System.Windows.Forms.PictureBox Star2;
        private System.Windows.Forms.PictureBox Star3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox OneJump1;
        private System.Windows.Forms.PictureBox DoubleJump1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox OneJump2;
        private System.Windows.Forms.PictureBox OneJump4;
        private System.Windows.Forms.PictureBox OneJump3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.PictureBox OneJump5;
        private System.Windows.Forms.PictureBox Teleport1;
        private System.Windows.Forms.PictureBox DoubleJump2;
        private System.Windows.Forms.Panel panel4;
    }
}