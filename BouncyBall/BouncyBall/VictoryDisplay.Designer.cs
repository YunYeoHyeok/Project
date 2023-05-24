namespace BouncyBall
{
    partial class VictoryDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VictoryDisplay));
            this.pictureBox_Victory = new System.Windows.Forms.PictureBox();
            this.pictureBox_cong = new System.Windows.Forms.PictureBox();
            this.label_cong = new System.Windows.Forms.Label();
            this.button_Return = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Victory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_cong)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Victory
            // 
            this.pictureBox_Victory.BackgroundImage = global::BouncyBall.Properties.Resources.c_background2;
            this.pictureBox_Victory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_Victory.Location = new System.Drawing.Point(0, -1);
            this.pictureBox_Victory.Name = "pictureBox_Victory";
            this.pictureBox_Victory.Size = new System.Drawing.Size(800, 449);
            this.pictureBox_Victory.TabIndex = 0;
            this.pictureBox_Victory.TabStop = false;
            // 
            // pictureBox_cong
            // 
            this.pictureBox_cong.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_cong.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_cong.Image")));
            this.pictureBox_cong.Location = new System.Drawing.Point(28, 128);
            this.pictureBox_cong.Name = "pictureBox_cong";
            this.pictureBox_cong.Size = new System.Drawing.Size(744, 297);
            this.pictureBox_cong.TabIndex = 1;
            this.pictureBox_cong.TabStop = false;
            // 
            // label_cong
            // 
            this.label_cong.AutoSize = true;
            this.label_cong.BackColor = System.Drawing.Color.Transparent;
            this.label_cong.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label_cong.Location = new System.Drawing.Point(143, 55);
            this.label_cong.Name = "label_cong";
            this.label_cong.Size = new System.Drawing.Size(517, 73);
            this.label_cong.TabIndex = 2;
            this.label_cong.Text = "Congratulations!";
            // 
            // button_Return
            // 
            this.button_Return.BackColor = System.Drawing.Color.Transparent;
            this.button_Return.Font = new System.Drawing.Font("맑은 고딕", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button_Return.Image = global::BouncyBall.Properties.Resources.yellow;
            this.button_Return.Location = new System.Drawing.Point(328, 331);
            this.button_Return.Name = "button_Return";
            this.button_Return.Size = new System.Drawing.Size(136, 71);
            this.button_Return.TabIndex = 3;
            this.button_Return.Text = "Return";
            this.button_Return.UseVisualStyleBackColor = false;
            this.button_Return.Click += new System.EventHandler(this.button_Return_Click);
            // 
            // VictoryDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_Return);
            this.Controls.Add(this.label_cong);
            this.Controls.Add(this.pictureBox_cong);
            this.Controls.Add(this.pictureBox_Victory);
            this.Name = "VictoryDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Victory";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VictoryDisplay_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Victory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_cong)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Victory;
        private System.Windows.Forms.PictureBox pictureBox_cong;
        private System.Windows.Forms.Label label_cong;
        private System.Windows.Forms.Button button_Return;
    }
}