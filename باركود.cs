using System;
using System.Drawing;
using System.Windows.Forms;

namespace fouater
{
    public partial class باركود : Form
    {
        private string connString;
        public static string price;
        public static string name;
        public static string barcode;
        public باركود(string barcod,string pri,string nam)
        {
            InitializeComponent();
            barcode = barcod;
            price = pri;
            name = nam;
        }

        private void باركود_Load(object sender, EventArgs e)
        {
            connString = Company.databasePath;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.Black;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.IndianRed;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.LightGray;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                printer.number = textBox1.Text;
                printer.printBarcode();
            }
            else
                MessageBox.Show("قم بإدخال العدد");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
