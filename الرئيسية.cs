using System;
using System.Drawing;
using System.Windows.Forms;

namespace fouater
{
    public partial class الرئيسية : Form
    {
        private  string user_type;
        private تسجيل_الدخول window;
        public الرئيسية(string user_type="موظق",تسجيل_الدخول window=null)
        {
            InitializeComponent();
            this.user_type = user_type;
            if (user_type == "مدير")
            {
                button1.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button9.Visible = true;
            }
            this.window = window;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var open = new المشتريات();
            open.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var open = new لمبيعات();
            open.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var open = new المخزن();
            open.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var open = new الموظفين();
            open.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var open = new اعدادات();
            open.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var open = new الصندوق();
            open.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (user_type == "مدير")
            {
                button1.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
            }
            this.Close();
            window.getEmployees();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void الرئيسية_Load(object sender, EventArgs e)
        {
            label5.Text = Company.companyName;
            label6.Text = Company.branchName;
            label7.Text = DateTime.Now.ToString("dd / MM / yyyy");
        }
        // style
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.Black;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.LightGray;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.DarkRed;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.Black;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Red;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.LightGray;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.ForestGreen;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.Black;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Red;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.LightGray;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Olive;
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.Black;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.LightGray;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.ForeColor = Color.Red;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.DarkOrchid;
        }

        private void button6_MouseDown(object sender, MouseEventArgs e)
        {
            button6.BackColor = Color.Black;
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            button6.BackColor = Color.LightGray;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.ForeColor = Color.Red;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.ForeColor = Color.Firebrick;
        }

        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            button5.BackColor = Color.Black;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.ForeColor = Color.Red;
        }

        private void button5_MouseUp(object sender, MouseEventArgs e)
        {
            button5.BackColor = Color.LightGray;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.ForeColor = Color.Black;
        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            button8.BackColor = Color.Black;
        }

        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            button8.BackColor = Color.LightGray;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            button8.ForeColor = Color.Red;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            button8.ForeColor = Color.IndianRed;
        }

        private void button7_MouseDown(object sender, MouseEventArgs e)
        {
            button7.BackColor = Color.Black;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            button7.ForeColor = Color.Red;
        }

        private void button7_MouseUp(object sender, MouseEventArgs e)
        {
            button7.BackColor = Color.LightGray;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            button7.ForeColor = Color.IndianRed;
        }

        private void الرئيسية_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.window.getEmployees();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var phoneForm=new ارقام_الزبائن();
            phoneForm.Show();
        }

        private void button9_MouseDown(object sender, MouseEventArgs e)
        {
            button9.BackColor = Color.Black;
        }

        private void button9_MouseEnter(object sender, EventArgs e)
        {
            button9.ForeColor = Color.Red;
        }

        private void button9_MouseUp(object sender, MouseEventArgs e)
        {
            button9.BackColor = Color.LightGray;
        }

        private void button9_MouseLeave(object sender, EventArgs e)
        {
            button9.ForeColor = Color.DarkBlue;
        }
    }
}
