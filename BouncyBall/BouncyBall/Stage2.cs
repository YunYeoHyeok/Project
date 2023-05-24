using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncyBall
{
    public partial class Stage2 : Form
    {
        public static bool stage2_clear = false;
        int starcnt = 0;
        private int ballSpeedX = 5;
        private int ballSpeedY = 0;
        private int ballForce = -10; // 새로운 공의 힘
        private int GRAVITY = 1;
        private bool KeyL = false;
        private bool KeyR = false;
        private int start_X;
        private int start_Y;
        Rectangle rect_up, rect_down, rect_left, rect_right;

        public Stage2()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            Ball.Location = new Point(start_X, start_Y);
            panel1.Text = "0 / 3";
            starcnt = 0;
            if (Star1.Visible == false) { Star1.Visible = true; }
            if (Star2.Visible == false) { Star2.Visible = true; }
            if (Star3.Visible == false) { Star3.Visible = true; }
            if (hid1.Visible == false) { hid1.Visible = true; }
            if (hid2.Visible == false) { hid2.Visible = true; }
            if (hid3.Visible == false) { hid3.Visible = true; }
            if (hid4.Visible == false) { hid4.Visible = true; }
            if (hid5.Visible == false) { hid5.Visible = true; }
            if (hid6.Visible == false) { hid6.Visible = true; }
            if (hid7.Visible == false) { hid7.Visible = true; }
            if (hid8.Visible == false) { hid8.Visible = true; }
            if (hid9.Visible == false) { hid9.Visible = true; }
            if (hid10.Visible == false) { hid10.Visible = true; }
        }

        private void Stage2_Load(object sender, EventArgs e)
        {
            start_X = Ball.Location.X;
            start_Y = Ball.Location.Y;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void Stage2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    KeyL = true;
                    break;
                case Keys.Right:
                    KeyR = true;
                    break;
                case Keys.Escape:
                    SelectDisplay SD = new SelectDisplay();
                    this.Hide();
                    SD.Show();
                    break;
                default:
                    break;
            }
            PlayerLimit();
        }

        private void PlayerLimit()
        {
            if (Ball.Location.X >= 690)
            {
                ballSpeedY = GRAVITY;
                Ball.Location = new Point(690, Ball.Location.Y);
            }
            else if (Ball.Location.X < 0)
            {
                ballSpeedY = GRAVITY;
                Ball.Location = new Point(0, Ball.Location.Y);
            }
            if (Ball.Location.Y + Ball.Size.Height >= this.ClientSize.Height)
            {
                ballSpeedY = GRAVITY;
                Ball.Location = new Point(start_X, start_Y);
                Reset();
            }
        }

        private void Stage2_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    KeyL = false;
                    break;
                case Keys.Right:
                    KeyR = false;
                    break;
                default:
                    break;
            }
        }

        private void Stage2_FormClosed(object sender, FormClosedEventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (KeyL)
            {
                Ball.Location = new Point(Ball.Location.X - ballSpeedX, Ball.Location.Y);
                foreach (Control control in this.Controls)
                {
                    if (Ball.Bounds.IntersectsWith(control.Bounds) && Ball.Location.X <= control.Location.X + control.Width && control.Name != Ball.Name && control.Name != Star1.Name && control.Name != Star2.Name && control.Name != Star3.Name)
                    {
                        if (control.Visible == false)
                        {
                            break;
                        }
                        Ball.Location = new Point(Ball.Location.X + ballSpeedX, Ball.Location.Y);
                        break;
                    }
                }
            }
            if (KeyR)
            {
                Ball.Location = new Point(Ball.Location.X + ballSpeedX, Ball.Location.Y);
                foreach (Control control in this.Controls)
                {
                    if (Ball.Bounds.IntersectsWith(control.Bounds) && Ball.Location.X + Ball.Width >= control.Location.X && control.Name != Ball.Name && control.Name != Star1.Name && control.Name != Star2.Name && control.Name != Star3.Name)
                    {
                        if (control.Visible == false)
                        {
                            break;
                        }
                        Ball.Location = new Point(Ball.Location.X - ballSpeedX, Ball.Location.Y);
                        break;
                    }
                }
            }



            Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + ballSpeedY);
            ballSpeedY += GRAVITY;

            // 공이 바닥에 닿으면 튕김
            PlayerLimit();

            foreach (Control control in this.Controls)
            {
                if (control is Panel)
                {
                    if (Ball.Bounds.IntersectsWith(control.Bounds))
                    {
                        // 시작 위치로 되돌리기
                        ballSpeedY = GRAVITY;
                        Reset();
                    }
                }
                if (control is PictureBox)
                {
                    if ( Ball.Bounds.IntersectsWith(control.Bounds) && control.Name != Ball.Name && control.Name != Star1.Name && control.Name != Star2.Name && control.Name != Star3.Name)
                    {
                        rect_up = new Rectangle(Ball.Location.X, Ball.Location.Y + 1, Ball.Width, 1);
                        if (control.Bounds.IntersectsWith(rect_up) && control.Visible)
                        {
                            ballSpeedY = -ballForce;
                        }
                        else if (control.Name == hid1.Name || control.Name == hid2.Name || control.Name == hid3.Name || control.Name == hid4.Name || control.Name == hid5.Name || control.Name == hid6.Name
                            || control.Name == hid7.Name || control.Name == hid8.Name || control.Name == hid9.Name || control.Name == hid10.Name)
                        {
                            if (control.Visible == true)
                            {
                                control.Visible = false;
                                ballSpeedY = ballForce;
                            }
                        }
                        else
                        {
                            ballSpeedY = ballForce;
                        }

                    }



                    else if (Ball.Bounds.IntersectsWith(control.Bounds) && (control.Name == Star1.Name || control.Name == Star2.Name || control.Name == Star3.Name))
                    {
                        if (starcnt == 3)
                        {
                            stage2_clear = true;
                            timer1.Enabled = false;
                            this.Visible = false;
                            SelectDisplay selectDisplay = new SelectDisplay();
                            selectDisplay.Show();
                            // 여기서 폼 이동
                        }
                        else
                        {
                            if (control.Visible == true)
                            {
                                starcnt++;
                                control.Visible = false;
                                label1.Text = starcnt + " / 3";
                            }
                        }
                    }

                    //위로 2배이동
                    if (Ball.Bounds.IntersectsWith(control.Bounds) && (control.Name != Ball.Name && control.Name == pictureBox27.Name || control.Name != Ball.Name && control.Name == pictureBox14.Name || control.Name != Ball.Name && control.Name == pictureBox15.Name))
                    {
                        ballSpeedY = -13;
                    }






                }
            }
        }


    }
}