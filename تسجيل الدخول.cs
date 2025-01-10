using IronSoftware.Drawing;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace fouater
{
    public partial class تسجيل_الدخول : Form
    {
        private string connString;
        public تسجيل_الدخول()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("قم بملئ جميع الحقول");
            }
            else
            {
               
                string cmdString = "select * from employees where userName=@val1 and password=@val2";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", listBox1.Text);
                        comm.Parameters.AddWithValue("@val2", textBox2.Text);
                        conn.Open();
                        SqlDataReader reader1 = comm.ExecuteReader();
                        if (!reader1.Read())
                        {
                            MessageBox.Show("المعلومات المدخلة خاطئة");
                            return;
                        }
                        else
                        {
                            cmdString = "select * from companies";
                            using (SqlCommand command = new SqlCommand(cmdString, conn))
                            {
                                Employee.idd =Convert.ToInt16( reader1.GetValue(0).ToString());
                                Employee.userNamee = reader1.GetValue(1).ToString();
                                Employee.passwordd = reader1.GetValue(2).ToString();
                                Employee.rolee = reader1.GetValue(3).ToString();
                                Employee.company_idd = reader1.GetValue(4).ToString();
                                Employee.boxx =Convert.ToDouble( reader1.GetValue(5).ToString());
                                Employee.lastDate = reader1.GetValue(6).ToString();
                                Employee.authh = reader1.GetValue(7).ToString();
                                Employee.cash = Convert.ToDouble(reader1.GetValue(8).ToString());
                                Employee.visa = Convert.ToDouble(reader1.GetValue(9).ToString());
                                string role = reader1.GetValue(3).ToString();
                                conn.Close();
                                conn.Open();
                                reader1 = command.ExecuteReader();
                                if (reader1.Read())
                                {
                                    Company.id = Convert.ToInt16(reader1.GetValue(0));
                                    Company.companyName = reader1.GetValue(1).ToString();
                                    Company.branchName = reader1.GetValue(2).ToString();
                                    Company.box = Convert.ToDouble(reader1.GetValue(3));
                                    Company.date = reader1.GetValue(4).ToString();
                                    Company.typeMonye = reader1.GetValue(5).ToString();
                                    Company.unitMonye = reader1.GetValue(6).ToString();
                                    Company.vat = reader1.GetValue(7).ToString();
                                    Company.visa = Convert.ToDouble(reader1.GetValue(8).ToString());
                                    Company.cash = Convert.ToDouble(reader1.GetValue(9).ToString());
                                }
                                //this.Hide();
                                var open = new الرئيسية(role, this);
                                open.Show();

                            }
                        }
                        conn.Close();
                    }
                    cmdString = "update employees set lastLogin=@val2 where userName=@val1";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                            comm.Parameters.AddWithValue("@val1", Employee.userNamee);
                            comm.Parameters.AddWithValue("@val2", DateTime.Now.ToString("MM / dd / yyyy HH: mm"));
                            conn.Open();
                            comm.ExecuteReader();
                            conn.Close();
                    }
                    label4.Text = "";
                    label5.Text = "";
                }
            }
        }

        private void تسجيل_الدخول_Load(object sender, EventArgs e)
        {
            connString = Company.databasePath;
            getEmployees();
            string cmdString = "select * from printers";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1.GetValue(2).ToString() == "bill")
                            الاجهزة_المتصلة.bilPrinter = reader1.GetValue(1).ToString();
                        if (reader1.GetValue(2).ToString() == "barcode")
                            الاجهزة_المتصلة.barcodePrinter = reader1.GetValue(1).ToString();
                    }
                    conn.Close();
                }
            }
        }

        public void getEmployees()
        {
            listBox1.Items.Clear();
            string cmdString = "select userName from employees";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    while (reader1.Read())
                        listBox1.Items.Add(reader1.GetValue(0).ToString());
                    conn.Close();
                    textBox2.Text = "";
                }
            }
        }
        // style
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.Black;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.Silver;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor=Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Firebrick;
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string cmdString = "select lastLogin from employees where userName=@val1";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", listBox1.Text);
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    if (reader1.Read())
                    {
                        label4.Visible = true;
                        label5.Visible=true;
                        label5.Text = reader1.GetValue(0).ToString();
                        label4.Text = "أخر تسجيل دخول";
                    }
                    conn.Close();
                }
            }
        }
    }
}
