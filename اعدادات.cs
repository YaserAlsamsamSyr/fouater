using System;
using System.Drawing;
using System.Windows.Forms;

namespace fouater
{
    public partial class اعدادات : Form
    {
        public اعدادات()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var open = new معلومات_الفرع();
            open.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var open = new الاجهزة_المتصلة();
            open.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var open = new اعدادات_عامة();
            open.ShowDialog();
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.Black;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.LightGray;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Peru;
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
            button3.ForeColor = Color.Peru;
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
            button2.ForeColor = Color.Black;
        }

        private void اعدادات_Load(object sender, EventArgs e)
        {
            if (Employee.rolee == "مدير")
            {
                button1.Visible = true;
                button3.Visible=true;
            }
        }
    }
}
