using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace fouater
{
    public partial class استعلام_عن_المشتريات : Form
    {
        private List<List<string>> invoicies = new List<List<string>>();
        private int invoiceIndex;
        private string connString;
        private SqlConnection conn;
        private bool check;
        private string currentInvoice;
        private int currentInvId;
        public استعلام_عن_المشتريات()
        {
            InitializeComponent();
        }

        private void استعلام_عن_المشتريات_Load(object sender, EventArgs e)
        {

            productView.DefaultCellStyle.Font = new Font("Tahoma", 10);
            productView.RowTemplate.Height = 50;
            connString = Company.databasePath;
            //'Hide the last blank line.
            productView.AllowUserToAddRows = false;
            DateTime dt = DateTime.Now;
            string dday = dt.Day.ToString();
            string mmonth = dt.Month.ToString();
            string yyear = dt.Year.ToString();
            day.Text = dday;
            month.Text = mmonth;
            year.Text = yyear;
            label4.Text = Company.branchName;
            conn = new SqlConnection(connString);
            check = true;
            currentInvoice = "0";
            currentInvId = 0;
        }
        private void to_left()
        {

            if (!check)
                this.invoiceIndex++;
            if (this.invoiceIndex < this.invoicies.Count)
            {
                if (this.invoiceIndex != 0)
                    right.Enabled = true;
                else
                    right.Enabled = false;
                if (this.invoiceIndex + 1 >= this.invoicies.Count)
                    left.Enabled = false;
                else
                    left.Enabled = true;
                productView.Rows.Clear();
                //first invoice
                var invId = this.invoicies[invoiceIndex][0];
                currentInvId = invoiceIndex;
                totalPriceTextBox.Text = this.invoicies[invoiceIndex][1];
                textBox1.Text = this.invoicies[invoiceIndex][2];
                saveTextBox.Text = this.invoicies[invoiceIndex][3];
                List<List<string>> prosId = new List<List<string>>();//all products in this invoice
                string cmdString = "select product_id,amount,proPrice from Inv_Pro where invoice_id=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", invId);
                    currentInvoice = invId;
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    while (reader1.Read())
                    {
                        List<string> oneInv = new List<string>();
                        oneInv.Add(reader1.GetValue(0).ToString());
                        oneInv.Add(reader1.GetValue(1).ToString());
                        oneInv.Add(reader1.GetValue(2).ToString());
                        prosId.Add(oneInv);
                    }
                    conn.Close();
                }
                for (int i = 0; i < prosId.Count; i++)
                {
                    cmdString = "select * from products where id=@val1";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", prosId[i][0]);
                        conn.Open();
                        SqlDataReader reader1 = comm.ExecuteReader();

                        if (reader1.Read())
                        {
                            productView.Rows.Add("" + (i + 1),
                                reader1.GetValue(0).ToString(),
                                reader1.GetValue(1).ToString(),
                                reader1.GetValue(2).ToString(),
                                prosId[i][1].ToString(),
                                prosId[i][2].ToString(),
                                reader1.GetValue(5).ToString(),
                                "" + (Convert.ToDouble(reader1.GetValue(4)) * Convert.ToInt64(prosId[i][1])));

                        }
                        conn.Close();
                    }
                }
                check = true;
                this.invoiceIndex++;
            }
        }
        private void to_right()
        {
            if (check)
                this.invoiceIndex--;
            this.invoiceIndex--;
            if (this.invoiceIndex >= 0)
            {
                if (this.invoiceIndex != 0)
                    right.Enabled = true;
                else
                    right.Enabled = false;
                left.Enabled = true;
                check = false;
                productView.Rows.Clear();
                //first invoice
                var invId = this.invoicies[invoiceIndex][0];
                currentInvId = invoiceIndex;
                totalPriceTextBox.Text = this.invoicies[invoiceIndex][1];
                textBox1.Text = this.invoicies[invoiceIndex][2];
                saveTextBox.Text = this.invoicies[invoiceIndex][3];
                List<List<string>> prosId = new List<List<string>>();//all products in this invoice
                string cmdString = "select product_id,amount,proPrice from Inv_Pro where invoice_id=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", invId);
                    currentInvoice = invId;
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    while (reader1.Read())
                    {
                        List<string> oneInv = new List<string>();
                        oneInv.Add(reader1.GetValue(0).ToString());
                        oneInv.Add(reader1.GetValue(1).ToString());
                        oneInv.Add(reader1.GetValue(2).ToString());
                        prosId.Add(oneInv);
                    }
                    conn.Close();
                }
                for (int i = 0; i < prosId.Count; i++)
                {
                    cmdString = "select * from products where id=@val1";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", prosId[i][0]);
                        conn.Open();
                        SqlDataReader reader1 = comm.ExecuteReader();

                        if (reader1.Read())
                        {
                            productView.Rows.Add("" + (i + 1),
                                reader1.GetValue(0).ToString(),
                                reader1.GetValue(1).ToString(),
                                reader1.GetValue(2).ToString(),
                                prosId[i][1].ToString(),
                                prosId[i][2].ToString(),
                                reader1.GetValue(5).ToString(),
                                "" + (Convert.ToDouble(reader1.GetValue(4)) * Convert.ToInt64(prosId[i][1])));

                        }
                        conn.Close();
                    }
                }
            }
        }
        private void search_Click(object sender, EventArgs e)
        {
            this.invoiceIndex = 0;
            this.invoicies.Clear();
            string cmdString = "select id,totalPrice,userName,sav from invoices where year=@val1 and month=@val2 and day=@val3 and type=@val4";
            try
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", year.Text);
                    comm.Parameters.AddWithValue("@val2", month.Text);
                    comm.Parameters.AddWithValue("@val3", day.Text);
                    comm.Parameters.AddWithValue("@val4", "مشتريات");
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    while (reader1.Read())
                    {
                        List<string> oneInv = new List<string>();
                        oneInv.Add(reader1.GetValue(0).ToString());
                        oneInv.Add(reader1.GetValue(1).ToString());
                        oneInv.Add(reader1.GetValue(2).ToString());
                        oneInv.Add(reader1.GetValue(3).ToString());
                        this.invoicies.Add(oneInv);
                    }
                    conn.Close();
                }
                if (this.invoicies.Count > 0)
                {
                    delete.Enabled = true;
                    to_left();
                }
                else
                {
                    delete.Enabled = false;
                    textBox1.Text = "";
                    saveTextBox.Text = "";
                    totalPriceTextBox.Text = "";
                    productView.Rows.Clear();
                    this.invoicies.Clear();
                }
            }
            catch (SqlException err)
            {
                MessageBox.Show("يوجد خطأ");
                MessageBox.Show(err.Message);
            }
        }

        private void right_Click(object sender, EventArgs e)
        {
            to_right();
        }

        private void left_Click(object sender, EventArgs e)
        {
            to_left();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("متأكد, سيتم حذف الفاتورة بشكل نهائي", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string cmdString = "delete invoices where id=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", currentInvoice);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                cmdString = "delete Inv_Pro where invoice_id=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", currentInvoice);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                // update box
                //update user box
                var empBox = "";
                var ttotalInvPrice = Convert.ToDouble(totalPriceTextBox.Text);
                cmdString = "select box from employees where userName=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", textBox1.Text);
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    if (reader1.Read())
                        empBox = reader1.GetValue(0).ToString();
                    conn.Close();
                }
                cmdString = "update employees set box=@val2 where userName=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", textBox1.Text);
                    comm.Parameters.AddWithValue("@val2", Convert.ToDouble(empBox) + ttotalInvPrice);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                //update company box
                cmdString = "update companies set box=@val2 where id=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", Company.id);
                    comm.Parameters.AddWithValue("@val2", Company.box + ttotalInvPrice);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                Company.box += ttotalInvPrice;
                //
                this.invoicies.RemoveAt(currentInvId);
                this.invoiceIndex = currentInvId;
                if (this.invoicies.Count == 0)
                {
                    textBox1.Text = "";
                    saveTextBox.Text = "";
                    totalPriceTextBox.Text = "";
                    productView.Rows.Clear();
                    this.invoicies.Clear();
                    delete.Enabled = false;
                    left.Enabled = false;
                    right.Enabled = false;
                }
                else
                {
                    this.check = true;
                    this.invoiceIndex = 0;
                    right.Enabled = false;
                    to_left();
                }
            }
        }

        private void delete_MouseDown(object sender, MouseEventArgs e)
        {
            delete.BackColor = Color.Black;
        }

        private void delete_MouseEnter(object sender, EventArgs e)
        {
            delete.ForeColor = Color.Red;
        }

        private void delete_MouseLeave(object sender, EventArgs e)
        {
            delete.ForeColor = Color.DarkRed;
        }

        private void delete_MouseUp(object sender, MouseEventArgs e)
        {
            delete.BackColor = Color.LightGray;
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
    }
}
