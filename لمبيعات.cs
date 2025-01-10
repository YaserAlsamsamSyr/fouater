using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using SixLabors.ImageSharp.Processing;

namespace fouater
{
    public partial class لمبيعات : Form
    {

        private double totalPricee;
        private int index;
        private string connString;
        public لمبيعات()
        {
            InitializeComponent();
        }
        
        private void لمبيعات_Load(object sender, EventArgs e)
        {

            productView.DefaultCellStyle.Font = new Font("Tahoma", 10);
            productView.RowTemplate.Height = 50;
            connString = Company.databasePath;
            //'Hide the last blank line.
            productView.AllowUserToAddRows = false;
            this.index = 0;
            // TODO: This line of code loads data into the 'modelDataSet.products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.modelDataSet.products);
            label4.Text = Company.branchName;
            if (Employee.rolee == "مدير")
            {
                string cmdString = "select userName from employees";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        try
                        {
                            conn.Open();
                            SqlDataReader reader1 = comm.ExecuteReader();
                            textBox1.Items.Clear();
                            textBox1.Enabled = true;
                            while (reader1.Read())
                            {
                                textBox1.Items.Add(reader1.GetValue(0).ToString());
                            }
                            conn.Close();
                            textBox1.Text = Employee.userNamee;
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
                textBox1.Text = Employee.userNamee;
                textBox1.Enabled = false;
            }
            getClassType();
            DateTime dt = DateTime.Now;
            //getting day of the month
            string day = dt.Day.ToString();
            string month = dt.Month.ToString();
            string year = dt.Year.ToString();
            dayTextBox.Text =day;
            monthTextBox.Text =month;
            yearTextBox.Text =year;
            save.Enabled = false;
            button1.Enabled = false;
            textBox6.Enabled = false;
            listBox2.Enabled = false;
            button4.Enabled = false;
            if(Employee.authh == "لا")
            {
                saveTextBox.Visible = false;
                label16.Visible = false;
                
            }
            comboBox1.Text = "visa";
        }
        private void getClassType()
        {
            listBox1.Items.Clear();
            string cmdString = "select distinct class from products where isDeleted=@val1";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1",0);
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
            var vat = Convert.ToDouble(Company.vat)/100;
            vat*= Convert.ToDouble(totalPriceTextBox.Text);
            //
            printer.vat = Convert.ToString(vat);
            //
            vat += Convert.ToDouble(totalPriceTextBox.Text);
            Company.box+= vat;
            if (comboBox1.Text == "visa") {
                Company.visa +=vat;
            }
            else
            {
                Company.cash += Convert.ToDouble(totalPriceTextBox.Text);
            }
                string cmdString = "Update companies SET box =@val1,visa=@val2,cash=@val3 WHERE id =@val4;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", Company.box);
                    comm.Parameters.AddWithValue("@val2", Company.visa);
                    comm.Parameters.AddWithValue("@val3", Company.cash);
                    comm.Parameters.AddWithValue("@val4", Company.id);
                    conn.Open();
                    comm.ExecuteReader();
                    conn.Close();
                }
                cmdString = "select box,cash,visa from employees where userName=@val1";
                var inId = "";
                var boxx = 0.0;
                var visa=0.0;
                var cash=0.0;
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1",textBox1.Text);
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    if (reader1.Read())
                    {
                        boxx = Convert.ToDouble(reader1.GetValue(0).ToString());//emp box
                        cash = Convert.ToDouble(reader1.GetValue(1).ToString());//emp cash
                        visa = Convert.ToDouble(reader1.GetValue(2).ToString());//emp visa
                    }
                    conn.Close();
                }
                boxx =boxx+vat;
                if (comboBox1.Text == "visa")
                    visa +=Convert.ToDouble(textBox5.Text);
                else
                    cash+= Convert.ToDouble(totalPriceTextBox.Text);
                if (textBox1.Text == Employee.userNamee) {
                    Employee.boxx = boxx;
                    Employee.visa = visa;
                    Employee.cash = cash;
                }
                    cmdString = "Update employees SET box =@val1,cash=@val4,visa=@val3 WHERE userName=@val2;";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", boxx);
                    comm.Parameters.AddWithValue("@val4",cash);
                    comm.Parameters.AddWithValue("@val3", visa);
                    comm.Parameters.AddWithValue("@val2", textBox1.Text);
                    conn.Open();
                    comm.ExecuteReader();
                    conn.Close();
                }

                //create invoice
                var time = DateTime.Now;
                cmdString = "INSERT INTO invoices (year,month,day,totalPrice,user_id,userName,type,time,sav,phoneNumber,isvisa) VALUES (@val1,@val2,@val3,@val4,@val6,@val7,@val8,@val9,@s,@val10,@val11)";

                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {

                    comm.Parameters.AddWithValue("@val1", yearTextBox.Text);
                    comm.Parameters.AddWithValue("@val2", monthTextBox.Text);
                    comm.Parameters.AddWithValue("@val3", dayTextBox.Text);
                    comm.Parameters.AddWithValue("@val4", vat.ToString());
                    comm.Parameters.AddWithValue("@val6", Employee.idd.ToString());
                    comm.Parameters.AddWithValue("@val7", textBox1.Text);
                    comm.Parameters.AddWithValue("@val8", label13.Text);
                    comm.Parameters.AddWithValue("@val9", time.ToString());
                    comm.Parameters.AddWithValue("@s", saveTextBox.Text);
                    if(textBox8.Text=="")
                        comm.Parameters.AddWithValue("@val10", "0");
                    else
                        comm.Parameters.AddWithValue("@val10", textBox8.Text);
                    comm.Parameters.AddWithValue("@val11", comboBox1.Text);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                //get current invoice id
                cmdString = "select id from invoices where time='" + time.ToString()+"'";
                inId = "";
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
                for (var row= 0;row< productView.Rows.Count;row++)
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
                    var am = Convert.ToInt64(inId) - proId[i][1];
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
            printer.invType ="مبيعات";
            printer.price = Convert.ToString(Convert.ToDouble(totalPriceTextBox.Text) + Convert.ToDouble(saveTextBox.Text));
            printer.discount =saveTextBox.Text;
            printer.finalPrice = textBox5.Text;
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
            listBox1.Text = "";
            listBox2.Text = "";
            listBox2.Enabled = false;
            totalPriceTextBox.Text = "0";
            textBox5.Text = "0";
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            listBox2.Text = "";
            button1.Enabled = false;
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
                            button4.Enabled = true;
                            textBox6.Text = "1";
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
            if (saveTextBox.Text != "")
            {
                var price = this.totalPricee;
                price -= Convert.ToDouble(saveTextBox.Text);
                totalPriceTextBox.Text = price.ToString();
                var vat = Convert.ToDouble(Company.vat) / 100;
                vat *= Convert.ToDouble(totalPriceTextBox.Text);
                vat += Convert.ToDouble(totalPriceTextBox.Text);
                textBox5.Text = vat.ToString();
                if (productView.Rows.Count > 0)
                    save.Enabled = true;
            }
            else
            {
                save.Enabled = false;
                saveTextBox.Text = "0";
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var open=new استعلام_عن_المبيعات();
            open.Show();
                    
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

        private void button1_Click(object sender, EventArgs e)
        {
            save.Enabled = true;
            var t = 0.0;
            if(button4.Text=="لا")
                t = Convert.ToDouble(textBox3.Text) * Convert.ToInt64(textBox6.Text);
            
            this.totalPricee += t;
            var totalInvPrice = this.totalPricee - Convert.ToDouble(saveTextBox.Text);
            totalPriceTextBox.Text = totalInvPrice.ToString();
            var check = false;
            if (button4.Text != "نعم")
                for (var row = 0; row < productView.Rows.Count; row++)
                {
                    if (Convert.ToString(productView.Rows[row].Cells[1].Value) == textBox2.Text)
                    {       
                            if (Convert.ToString(productView.Rows[row].Cells[2].Value) == "هدية")
                                      continue;
                            check = true;
                            productView.Rows[row].Cells[4].Value = Convert.ToInt64(productView.Rows[row].Cells[4].Value) + Convert.ToInt64(textBox6.Text);
                            productView.Rows[row].Cells[7].Value = Convert.ToInt64(productView.Rows[row].Cells[4].Value) * Convert.ToDouble(textBox3.Text);
                            break;             
                    }
                }
            
            if (!check)
            {
                if (button4.Text == "نعم")
                    productView.Rows.Add(
                        this.index + 1,
                        textBox2.Text,
                        "هدية",
                        listBox1.Text + " " + listBox2.Text,
                        textBox6.Text,
                        "0",
                        textBox4.Text,
                        "0"
                    );
                else
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
            var vat = Convert.ToDouble(Company.vat) / 100;
            vat *= Convert.ToDouble(totalPriceTextBox.Text);
            vat += Convert.ToDouble(totalPriceTextBox.Text);
            textBox5.Text = vat.ToString();
            textBox6.Enabled = false;
            listBox1.Text = "";
            listBox2.Text = "";
            listBox2.Enabled = false;
            textBox6.Text = "1";
            textBox3.Text = "";
            textBox4.Text = "";
            button4.Enabled = false;
            button4.Text = "لا";
            button4.ForeColor = Color.Black;
        }

        private void productView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8) {
                int roww = productView.CurrentCellAddress.Y;
                var row = productView.CurrentRow;
                this.totalPricee -=Convert.ToDouble( productView[7, roww].EditedFormattedValue.ToString());
                var totalInvPrice = this.totalPricee - Convert.ToDouble(saveTextBox.Text);
                totalPriceTextBox.Text = totalInvPrice.ToString();
                productView.Rows.Remove(row);
                this.index--;
                if (this.index == 0)
                    save.Enabled = false;
                var vat = Convert.ToDouble(Company.vat) / 100;
                vat *= Convert.ToDouble(totalPriceTextBox.Text);
                vat += Convert.ToDouble(totalPriceTextBox.Text);
                textBox5.Text = vat.ToString();
            }
        }
        //
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

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            save.Enabled = true;
            var id = "";
            var classs="";
            var name = "";
            var amount = "";
            var price = "";
            var barcode = "";
            ///
            string cmdString = "select * from products where barcode=@val1";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", textBox7.Text);
                    try
                    {
                        conn.Open();
                        SqlDataReader reader1 = comm.ExecuteReader();
                        if (reader1.Read())
                        {
                            id = reader1.GetValue(0).ToString();
                            classs = reader1.GetValue(1).ToString();
                            name = reader1.GetValue(2).ToString();
                            amount =(1).ToString();
                            price = reader1.GetValue(4).ToString();
                            barcode = reader1.GetValue(5).ToString();


                            conn.Close();
                            ///
                            var t = Convert.ToDouble(amount) * Convert.ToInt64(price);
                            this.totalPricee += t;
                            var totalInvPrice = this.totalPricee - Convert.ToDouble(saveTextBox.Text);
                            totalPriceTextBox.Text = totalInvPrice.ToString();
                            var check = false;
                            for (var row = 0; row < productView.Rows.Count; row++)
                            {
                                if (Convert.ToString(productView.Rows[row].Cells[1].Value) == id)
                                {
                                    check = true;
                                    productView.Rows[row].Cells[4].Value = Convert.ToInt64(productView.Rows[row].Cells[4].Value) + Convert.ToInt64(amount);
                                    productView.Rows[row].Cells[7].Value = Convert.ToInt64(productView.Rows[row].Cells[4].Value) * Convert.ToDouble(price);
                                    break;
                                }
                            }
                            if (!check)
                            {
                                productView.Rows.Add(
                                    this.index + 1,
                                    id,
                                    classs,
                                    name,
                                    amount,
                                    price,
                                    barcode,
                                    t.ToString()
                                );
                                this.index++;
                            }
                            button1.Enabled = false;
                            var vat = Convert.ToDouble(Company.vat) / 100;
                            vat *= Convert.ToDouble(totalPriceTextBox.Text);
                            vat += Convert.ToDouble(totalPriceTextBox.Text);
                            textBox5.Text = vat.ToString();
                            textBox6.Enabled = false;
                            listBox1.Text = "";
                            listBox2.Text = "";
                            listBox2.Enabled = false;
                            textBox7.Text = "";
                            textBox7.Focus();
                        }
                    }
                    catch (SqlException err)
                    {
                        MessageBox.Show("يوجد خطأ");
                        MessageBox.Show(err.Message);
                    }
                }
            }
        }

        private void لمبيعات_MouseClick(object sender, MouseEventArgs e)
        {
            textBox7.Text = "";
            textBox7.Focus();
        }

        private void button2_MouseDown_1(object sender, MouseEventArgs e)
        {

            button2.BackColor = Color.Black;
        }

        private void button2_MouseEnter_1(object sender, EventArgs e)
        {

            button2.ForeColor = Color.Red;
        }

        private void button2_MouseUp_1(object sender, MouseEventArgs e)
        {

            button2.BackColor = Color.LightGray;
        }

        private void button2_MouseLeave_1(object sender, EventArgs e)
        {

            button2.ForeColor = Color.DarkRed;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox7.Text = "";
            textBox7.Focus();
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.Black;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.ForeColor = Color.Red;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.LightGray;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            if (button4.Text == "لا")
                button4.ForeColor = Color.Black;
            else if (button4.Text == "نعم")
                button4.ForeColor = Color.Green;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "لا")
            {
                button4.ForeColor = Color.Green;
                button4.Text="نعم";
            }
            else if (button4.Text == "نعم")
            {
                button4.ForeColor = Color.Black;
                button4.Text = "لا";
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
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

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
                e.Handled = true;
        }
    }
}