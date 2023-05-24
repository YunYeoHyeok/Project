using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncyBall
{
    public partial class Stage7 : Form
    {
        public static bool Stage7_clear = false;
        int starcnt = 0;
        private int ballSpeedX = 5;
        private int ballSpeedY = 0;
        private int ballForce = -10; // 새로운 공의 힘
        private int GRAVITY = 1;
        private bool KeyL = false;
        private bool KeyR = false;
        private int start_X;
        private int start_Y;
        bool flag_jump;
        bool flag_doublejump = false;
        bool flag_RightStraight = false;
        bool flag_LeftStraight = false;
        List<PictureBox> picturelist = new List<PictureBox>();
        Rectangle rect_up, rect_down, rect_left, rect_right;
        public Stage7()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            Ball.Location = new Point(start_X, start_Y);
            Ball.Image = Properties.Resources.ball_trans;
            label1.Text = "0 / 3";
            starcnt = 0;
            if (Star1.Visible == false)
            {
                Star1.Visible = true;
            }
            if (Star2.Visible == false)
            {
                Star2.Visible = true;
            }
            if (Star3.Visible == false)
            {
                Star3.Visible = true;
            }
            if (DoubleJump1.Visible == false)
            {
                DoubleJump1.Visible = true;
            }
            if (DoubleJump2.Visible == false)
            {
                DoubleJump2.Visible = true;
            }
            foreach (PictureBox picture in picturelist)
            {
                if (picture.Visible == false)
                {
                    picture.Visible = true;
                }
            }
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

        private void PJOStage_Load(object sender, EventArgs e)
        {
            start_X = Ball.Location.X;
            start_Y = Ball.Location.Y;
            picturelist.Add(OneJump1);
            picturelist.Add(OneJump2);
            picturelist.Add(OneJump3);
            picturelist.Add(OneJump4);
            picturelist.Add(OneJump5);
        }

        private void Stage7_FormClosed(object sender, FormClosedEventArgs e)
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

        private void PJOStage_KeyDown(object sender, KeyEventArgs e)
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
                case Keys.Space:
                    if (flag_doublejump)
                    {
                        ballSpeedY = ballForce;
                        // 더블 점프
                        flag_doublejump = false;
                        Ball.Image = Properties.Resources.ball_trans;
                    }
                    break;
                default:
                    break;
            }
            PlayerLimit();
        }

        private void PJOStage_KeyUp(object sender, KeyEventArgs e)
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (KeyL)
            {
                flag_RightStraight = false;
                flag_LeftStraight = false;
                Ball.Location = new Point(Ball.Location.X - ballSpeedX, Ball.Location.Y);
                foreach (Control control in this.Controls)
                {
                    if (Ball.Bounds.IntersectsWith(control.Bounds) && Ball.Location.X <= control.Location.X + control.Width && control.Name != Ball.Name && control.Name != Star1.Name && control.Name != Star2.Name && control.Name != Star3.Name && control.Name != DoubleJump1.Name && control.Name != DoubleJump2.Name)
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
                flag_RightStraight = false;
                flag_LeftStraight = false;
                Ball.Location = new Point(Ball.Location.X + ballSpeedX, Ball.Location.Y);
                foreach (Control control in this.Controls)
                {
                    if (Ball.Bounds.IntersectsWith(control.Bounds) && Ball.Location.X + Ball.Width >= control.Location.X && control.Name != Ball.Name && control.Name != Star1.Name && control.Name != Star2.Name && control.Name != Star3.Name && control.Name != DoubleJump1.Name && control.Name != DoubleJump2.Name)
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


            if (flag_LeftStraight)
            {
                Ball.Location = new Point(Ball.Location.X - ballSpeedX * 2, Ball.Location.Y);
                foreach (Control control in this.Controls)
                {
                    if (Ball.Bounds.IntersectsWith(control.Bounds) && Ball.Location.X <= control.Location.X + control.Width && control.Name != Ball.Name && control.Name != Star1.Name && control.Name != Star2.Name && control.Name != Star3.Name && control.Name != DoubleJump1.Name && control.Name != DoubleJump2.Name)
                    {
                        Ball.Location = new Point(control.Location.X + control.Width, Ball.Location.Y);
                        flag_LeftStraight = false;
                        break;
                    }
                }

            }
            else if (flag_RightStraight)
            {
                Ball.Location = new Point(Ball.Location.X + ballSpeedX * 2, Ball.Location.Y);
                foreach (Control control in this.Controls)
                {
                    if (Ball.Bounds.IntersectsWith(control.Bounds) && Ball.Location.X + Ball.Width >= control.Location.X && control.Name != Ball.Name && control.Name != Star1.Name && control.Name != Star2.Name && control.Name != Star3.Name && control.Name != DoubleJump1.Name && control.Name != DoubleJump2.Name)
                    {
                        Ball.Location = new Point(control.Location.X - Ball.Width, Ball.Location.Y);
                        flag_RightStraight = false;
                        break;
                    }
                }
            }
            else
            {
                Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + ballSpeedY);
                ballSpeedY += GRAVITY;
            }


            flag_jump = false;
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
                } // 장애물 충돌
                if (control is PictureBox)  // 오브젝트 충돌
                {
                    if (flag_jump == false && Ball.Bounds.IntersectsWith(control.Bounds) && control.Name != Ball.Name && control.Name != Star1.Name && control.Name != Star2.Name && control.Name != Star3.Name && control.Name != DoubleJump1.Name && control.Name != DoubleJump2.Name)
                    {
                        rect_up = new Rectangle(Ball.Location.X, Ball.Location.Y + 1, Ball.Width, 1);
                        rect_down = new Rectangle(Ball.Location.X, Ball.Location.Y + Ball.Height - 1, Ball.Width, 1);
                        if (control.Bounds.IntersectsWith(rect_up) && control.Visible==true)
                        {
                            ballSpeedY = -ballForce;
                            Ball.Top++;
                        }
                        else if (control.Bounds.IntersectsWith(rect_down) && (control.Name != Ball.Name && control.Name == HighJump1.Name || control.Name != Ball.Name && control.Name == HighJump2.Name))
                        {
                            ballSpeedY = -13;
                            flag_jump = true;
                        }
                        else if (control.Name == OneJump1.Name || control.Name == OneJump2.Name || control.Name == OneJump3.Name || control.Name == OneJump4.Name || control.Name == OneJump5.Name)
                        {
                            if (control.Visible == true)
                            {
                                control.Visible = false;
                                ballSpeedY = ballForce;
                                flag_jump = true;
                            }
                        }
                        else
                        {
                            ballSpeedY = ballForce;
                            flag_jump = true;
                        }
                        
                    }
                    // 맨땅 충돌
                    else if (Ball.Bounds.IntersectsWith(control.Bounds) && (control.Name == Star1.Name || control.Name == Star2.Name || control.Name == Star3.Name))
                    {
                        if (starcnt == 3)
                        {
                            Stage7_clear = true;
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
                    // 별 먹었을 때
                    else if (Ball.Bounds.IntersectsWith(control.Bounds) && (control.Name == DoubleJump1.Name || control.Name == DoubleJump2.Name))
                    {
                        if (control.Visible == true)
                        {
                            Ball.Image = Properties.Resources.ball_doublejump_trans;
                            control.Visible = false;
                            flag_doublejump = true;
                        }
                    }
                    
                }
            }
        }
    }
}
