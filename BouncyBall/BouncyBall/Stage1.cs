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

    public partial class Stage1 : Form
    {
        public static bool stage1_clear = false; // 승리 여부 
        private int ballSpeedX = 5; // x축 속도
        private int ballSpeedY = 0; // y축 속도
        private int ballForce = -10; // 새로운 공의 힘
        private int GRAVITY = 1; // 공의 가속도
        private bool KeyL = false; // 방향키 왼쪽 입력 - 누르고 있을 때 동작하게 하기 위함
        private bool KeyR = false; // 방향키 오른쪽 입력 - 누르고 있을 때 동작하게 하기 위함
        private int start_X; // 게임시작시 공의 x축 위치
        private int start_Y; // 게임시작시 공의 y축 위치
        private int starcnt = 0; // 별 카운터
        private Rectangle rect_up, rect_down, rect_left, rect_right; // 공의 상하좌우 영역


        public Stage1()
        {
            InitializeComponent();
        }

        private void Reset()
        {
            Ball.Location = new Point(start_X, start_Y);
            timer1.Enabled = true;
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
        }

        private void Stage1_Load(object sender, EventArgs e)
        {
            start_X = Ball.Location.X;
            start_Y = Ball.Location.Y;
            
        }


        private void Stage1_KeyDown(object sender, KeyEventArgs e)
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
                Ball.Location = new Point(690 , Ball.Location.Y);
            }
            else if( Ball.Location.X < 0)
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

        private void Stage1_FormClosed(object sender, FormClosedEventArgs e)
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

        private void Stage1_KeyUp(object sender, KeyEventArgs e)
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
                Ball.Location = new Point(Ball.Location.X - ballSpeedX, Ball.Location.Y);
                foreach(Control control in this.Controls)
                {
                    if(Ball.Bounds.IntersectsWith(control.Bounds) && Ball.Location.X <= control.Location.X+control.Width&& control.Name != Ball.Name && control.Name != Star1.Name && control.Name != Star2.Name && control.Name != Star3.Name)
                    {
                        if (control.Visible == false)
                        {
                            break;
                        }
                        Ball.Location = new Point(Ball.Location.X+ballSpeedX, Ball.Location.Y);
                        break;
                    }
                }
            }
            if (KeyR)
            {
                Ball.Location = new Point(Ball.Location.X + ballSpeedX, Ball.Location.Y);
                foreach (Control control in this.Controls)
                {
                    if (Ball.Bounds.IntersectsWith(control.Bounds) && Ball.Location.X+Ball.Width >= control.Location.X && control.Name != Ball.Name && control.Name != Star1.Name && control.Name != Star2.Name && control.Name != Star3.Name)
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
                    if (Ball.Bounds.IntersectsWith(control.Bounds) 
                        && control.Name != Ball.Name 
                        && control.Name != Star1.Name && control.Name != Star2.Name && control.Name != Star3.Name) 
                        // 별과 자신을 제외한 오브젝트와 충돌시 동작
                    {
                        rect_up = new Rectangle(Ball.Location.X, Ball.Location.Y + 1, Ball.Width, 1); // 공의 윗면 
                        if (control.Bounds.IntersectsWith(rect_up) && control.Visible)
                        {
                            ballSpeedY = -ballForce;
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
                            stage1_clear = true;
                            timer1.Enabled=false;
                            this.Visible= false;
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

                    
                }
            }

        }

        private void Stage1_Shown(object sender, EventArgs e)
        {
            if (stage1_clear == false)
            {
                Reset();
            }
        }
    }
}
