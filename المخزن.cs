using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ZXing;

namespace fouater
{
    public partial class المخزن : Form
    {
        private string connString;
        public المخزن()
        {
            InitializeComponent();
        }

        private void المخزن_Load(object sender, EventArgs e)
        {

            productDataGridView.DefaultCellStyle.Font = new Font("Tahoma", 10);
            productDataGridView.RowTemplate.Height = 50;
            connString = Company.databasePath;
            getClassType();
            getAllproducts();
            getDetails();
        }
        private void getDetails()
        {
            string cmdString = "select sum(amount),sum(price) from products where amount>@val1 and isDeleted=@val2";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", 0);
                    comm.Parameters.AddWithValue("@val2", 0);
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    if (reader1.Read())
                    {
                        if (reader1.GetValue(0).ToString() != "")
                            label8.Text = reader1.GetValue(0).ToString();
                        else
                            label8.Text = "0";
                        if (reader1.GetValue(1).ToString() != "")
                            label9.Text = Convert.ToString(Convert.ToInt32(label8.Text) * Convert.ToDouble(reader1.GetValue(1).ToString()));
                        else
                            label9.Text = "0";
                    }
                    else
                    {
                        label8.Text ="0";
                        label9.Text = "0";
                    }
                    conn.Close();
                }
            }
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
        private void getAllproducts()
        {
            productDataGridView.Rows.Clear();
            //'Hide the last blank line.
            productDataGridView.AllowUserToAddRows = false;
            string cmdString = "select * from products where isDeleted=@val1";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1",0);
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    var count = 1;
                    while (reader1.Read())
                    {
                        productDataGridView.Rows.Add(
                        count.ToString(),
                        reader1.GetValue(0).ToString(),//id
                        reader1.GetValue(1).ToString(),//class
                        reader1.GetValue(2).ToString(),//name
                        reader1.GetValue(3).ToString(),//amount
                        reader1.GetValue(4).ToString(),//price
                        reader1.GetValue(5).ToString()//barcode
                        );
                        count++;
                    }
                    conn.Close();
                }
            }
        }
        private void deletePro(string id)
        {
            //string cmdString = "DELETE FROM products WHERE id =" + id;
            string cmdString = "update products set isDeleted=@val1 WHERE id =@val2";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", 1);
                    comm.Parameters.AddWithValue("@val2", id);
                    conn.Open();
                    comm.ExecuteReader();
                    conn.Close();
                    MessageBox.Show("تمت عملية الحذف");
                }
            }
        }
        private void updatePro(Product pro)
        {
                string cmdString = "Update products SET class =@val1, name =@val2, amount =@val3, price =@val4 WHERE id =@val5;";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", pro.Class);
                    comm.Parameters.AddWithValue("@val2", pro.name);
                    comm.Parameters.AddWithValue("@val3", pro.amount);
                    comm.Parameters.AddWithValue("@val4", pro.price);
                    comm.Parameters.AddWithValue("@val5", pro.id);
                    conn.Open();
                    comm.ExecuteReader();
                    conn.Close();
                    MessageBox.Show("تمت عملية التعديل");
                    }
                } 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (bar.Text == "" || pri.Text == "" || am.Text == "" || na.Text == "" || listBox1.Text == "")
            {
                MessageBox.Show("قم بملئ جميع الحقول");
            }
            else {
                    var check = false;
                    float proId = -1;
                    var amount = "0";
                    var isDeleted = "0";
                    string cmdString = "select id,amount,isDeleted from products where class=@val2 and name=@val3";
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                    //
                        using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                           comm.Parameters.AddWithValue("@val2", listBox1.Text);
                           comm.Parameters.AddWithValue("@val3", na.Text);
                           try
                           {
                              conn.Open();
                              SqlDataReader reader1 = comm.ExecuteReader();
                              if (reader1.Read())
                              {
                                proId = Convert.ToInt64(reader1.GetValue(0).ToString());
                                amount =reader1.GetValue(1).ToString();
                                isDeleted =reader1.GetValue(2).ToString();
                                check =true;
                              } else
                                check=false;
                              conn.Close();
                           } catch (SqlException err) {
                              MessageBox.Show("يوجد خطأ");
                              MessageBox.Show(err.Message);
                           }
                        }

                    if (check)
                    {
                        if (isDeleted=="1")
                        {
                            cmdString = "update products set isDeleted=@val1,class=@val3,name=@val4,amount=@val5,price=@val6,barcode=@val7 where id=@val2";
                            using (SqlCommand comm = new SqlCommand(cmdString, conn))
                            {
                                comm.Parameters.AddWithValue("@val1", 0);
                                comm.Parameters.AddWithValue("@val2", proId);
                                comm.Parameters.AddWithValue("@val3", listBox1.Text);
                                comm.Parameters.AddWithValue("@val4", na.Text);
                                comm.Parameters.AddWithValue("@val5", am.Text);
                                comm.Parameters.AddWithValue("@val6", pri.Text);
                                comm.Parameters.AddWithValue("@val7", bar.Text);
                                try
                                {
                                    conn.Open();
                                    comm.ExecuteNonQuery();
                                    conn.Close();
                                    this.getAllproducts();
                                    MessageBox.Show("تمت الاضافة بنجاح");
                                    getClassType();
                                }
                                catch (SqlException err)
                                {
                                    MessageBox.Show("يوجد خطأ");
                                    MessageBox.Show(err.Message);
                                }
                            }
                        }
                        else {
                            cmdString = "update products set isDeleted=@val1,class=@val3,name=@val4,amount=@val5,price=@val6,barcode=@val7 where id=@val2";
                            using (SqlCommand comm = new SqlCommand(cmdString, conn))
                            {
                                comm.Parameters.AddWithValue("@val1", 0);
                                comm.Parameters.AddWithValue("@val2", proId);
                                comm.Parameters.AddWithValue("@val3", listBox1.Text);
                                comm.Parameters.AddWithValue("@val4", na.Text);
                                comm.Parameters.AddWithValue("@val5", Convert.ToInt32(am.Text)+Convert.ToInt32(amount));
                                comm.Parameters.AddWithValue("@val6", pri.Text);
                                comm.Parameters.AddWithValue("@val7", bar.Text);
                                try
                                {
                                    conn.Open();
                                    comm.ExecuteNonQuery();
                                    conn.Close();
                                    this.getAllproducts();
                                    MessageBox.Show("تمت الاضافة بنجاح");
                                    getClassType();
                                }
                                catch (SqlException err)
                                {
                                    MessageBox.Show("يوجد خطأ");
                                    MessageBox.Show(err.Message);
                                }
                            }
                        }
                    }
                    else
                    {
                        cmdString = "INSERT INTO products (class,name,amount,price,barcode) VALUES (@val1, @val2, @val3,@val4,@val5)";
                        using (SqlCommand comm = new SqlCommand(cmdString, conn))
                        {
                            comm.Parameters.AddWithValue("@val1", listBox1.Text);
                            comm.Parameters.AddWithValue("@val2", na.Text);
                            comm.Parameters.AddWithValue("@val3", am.Text);
                            comm.Parameters.AddWithValue("@val4", pri.Text);
                            comm.Parameters.AddWithValue("@val5", bar.Text);
                            try
                            {
                                conn.Open();
                                comm.ExecuteNonQuery();
                                conn.Close();
                                listBox1.Text = "";
                                na.Text = "";
                                this.getAllproducts();
                                MessageBox.Show("تمت الاضافة بنجاح");
                                getClassType();
                            }
                            catch (SqlException err)
                            {
                                MessageBox.Show("يوجد خطأ");
                                MessageBox.Show(err.Message);
                            }
                        }
                    }
                    }
                getDetails();
            }
            bar.Text = "";

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (na.Text == "" || listBox1.Text == "") {
                MessageBox.Show("قم بملئ الحقول سابقة اولا");
            } else
            {
                var barr = listBox1.Text + na.Text;
                var barcode = 125;
                for (var i = 0; i < barr.Length; i++)
                {
                    char alphabet = barr[i];
                    int number = alphabet;
                    barcode += number;
                }
                bar.Text = barcode.ToString();
            }
        }

        private void am_KeyPress(object sender, KeyPressEventArgs e)
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

        private void pri_KeyPress(object sender, KeyPressEventArgs e)
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

        ////////// for gradeview
        private void productDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                int row = productDataGridView.CurrentCellAddress.Y;
                var barcode = productDataGridView[6, row].EditedFormattedValue.ToString();
                var pri = productDataGridView[5, row].EditedFormattedValue.ToString();
                var na= productDataGridView[2, row].EditedFormattedValue.ToString()+" "+productDataGridView[3, row].EditedFormattedValue.ToString();
                (new باركود(barcode,pri,na)).Show();
            }
            else if (e.ColumnIndex == 7)//update
            {
                var regx = @"^[0-9]+(.[0-9]+)?$";
                var colIndex = 2;
                int row = productDataGridView.CurrentCellAddress.Y;
                var amount=productDataGridView[colIndex + 2, row].EditedFormattedValue.ToString();
                var price = productDataGridView[colIndex + 3, row].EditedFormattedValue.ToString();
                if (!Regex.IsMatch(amount, regx) || !Regex.IsMatch(price, regx))
                {
                    MessageBox.Show("البيانات المدخلة بها خطأ");
                }
                else
                {
                    var pro = new Product();
                    pro.id = Convert.ToInt64(productDataGridView[1, row].EditedFormattedValue);
                    pro.Class = productDataGridView[colIndex, row].EditedFormattedValue.ToString();
                    pro.name = productDataGridView[colIndex + 1, row].EditedFormattedValue.ToString();
                    pro.amount = Convert.ToInt64(amount);
                    pro.price = Convert.ToDouble(price);
                    this.updatePro(pro);
                    this.getAllproducts();
                    getDetails();
                }
            }
            else if (e.ColumnIndex == 8)//delete
            {
                DialogResult dialogResult = MessageBox.Show("متأكد, سيتم حذف المنتج بشكل نهائي", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int row = productDataGridView.CurrentCellAddress.Y;
                    var proId = productDataGridView[1, row].EditedFormattedValue.ToString();
                    this.deletePro(proId);
                    this.getAllproducts();
                    getDetails();
                }
            }
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
            button2.ForeColor = Color.DarkGreen;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.Black;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.IndianRed;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.LightGray;
        }
    }
}
