using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace fouater
{
    public partial class معلومات_الفرع : Form
    {
        private string connString;
        public معلومات_الفرع()
        {
            InitializeComponent();
            textBox2.Text = Company.companyName;
            textBox1.Text = Company.branchName;
            connString = Company.databasePath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cmdString = "update companies set companyName=@val1 , branchName=@val2 where id=@val3";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", textBox2.Text);
                    comm.Parameters.AddWithValue("@val2", textBox1.Text);
                    comm.Parameters.AddWithValue("@val3", Company.id);
                    conn.Open();
                    comm.ExecuteReader();
                    conn.Close();
                }
            }
            Company.companyName= textBox2.Text;
            Company.branchName= textBox1.Text;
            textBox2.Text = Company.companyName;
            textBox1.Text = Company.branchName;
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

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Black;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.LightGray;
        }
    }
}
