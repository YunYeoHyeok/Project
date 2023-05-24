using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncyBall
{
    public partial class Stage8 : Form
    {
        public static bool Stage8_clear = false; 
        private int ballSpeedX = 5;  // 공의 x축 속도
        private int ballSpeedY = 0;  // 공의 y축 속도
        private int ballForce = -10; // 새로운 공의 힘
        private int GRAVITY = 1;  // 공의 가속도
        private bool KeyL = false; // 방향키 왼쪽 입력 - 누르고 있을 때 동작하게 하기 위함
        private bool KeyR = false; // 방향키 오른쪽 입력 - 누르고 있을 때 동작하게 하기 위함
        private int start_X; // 게임시작시 공의 x축 위치
        private int start_Y; // 게임시작시 공의 y축 위치
        private int starcnt = 0; // 별 카운터
        private bool flag_jump; // 점프 여부
        private bool flag_doublejump = false; // 더블점프 아이템 획득 여부
        private bool flag_spider = false; // 끈끈이 블럭 충돌 여부
        private bool flag_RightStraight = false; // 오른쪽 직진블럭 충돌 여부
        private bool flag_LeftStraight = false; // 왼쪽 직진 블럭 충돌 여부
        private List<PictureBox> picturelist = new List<PictureBox>(); // 일회용 발판 PictureBox 리스트
        private Rectangle rect_up, rect_down, rect_left, rect_right; // 공의 상하좌우 영역
        public Stage8()
        {
            InitializeComponent();
        }
        private void Reset()  // 스테이지 초기화
        {
            timer1.Enabled= false;
            flag_LeftStraight=false;
            flag_RightStraight=false;
            Ball.Location = new Point(start_X, start_Y);
            Ball.Image = Properties.Resources.ball_trans;
            label1.Text = "0 / 3";
            starcnt = 0;
            /*foreach(Control item in this.Controls)
            {
                if(item.Visible==false)
                    item.Visible = true;
            }*/
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
            timer1.Enabled = true;
        } 
        private void PlayerLimit() // 플레이어 맵밖으로 나갈 시 공 위치 조정
        {
           
            if (Ball.Location.X >= 690)
            {
                flag_LeftStraight = false;
                flag_RightStraight = false;
                ballSpeedY = GRAVITY;
                Ball.Location = new Point(690, Ball.Location.Y);
            }
            else if (Ball.Location.X < 0)
            {
                flag_LeftStraight = false;
                flag_RightStraight = false;
                ballSpeedY = GRAVITY;
                Ball.Location = new Point(0, Ball.Location.Y);
            }
            if (Ball.Location.Y + Ball.Size.Height >= this.ClientSize.Height) // 공이 맵 아래로 추락시 리셋
            {
                ballSpeedY = GRAVITY;
                Ball.Location = new Point(start_X, start_Y);
                Reset();
            }
        }


        private void PJHStage_Load(object sender, EventArgs e) // 폼 로드시 공의 시작위치 저장 ,일회용 발판 리스트에 저장
        {
            start_X = Ball.Location.X;
            start_Y = Ball.Location.Y;

            picturelist.Add(OneJump1);
            picturelist.Add(OneJump2);
            picturelist.Add(OneJump3);
            picturelist.Add(OneJump4);
            picturelist.Add(OneJump5);
            if(Stage8_clear == false)
            {
                Reset();
            }
        }

        private void Stage8_FormClosed(object sender, FormClosedEventArgs e) // 강제 종료시 열려있는 폼들 확인 후 닫음
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

        private void PJHStage_KeyUp(object sender, KeyEventArgs e)
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

        private void PJHStage_KeyDown(object sender, KeyEventArgs e)
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
                    if (flag_doublejump) // 더블 점프아이템 획득 후 키입력시 동작
                    {
                        ballSpeedY = ballForce;
                        flag_doublejump = false;
                        Ball.Image = Properties.Resources.ball_trans;
                    }
                    else if(flag_spider) // 끈끈이 블럭에 붙은 상태에서 키입력시 동작
                    {
                        ballSpeedY = ballForce;
                        flag_spider = false;
                    }
                    break;
                default:
                    break;
            }
            PlayerLimit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (KeyL)
            {
                flag_RightStraight = false;
                flag_LeftStraight = false;
                flag_spider = false;
                Ball.Location = new Point(Ball.Location.X - ballSpeedX, Ball.Location.Y);
                foreach (Control control in this.Controls)
                {
                    if (Ball.Bounds.IntersectsWith(control.Bounds) && Ball.Location.X <= control.Location.X + control.Width && control.Name != Ball.Name && control.Name != Star1.Name && control.Name != Star2.Name && control.Name != Star3.Name && control.Name != DoubleJump1.Name && control.Name != DoubleJump2.Name)
                    {
                        rect_left = new Rectangle(Ball.Location.X, Ball.Location.Y, 1, Ball.Height); // 공 기준 왼쪽영역 설정
                        rect_right = new Rectangle(Ball.Location.X + Ball.Width - 1, Ball.Location.Y, 1, Ball.Height);// 공 기준 오른쪽 영역 설정
                        if (control.Visible == false) // 컨트롤이 맵에 안보이면 통과
                        {
                            break;
                        }
                        if (control.Bounds.IntersectsWith(rect_right) && (control.Name == spider1.Name || control.Name == spider2.Name)) 
                        {
                            flag_spider = true;
                            break;
                        }
                        else if (control.Bounds.IntersectsWith(rect_left) && (control.Name == spider1.Name || control.Name == spider2.Name))
                        {
                            flag_spider = true;
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
                flag_spider = false;
                Ball.Location = new Point(Ball.Location.X + ballSpeedX, Ball.Location.Y);
                foreach (Control control in this.Controls)
                {
                    if (Ball.Bounds.IntersectsWith(control.Bounds) && Ball.Location.X + Ball.Width >= control.Location.X && control.Name != Ball.Name && control.Name != Star1.Name && control.Name != Star2.Name && control.Name != Star3.Name && control.Name != DoubleJump1.Name && control.Name != DoubleJump2.Name)
                    {
                        flag_spider = false;
                        rect_left = new Rectangle(Ball.Location.X, Ball.Location.Y, 1, Ball.Height);
                        rect_right = new Rectangle(Ball.Location.X + Ball.Width - 1, Ball.Location.Y, 1, Ball.Height);
                        if (control.Visible == false)
                        {
                            break;
                        }
                        if (control.Bounds.IntersectsWith(rect_left) && (control.Name == spider1.Name || control.Name == spider2.Name))
                        {
                            flag_spider= true;
                            break;
                        }
                        else if (control.Bounds.IntersectsWith(rect_right) && (control.Name == spider1.Name || control.Name == spider2.Name))
                        {
                            flag_spider = true;
                        }
                        Ball.Location = new Point(Ball.Location.X - ballSpeedX, Ball.Location.Y);
                        break;
                    }
                }
            }


            if (flag_LeftStraight)
            {
                KeyL = false;
                KeyR = false;
                Ball.Location = new Point(Ball.Location.X - ballSpeedX * 2, Ball.Location.Y);
                foreach (Control control in this.Controls)
                {
                    if (Ball.Bounds.IntersectsWith(control.Bounds)  && control.Name != Ball.Name && control.Name != Star1.Name && control.Name != Star2.Name && control.Name != Star3.Name && control.Name != DoubleJump1.Name && control.Name != DoubleJump2.Name)
                    {
                        if (control is Panel)
                        {
                            ballSpeedY = GRAVITY;
                            Reset();
                            break;
                        }
                        else if (control.Name == spider1.Name || control.Name == spider2.Name)
                        {
                            flag_spider = true;
                            ballSpeedY = 1;
                            flag_jump = true;
                            break;
                        }
                        Ball.Location = new Point(control.Location.X + control.Width, Ball.Location.Y);
                        PlayerLimit();
                        flag_LeftStraight = false;
                        flag_spider = false;
                        break;
                    }
                }
            }
            else if (flag_RightStraight)
            {
                KeyL = false;
                KeyR = false;
                Ball.Location = new Point(Ball.Location.X + ballSpeedX * 2, Ball.Location.Y);
                foreach (Control control in this.Controls)
                {
                    if (Ball.Bounds.IntersectsWith(control.Bounds) && Ball.Location.X + Ball.Width >= control.Location.X && control.Name != Ball.Name && control.Name != Star1.Name && control.Name != Star2.Name && control.Name != Star3.Name && control.Name != DoubleJump1.Name && control.Name != DoubleJump2.Name)
                    {
                        if(control is Panel)
                        {
                            ballSpeedY = GRAVITY;
                            Reset();
                            break;
                        }
                        else if (control.Name == spider1.Name || control.Name == spider2.Name)
                        {
                            flag_spider=true;
                            ballSpeedY = 1;
                            flag_jump = true;
                            Ball.Location = new Point(control.Location.X - Ball.Width, Ball.Location.Y);
                            flag_RightStraight = false;
                            break;
                        }
                        Ball.Location = new Point(control.Location.X - Ball.Width, Ball.Location.Y + 2);
                        PlayerLimit();
                        flag_RightStraight = false;
                        flag_spider = false;
                        break;
                    }
                }
            }
            else
            { 
                if(flag_spider)
                {
                    Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + ballSpeedY);
                    ballSpeedY = 1;
                }
                else
                {
                    ballSpeedY += GRAVITY;
                    Ball.Location = new Point(Ball.Location.X, Ball.Location.Y + ballSpeedY);
                }
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
                        ballSpeedY = GRAVITY;
                        Reset();
                        break;
                    }
                } // 장애물 충돌
                if (control is PictureBox)  // 오브젝트 충돌
                {
                    if (flag_jump == false && Ball.Bounds.IntersectsWith(control.Bounds) 
                        && control.Name != Ball.Name 
                        && control.Name != Star1.Name && control.Name != Star2.Name && control.Name != Star3.Name 
                        && control.Name != DoubleJump1.Name && control.Name != DoubleJump2.Name)
                    {
                        Rectangle rect_control_down = new Rectangle(control.Location.X, control.Location.Y + control.Height - 1, control.Width, 1);
                        flag_RightStraight = false;
                        flag_LeftStraight = false;
                        rect_up = new Rectangle(Ball.Location.X, Ball.Location.Y + 1, Ball.Width, 1);
                        rect_down = new Rectangle(Ball.Location.X, Ball.Location.Y + Ball.Height - 1, Ball.Width, 1);
                        if (control.Bounds.IntersectsWith(rect_up) && control.Visible)
                        {
                            ballSpeedY = -ballForce;
                            flag_jump = true;
                            Ball.Location = new Point(Ball.Location.X,control.Location.Y+control.Height);
                            break;
                        } // 아래에서 위로 충돌 시
                        else if ( !control.Bounds.IntersectsWith(rect_down) &&(control.Name == spider1.Name || control.Name==spider2.Name))
                        {
                            flag_spider = true;
                            flag_jump = true;
                            ballSpeedY = 1;
                            break;
                        } // 끈끈이 블럭 충돌 시 
                        else if (control.Name == RightStraight1.Name || control.Name == RightStraight2.Name)
                        {
                            Ball.Location = new Point(control.Location.X + control.Width, control.Location.Y);
                            flag_RightStraight = true;
                            ballSpeedY = 0;
                            break;
                        }
                        else if (control.Name == LeftStraight.Name)
                        {
                            Ball.Location = new Point(control.Location.X - Ball.Width, control.Location.Y + 2);
                            flag_LeftStraight = true;
                            ballSpeedY = 0;
                            break;
                        }
                        else
                        {
                            if (control.Name == OneJump1.Name || control.Name == OneJump2.Name || control.Name == OneJump3.Name || control.Name == OneJump4.Name || control.Name == OneJump5.Name)
                            {
                                if (control.Visible == true)
                                {
                                    control.Visible = false;
                                    ballSpeedY = ballForce;
                                    flag_jump = true;
                                    break;
                                }
                            }
                            else
                            {
                                ballSpeedY = ballForce;
                                flag_jump = true;
                                break;
                            }
                        }
                    }
                    // 맨땅 충돌
                    else if (Ball.Bounds.IntersectsWith(control.Bounds) && (control.Name == Star1.Name || control.Name == Star2.Name || control.Name == Star3.Name))
                    {
                        if (starcnt == 3)
                        {
                            Stage8_clear = true;
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
                            break;
                        }
                    }
                    // 더블점프 먹었을 때

                }
            }
        }
    }
}
