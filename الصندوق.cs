using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace fouater
{
    public partial class الصندوق : Form
    {
        private string connString;
        public الصندوق()
        {
            InitializeComponent();
        }

        private void الصندوق_Load(object sender, EventArgs e)
        {
            connString = Company.databasePath;
            label5.Text = Employee.lastDate;
            label6.Text = Company.branchName;
            label7.Text = Employee.userNamee;
            if (Employee.rolee != "مدير")
            {
                textBox1.Text = Employee.boxx.ToString();
                textBox2.Text = Employee.cash.ToString();
                textBox3.Text = Employee.visa.ToString();
            }
            else
            {
                textBox1.Text = Company.box.ToString();
                textBox2.Text = Company.cash.ToString();
                textBox3.Text = Company.visa.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            updateEmpBox();
            Employee.boxx = 0;
            Employee.visa = 0;
            Employee.cash = 0;
        }
        private void updateEmpBox()
        {
            string cmdString = "update employees set box=@val1 , lastDate=@val2 , visa=@val4 , cash=@val5 where id=@val3";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", 0);
                    comm.Parameters.AddWithValue("@val2", DateTime.Now.ToString("MM / dd / yyyy HH: mm"));
                    comm.Parameters.AddWithValue("@val3", Employee.idd);
                    comm.Parameters.AddWithValue("@val4", 0);
                    comm.Parameters.AddWithValue("@val5", 0);
                    conn.Open();
                    comm.ExecuteReader();
                    conn.Close();
                    label5.Text = DateTime.Now.ToString("MM / dd / yyyy HH: mm");
                    Employee.boxx = 0;
                    Employee.lastDate = DateTime.Now.ToString("MM / dd / yyyy HH: mm");
                }
                if (Employee.rolee == "مدير")
                {
                    cmdString = "update companies set box=@val1,visa=@val4,cash=@val6 where id=@val2";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", 0);
                        comm.Parameters.AddWithValue("@val2", Company.id);
                        comm.Parameters.AddWithValue("@val6", 0);
                        comm.Parameters.AddWithValue("@val4", 0);
                        conn.Open();
                        comm.ExecuteReader();
                        conn.Close();
                    }
                    Company.box = 0;
                    Company.visa = 0;
                    Company.cash = 0;
                }
            }
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
            button1.ForeColor = Color.DarkGreen;
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
            button2.ForeColor = Color.DarkRed;
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
            button3.ForeColor = Color.Black;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //print
            printer.companyBranch = Company.branchName;
            printer.empName = Employee.userNamee;
            printer.lastDate = label5.Text;
            printer.finalPrice = textBox1.Text;
            printer.printReset();
            //
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printer.openCasher();
        }
    }
}
