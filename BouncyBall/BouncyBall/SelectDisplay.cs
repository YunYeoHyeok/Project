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
    public partial class SelectDisplay : Form
    {
        public static Stage1 Stage1 = new Stage1();
        public static Stage2 Stage2 = new Stage2();
        public static Stage3 Stage3 = new Stage3();
        public static Stage4 Stage4 = new Stage4();
        public static Stage5 Stage5 = new Stage5();
        public static Stage6 Stage6 = new Stage6();
        public static Stage7 Stage7 = new Stage7();
        public static Stage8 Stage8 = new Stage8();
        public SelectDisplay()
        {
            InitializeComponent();


        }


        private void SelectDisplay_Shown(object sender, EventArgs e)
        {
            if (Stage1.stage1_clear == true && Stage2.stage2_clear == true && Stage3.stage3_clear == true && Stage4.stage4_clear == true && Stage5.stage5_clear == true
                && Stage6.Stage6_clear == true && Stage7.Stage7_clear == true && Stage8.Stage8_clear == true)
            {
                this.Visible = false;
                VictoryDisplay victoryDisplay = new VictoryDisplay();
                victoryDisplay.Show();
                this.Hide();
            }   
        }


        private void SelectDisplay_Load(object sender, EventArgs e)
        {
            if (Stage1.stage1_clear == true) { button1.Text = "CLEAR"; }
            if (Stage2.stage2_clear == true) { button2.Text = "CLEAR"; }
            if (Stage3.stage3_clear == true) { button3.Text = "CLEAR"; }
            if (Stage4.stage4_clear == true) { button4.Text = "CLEAR"; }
            if (Stage5.stage5_clear == true) { button5.Text = "CLEAR"; }
            if (Stage6.Stage6_clear == true) { button6.Text = "CLEAR"; }
            if (Stage7.Stage7_clear == true) { button7.Text = "CLEAR"; }
            if (Stage8.Stage8_clear == true) { button8.Text = "CLEAR"; }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Stage1 = new Stage1();
            Stage1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Stage2 = new Stage2();
            Stage2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Stage3 = new Stage3();
            Stage3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Stage4 = new Stage4();
            Stage4.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Stage5 = new Stage5();
            Stage5.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Stage6 = new Stage6();
            Stage6.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Stage7 = new Stage7();
            Stage7.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Stage8 = new Stage8();
            Stage8.Show();
            this.Hide();
        }

        private void SelectDisplay_FormClosed(object sender, FormClosedEventArgs e)
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
