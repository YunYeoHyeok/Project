using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace BouncyBall
{
    public partial class MainDisplay : Form
    {
        public MainDisplay()
        {
            InitializeComponent();
            picture_ball.Parent = pictureBox_mainbg;
            Title.Parent = pictureBox_mainbg;
            this.picture_ball.Controls.Add(this.pictureBox_ball2);
            this.pictureBox_ball2.Location = new Point(-10, 10);
            this.pictureBox_ball2.BackColor = Color.Transparent;
            this.pictureBox_ball2.Controls.Add(this.pictureBox_ball3);
            this.pictureBox_ball3.Location = new Point(-5, 10);
            this.pictureBox_ball3.BackColor = Color.Transparent;
        }

        private void button_start_Click(object sender, EventArgs e)
        {

        }

        private void button_start_Click_1(object sender, EventArgs e)
        {
            this.Visible= false;
            SelectDisplay selectDisplay = new SelectDisplay();
            selectDisplay.Show();
        }

        private void MainDisplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            List<Form> formsToClose = new List<Form>();

            foreach (Form form in Application.OpenForms)
            {
                if (form != this)  // 만약 자기 자신 Form도 닫을 경우 if문 생략
                {
                    formsToClose.Add(form);
                }
            }

            formsToClose.ForEach(f => f.Close());
        }
    }
}
