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
    public partial class VictoryDisplay : Form
    {
        public VictoryDisplay()
        {
            InitializeComponent();
            pictureBox_cong.BackColor = Color.Transparent;
            pictureBox_cong.Parent = pictureBox_Victory;
            label_cong.Parent = pictureBox_Victory;
        }

        private void button_Return_Click(object sender, EventArgs e)
        {
            Stage1.stage1_clear = false;
            Stage2.stage2_clear = false;
            Stage3.stage3_clear = false;
            Stage4.stage4_clear = false;
            Stage5.stage5_clear = false;
            Stage6.Stage6_clear= false;
            Stage7.Stage7_clear= false;
            Stage8.Stage8_clear= false;
            this.Visible = false;
            MainDisplay mainDisplay = new MainDisplay();
            mainDisplay.Show();
        }

        private void VictoryDisplay_FormClosed(object sender, FormClosedEventArgs e)
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
