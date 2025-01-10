using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace fouater
{
    public partial class ارقام_الزبائن : Form
    {

        private string connString = Company.databasePath;
        private int monthIndex = 0;
        private int yearIndex = 0;
        public ارقام_الزبائن()
        {
            InitializeComponent();
        }

        private void ارقام_الزبائن_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Font = new Font("Tahoma", 10);
            dataGridView2.DefaultCellStyle.Font = new Font("Tahoma", 10);
            DateTime dt = DateTime.Now;
            dataGridView1.RowTemplate.Height = 50;
            dataGridView2.RowTemplate.Height = 50;
            //getting day of the month
            string mon = dt.Month.ToString();
            string yea = dt.Year.ToString();
            month.Text = mon;
            year.Text = yea;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string cmdString = "select count(phoneNumber) from invoices where phoneNumber!=@val1 and phoneNumber!=@val2";

                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", "0");
                    comm.Parameters.AddWithValue("@val2", " ");
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    if (reader1.Read())
                        label2.Text = reader1.GetValue(0).ToString();
                    conn.Close();
                }
                cmdString = "select phoneNumber from invoices where phoneNumber!=@val1 and year=@val2 and month=@val3";

                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", "0");
                    comm.Parameters.AddWithValue("@val2",yea);
                    comm.Parameters.AddWithValue("@val3", mon);
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    var count = 1;
                    while (reader1.Read())
                    {
                        dataGridView1.Rows.Add(count.ToString(), reader1.GetValue(0).ToString());
                        count++;
                    }
                    conn.Close();
                }

                //dataGridView2
                cmdString = "select count(phoneNumber),userName from invoices where phoneNumber!=@val1 and year=@val2 and month=@val3 group by userName";

                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", "0");
                    comm.Parameters.AddWithValue("@val2", yea);
                    comm.Parameters.AddWithValue("@val3", mon);
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    var count = 1;
                    while (reader1.Read())
                    {
                        dataGridView2.Rows.Add(count.ToString(), reader1.GetValue(1).ToString(), reader1.GetValue(0).ToString());
                        count++;
                    }
                    conn.Close();
                }
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            getData();
            left.Enabled = true;
            right.Enabled = true;
            yearIndex = Convert.ToInt32(year.Text);
            monthIndex = Convert.ToInt32(month.Text);
        }
        private void getData()
        {
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            string cmdString = "select phoneNumber from invoices where phoneNumber!=@val1 and year=@val2 and month=@val3";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", "0");
                    comm.Parameters.AddWithValue("@val2", year.Text);
                    comm.Parameters.AddWithValue("@val3", month.Text);
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    var count = 1;
                    while (reader1.Read())
                    {
                        dataGridView1.Rows.Add(count.ToString(), reader1.GetValue(0).ToString());
                        count++;
                    }
                    conn.Close();
                }
                //dataGridView2
                cmdString = "select count(phoneNumber),userName from invoices where phoneNumber!=@val1 and year=@val2 and month=@val3 group by userName";

                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", "0");
                    comm.Parameters.AddWithValue("@val2", year.Text);
                    comm.Parameters.AddWithValue("@val3", month.Text);
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    var count = 1;
                    while (reader1.Read())
                    {
                        dataGridView2.Rows.Add(count.ToString(), reader1.GetValue(1).ToString(), reader1.GetValue(0).ToString());
                        count++;
                    }
                    conn.Close();
                }
            }
        }
        private void search_MouseDown(object sender, MouseEventArgs e)
        {
            search.BackColor = Color.Black;
        }

        private void search_MouseUp(object sender, MouseEventArgs e)
        {
            search.BackColor = Color.LightGray;
        }

        private void search_MouseEnter(object sender, EventArgs e)
        {
            search.ForeColor = Color.Red;
        }

        private void search_MouseLeave(object sender, EventArgs e)
        {
            search.ForeColor = Color.OrangeRed;
        }

        private void left_MouseDown(object sender, MouseEventArgs e)
        {
            left.BackColor = Color.Black;
        }

        private void left_MouseEnter(object sender, EventArgs e)
        {
            left.ForeColor = Color.Red;
        }

        private void left_MouseUp(object sender, MouseEventArgs e)
        {
            left.BackColor = Color.LightGray;
        }

        private void left_MouseLeave(object sender, EventArgs e)
        {
            left.ForeColor = Color.OrangeRed;
        }

        private void right_MouseUp(object sender, MouseEventArgs e)
        {
            right.BackColor = Color.LightGray;
        }

        private void right_MouseLeave(object sender, EventArgs e)
        {
            right.ForeColor = Color.OrangeRed;
        }

        private void right_MouseDown(object sender, MouseEventArgs e)
        {
            right.BackColor = Color.Black;
        }

        private void right_MouseEnter(object sender, EventArgs e)
        {
            right.ForeColor = Color.Red;
        }

        private void year_KeyPress(object sender, KeyPressEventArgs e)
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

        private void left_Click(object sender, EventArgs e)
        {
            monthIndex++;
            if (monthIndex > 12)
            {
                monthIndex = 1;
                yearIndex++;
            }
            year.Text = yearIndex.ToString();
            month.Text = monthIndex.ToString();
            getData();
        }

        private void right_Click(object sender, EventArgs e)
        {
            monthIndex--;
            if (monthIndex < 1)
            {
                monthIndex = 12;
                yearIndex--;
            }
            year.Text = yearIndex.ToString();
            month.Text = monthIndex.ToString();
            getData();
        }
    }
}
