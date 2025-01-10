using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace fouater
{
    public partial class المشتريات : Form
    {

        private double totalPricee;
        private int index;
        private string connString;
        public المشتريات()
        {
            InitializeComponent();
        }

        private void المشتريات_Load(object sender, EventArgs e)
        {

            productView.DefaultCellStyle.Font = new Font("Tahoma", 10);
            productView.RowTemplate.Height = 50;
            saveTextBox.Enabled = false;
            connString = Company.databasePath;
            //'Hide the last blank line.
            productView.AllowUserToAddRows = false;
            this.index = 0;
            // TODO: This line of code loads data into the 'modelDataSet.products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.modelDataSet.products);
            label4.Text = Company.branchName;
            textBox1.Text = Employee.userNamee;
            getClassType();
            DateTime dt = DateTime.Now;
            //getting day of the month
            string day = dt.Day.ToString();
            string month = dt.Month.ToString();
            string year = dt.Year.ToString();
            dayTextBox.Text = day;
            monthTextBox.Text = month;
            yearTextBox.Text = year;
            save.Enabled = false;
            textBox1.Text = Employee.userNamee;
            button1.Enabled = false;
            textBox6.Enabled = false;
            listBox2.Enabled= false;
        }
        private void getClassType()
        {
            listBox1.Items.Clear();
            string cmdString = "select distinct class from products where isDeleted=@val1";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", 0);
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    while (reader1.Read())
                        listBox1.Items.Add(reader1.GetValue(0).ToString());
                    conn.Close();
                }
            }
        }
        private void save_Click(object sender, EventArgs e)
        {
            Company.box -= Convert.ToDouble(totalPriceTextBox.Text);
            string cmdString = "Update companies SET box ='" + Company.box + "' WHERE id ='" + Company.id + "';";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    conn.Open();
                    comm.ExecuteReader();
                    conn.Close();
                }
                Employee.boxx -= Convert.ToDouble(totalPriceTextBox.Text);
                cmdString = "Update employees SET box = '" + Employee.boxx + "' WHERE id ='" + Employee.idd + "';";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    conn.Open();
                    comm.ExecuteReader();
                    conn.Close();
                }

                //create invoice
                var time = DateTime.Now;
                cmdString = "INSERT INTO invoices (year,month,day,totalPrice,user_id,userName,type,time,sav) VALUES (@val1,@val2,@val3,@val4,@val6,@val7,@val8,@val9,@s)";

                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {

                    comm.Parameters.AddWithValue("@val1", yearTextBox.Text);
                    comm.Parameters.AddWithValue("@val2", monthTextBox.Text);
                    comm.Parameters.AddWithValue("@val3", dayTextBox.Text);
                    comm.Parameters.AddWithValue("@val4", totalPriceTextBox.Text);
                    comm.Parameters.AddWithValue("@val6", Employee.idd.ToString());
                    comm.Parameters.AddWithValue("@val7", Employee.userNamee);
                    comm.Parameters.AddWithValue("@val8", label13.Text);
                    comm.Parameters.AddWithValue("@val9", time.ToString());
                    comm.Parameters.AddWithValue("@s", saveTextBox.Text);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                //get current invoice id
                cmdString = "select id from invoices where time='" + time.ToString() + "'";
                var inId = "";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    if (reader1.Read())
                    {
                        inId = reader1.GetValue(0).ToString();//id
                        printer.invNum = inId;
                    }
                    conn.Close();
                }
                var proId = new List<List<double>>();//put all product id
                for (var row = 0; row < productView.Rows.Count; row++)
                {
                    var proInfo = new List<double>();//each product save id and amount
                    proInfo.Add(Convert.ToInt64(productView.Rows[row].Cells[1].Value));//id
                    proInfo.Add(Convert.ToInt64(productView.Rows[row].Cells[4].Value));//amount
                    proInfo.Add(Convert.ToDouble(productView.Rows[row].Cells[5].Value));//proPrice
                    proId.Add(proInfo);
                }
                for (int i = 0; i < proId.Count; i++)
                {
                    cmdString = "INSERT INTO inv_Pro (invoice_id,product_id,amount,proPrice) VALUES (@val1, @val2, @val3,@val4)";

                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", inId);
                        comm.Parameters.AddWithValue("@val2", proId[i][0]);
                        comm.Parameters.AddWithValue("@val3", proId[i][1]);
                        comm.Parameters.AddWithValue("@val4", proId[i][2]);
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                for (int i = 0; i < proId.Count; i++)
                {
                    cmdString = "select amount from products where id='" + proId[i][0] + "'";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        conn.Open();
                        SqlDataReader reader1 = comm.ExecuteReader();
                        if (reader1.Read())
                            inId = reader1.GetValue(0).ToString();//amount
                        conn.Close();
                    }
                    //
                    var am = Convert.ToInt64(inId) + proId[i][1];
                    cmdString = "update products set amount='" + am + "' where id='" + proId[i][0] + "'";

                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            // print invoice
            printer.data = productView;
            printer.empName = textBox1.Text;
            printer.invType = "مشتريات";
            printer.price = Convert.ToString(Convert.ToDouble(totalPriceTextBox.Text)-Convert.ToDouble(saveTextBox.Text));
            printer.discount = saveTextBox.Text;
            printer.finalPrice = totalPriceTextBox.Text;
            printer.vat = "0";
            printer.companyBranch = Company.branchName;
            printer.print();
            //
            MessageBox.Show("تم بنجاح");
            save.Enabled = false;
            totalPriceTextBox.Text = "0";
            saveTextBox.Text = "0";
            productView.Rows.Clear();
            button1.Enabled = false;
            this.index = 0;
            textBox6.Enabled = false;
            this.totalPricee = 0;
            listBox2.Enabled = false;
            totalPriceTextBox.Text = "0";
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            listBox2.Text = "";
            button1.Enabled=false;
            string cmdString = "select name from products where class=@val1 and isDeleted=@val2";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", listBox1.Text);
                    comm.Parameters.AddWithValue("@val2", 0);
                    try
                    {
                        conn.Open();
                        SqlDataReader reader1 = comm.ExecuteReader();
                        listBox2.Items.Clear();
                        listBox2.Enabled = true;
                        while (reader1.Read())
                        {
                            listBox2.Items.Add(reader1.GetValue(0).ToString());
                        }
                        conn.Close();
                    }
                    catch (SqlException err)
                    {
                        MessageBox.Show("يوجد خطأ");
                        MessageBox.Show(err.Message);
                    }
                }
            }
        }

        private void listBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            string cmdString = "select * from products where name=@val1 and class=@val2 and isDeleted=@val4";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", listBox2.Text);
                    comm.Parameters.AddWithValue("@val2", listBox1.Text);
                    comm.Parameters.AddWithValue("@val4", 0);
                    try
                    {
                        conn.Open();
                        SqlDataReader reader1 = comm.ExecuteReader();
                        if (reader1.Read())
                        {
                            textBox2.Text = reader1.GetValue(0).ToString();
                            textBox3.Text = reader1.GetValue(4).ToString();
                            textBox4.Text = reader1.GetValue(5).ToString();

                            button1.Enabled = true;
                            textBox6.Enabled = true;
                        }

                        conn.Close();
                    }
                    catch (SqlException err)
                    {
                        MessageBox.Show("يوجد خطأ");
                        MessageBox.Show(err.Message);
                    }
                }
            }
        }

        private void saveTextBox_TextChanged(object sender, EventArgs e)
        {
            if (saveTextBox.Text!="")
            {
                var price = this.totalPricee;
                price -= Convert.ToDouble(saveTextBox.Text);
                totalPriceTextBox.Text = price.ToString();
                if (productView.Rows.Count > 0)
                    save.Enabled = true;
            }
            else
                save.Enabled=false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var open = new استعلام_عن_المشتريات();
            open.Show();

        }

        private void saveTextBox_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            save.Enabled = true;
            var t = Convert.ToDouble(textBox3.Text) * Convert.ToInt64(textBox6.Text);
            //this.totalPricee += t;
            //var totalInvPrice = this.totalPricee - Convert.ToDouble(saveTextBox.Text);
            //totalPriceTextBox.Text = totalInvPrice.ToString();
            var check = false;
            for (var row = 0; row < productView.Rows.Count; row++)
            {
                if (Convert.ToString(productView.Rows[row].Cells[1].Value) == textBox2.Text)
                {
                    check = true;
                    productView.Rows[row].Cells[4].Value = Convert.ToInt64(productView.Rows[row].Cells[4].Value) + Convert.ToInt64(textBox6.Text);
                    productView.Rows[row].Cells[7].Value = Convert.ToInt64(productView.Rows[row].Cells[4].Value) * Convert.ToDouble(textBox3.Text);
                    break;
                }
            }
            if (!check)
            {
                productView.Rows.Add(
                    this.index + 1,
                    textBox2.Text,
                    listBox1.Text,
                    listBox2.Text,
                    textBox6.Text,
                    textBox3.Text,
                    textBox4.Text,
                    t.ToString()
                );
                this.index++;
            }
            button1.Enabled = false;
            textBox6.Enabled = false;
            listBox1.Text = "";
            listBox2.Text = "";
            listBox2.Enabled = false;
        }

        private void productView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                int roww = productView.CurrentCellAddress.Y;
                var row = productView.CurrentRow;
                //this.totalPricee -= Convert.ToDouble(productView[7, roww].EditedFormattedValue.ToString());
                //var totalInvPrice = this.totalPricee - Convert.ToDouble(saveTextBox.Text);
                //totalPriceTextBox.Text = totalInvPrice.ToString();
                productView.Rows.Remove(row);
                this.index--;
                if(this.index==0)
                    save.Enabled = false;
            }
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.Black;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.LightGray;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Red;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.SaddleBrown;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            save.ForeColor = Color.ForestGreen;
        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            save.BackColor = Color.Black;
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            save.BackColor = Color.LightGray;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            save.ForeColor = Color.Red;
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
