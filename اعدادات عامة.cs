using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace fouater
{
    public partial class اعدادات_عامة : Form
    {
        private string connString;
        public اعدادات_عامة()
        {
            InitializeComponent();
        }

        private void اعدادات_عامة_Load(object sender, EventArgs e)
        {
            connString = Company.databasePath;
            textBox1.Text = Company.typeMonye;
            textBox2.Text = Company.unitMonye;
            textBox3.Text = Company.vat;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdString = "update companies set typeMonye=@val1 , unitMonye=@val2 , vat=@val4 where id=@val3";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", textBox1.Text);
                    comm.Parameters.AddWithValue("@val2", textBox2.Text);
                    comm.Parameters.AddWithValue("@val4", textBox3.Text);
                    comm.Parameters.AddWithValue("@val3", Company.id);
                    conn.Open();
                    comm.ExecuteReader();
                    conn.Close();
                }
            }
            Company.typeMonye= textBox1.Text;
            Company.unitMonye= textBox2.Text;
            Company.vat= textBox3.Text;
            textBox1.Text = Company.typeMonye;
            textBox2.Text = Company.unitMonye;
            textBox3.Text= Company.vat;
            MessageBox.Show("تم تعديل بنجاح");
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
            button1.ForeColor = Color.IndianRed;
        }
    }
}
