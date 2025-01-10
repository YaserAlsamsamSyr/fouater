using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace fouater
{
    public partial class استعلام_عن_المبيعات : Form
    {
        private List<List<string>> invoicies = new List<List<string>>();
        private int invoiceIndex;
        private string connString;
        private SqlConnection conn;
        private bool check;
        private string currentInvoice;
        private int currentInvId;
        private bool updateOrInsert;
        private double savePrice;
        private string oldSave;
        public استعلام_عن_المبيعات()
        {
            InitializeComponent();
        }
        private void استعلام_عن_المبيعات_Load(object sender, EventArgs e)
        {

            productView.DefaultCellStyle.Font = new Font("Tahoma", 10);
            button3.Enabled = false;
            updateOrInsert = false;
            //'Hide the last blank line.
            productView.RowTemplate.Height = 50;
            productView.AllowUserToAddRows = false;
            if (Employee.rolee!="مدير")
                  delete.Visible = false;
            DateTime dt = DateTime.Now;
            string dday = dt.Day.ToString();
            string mmonth = dt.Month.ToString();
            string yyear = dt.Year.ToString();
            day.Text = dday;
            month.Text = mmonth;
            year.Text = yyear;
            label4.Text = Company.branchName;
            connString = Company.databasePath;
            conn = new SqlConnection(connString);
            check = true;
            currentInvoice = "0";
            currentInvId = 0;
            string cmdString = "select distinct class from products where isDeleted=@val1";
            using (SqlCommand comm = new SqlCommand(cmdString, conn))
            {
                comm.Parameters.AddWithValue("@val1", 0);
                conn.Open();
                SqlDataReader reader1 = comm.ExecuteReader();
                while (reader1.Read())
                    listBox1.Items.Add(reader1.GetValue(0).ToString());
                conn.Close();
            }
            if (Employee.rolee != "مدير")
            {
                listBox1.Visible = false;
                listBox2.Visible = false;
                textBox6.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox2.Visible = false;
                textBox5.Visible = false;
                button1.Visible = false;
                label11.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                button2.Visible = false;
                saveTextBox.Enabled = false;
                label14.Visible = false;
                textBox7.Visible = false;
                button3.Visible = false;
                label15.Visible = false;
                button4.Visible = false;
                productView.Columns.Remove("update");
                productView.Columns.Remove("deletee");
            }
            else
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            textBox2.Text = "";
            textBox5.Text = "";
            savePrice = 0;
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
                if (this.invoiceIndex + 1 >=this.invoicies.Count)
                    left.Enabled = false;
                else
                    left.Enabled = true;
                productView.Rows.Clear();
                //first invoice
                var invId = this.invoicies[invoiceIndex][0];
                label10.Text= this.invoicies[invoiceIndex][5];
                textBox7.Text= this.invoicies[invoiceIndex][4];
                currentInvId = invoiceIndex;
                totalPriceTextBox.Text = this.invoicies[invoiceIndex][1];
                textBox1.Text = this.invoicies[invoiceIndex][2];
                saveTextBox.Text = this.invoicies[invoiceIndex][3];
                oldSave = saveTextBox.Text;
                this.savePrice =Convert.ToDouble(saveTextBox.Text);
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
                var count = 0;
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
                            count++;
                            if (prosId[i][2].ToString() == "0") 
                                productView.Rows.Add(count.ToString(),
                                       reader1.GetValue(0).ToString(),
                                       "هدية",
                                        reader1.GetValue(1).ToString()+" "+reader1.GetValue(2).ToString(),
                                       prosId[i][1].ToString(),
                                       prosId[i][2].ToString(),
                                       reader1.GetValue(5).ToString(),
                                       "0"
                                );
                            else
                                productView.Rows.Add(count.ToString(),
                                        reader1.GetValue(0).ToString(),
                                        reader1.GetValue(1).ToString(),
                                        reader1.GetValue(2).ToString(),
                                        prosId[i][1].ToString(),
                                        prosId[i][2].ToString(),
                                        reader1.GetValue(5).ToString(),
                                        "" + (Convert.ToDouble(reader1.GetValue(4)) * Convert.ToInt64(prosId[i][1]))
                                 );
                            
                            button1.Enabled = true;
                            button3.Enabled = true;
                        }
                        else
                            button1.Enabled = false;
                        conn.Close();
                    }
                }
                var proPrice = 0.0;
                for (var i = 0; i < productView.Rows.Count; i++)
                {
                    proPrice += Convert.ToDouble(productView.Rows[Convert.ToInt32(i)].Cells[7].Value.ToString());
                }

                var saveVal = Convert.ToDouble(saveTextBox.Text);
                var save = proPrice - saveVal;
                textBox8.Text = save.ToString();
                check = true;
                this.invoiceIndex++;
                listBox1.Text = "";
                listBox2.Text = "";
                textBox6.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox2.Text = "";
                textBox5.Text = "";
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
                label10.Text = this.invoicies[invoiceIndex][5];
                textBox7.Text = this.invoicies[invoiceIndex][4];
                currentInvId = invoiceIndex;
                totalPriceTextBox.Text = this.invoicies[invoiceIndex][1];
                textBox1.Text = this.invoicies[invoiceIndex][2];
                saveTextBox.Text = this.invoicies[invoiceIndex][3];
                oldSave = saveTextBox.Text;
                this.savePrice = Convert.ToDouble(saveTextBox.Text);
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
                var count = 0;
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
                            count++;
                            if (prosId[i][2].ToString() == "0")
                                productView.Rows.Add(count.ToString(),
                                       reader1.GetValue(0).ToString(),
                                       "هدية",
                                        reader1.GetValue(1).ToString() + " " + reader1.GetValue(2).ToString(),
                                       prosId[i][1].ToString(),
                                       prosId[i][2].ToString(),
                                       reader1.GetValue(5).ToString(),
                                       "0"
                                );
                            else
                                productView.Rows.Add(count.ToString(),
                                        reader1.GetValue(0).ToString(),
                                        reader1.GetValue(1).ToString(),
                                        reader1.GetValue(2).ToString(),
                                        prosId[i][1].ToString(),
                                        prosId[i][2].ToString(),
                                        reader1.GetValue(5).ToString(),
                                        "" + (Convert.ToDouble(reader1.GetValue(4)) * Convert.ToInt64(prosId[i][1]))
                                 );

                            button1.Enabled = true;
                            button3.Enabled = true;
                        }
                        else
                            button1.Enabled = false;
                        conn.Close();
                        var proPrice = 0.0;
                        for (var ii = 0; ii < productView.Rows.Count; ii++)
                        {
                            proPrice += Convert.ToDouble(productView.Rows[Convert.ToInt32(ii)].Cells[7].Value.ToString());
                        }

                        var saveVal = Convert.ToDouble(saveTextBox.Text);
                        var save = proPrice - saveVal;
                        textBox8.Text = save.ToString();
                        listBox1.Text = "";
                        listBox2.Text = "";
                        textBox6.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox2.Text = "";
                        textBox5.Text = "";
                    }
                }
            }
        }
        private void search_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            this.invoiceIndex = 0;
            this.invoicies.Clear();
            string cmdString;
            if (Employee.rolee!="مدير")
                  cmdString = "select id,totalPrice,userName,sav,phoneNumber,isvisa from invoices where year=@val1 and month=@val2 and day=@val3 and type=@val4 and userName=@val5";
            else
                cmdString = "select id,totalPrice,userName,sav,phoneNumber,isvisa from invoices where year=@val1 and month=@val2 and day=@val3 and type=@val4";

            try
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", year.Text);
                    comm.Parameters.AddWithValue("@val2", month.Text);
                    comm.Parameters.AddWithValue("@val3", day.Text);
                    comm.Parameters.AddWithValue("@val4", "مبيعات");
                    if (Employee.rolee != "مدير")
                        comm.Parameters.AddWithValue("@val5",Employee.userNamee);
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    while (reader1.Read())
                    {
                        List<string> oneInv = new List<string>();
                        oneInv.Add(reader1.GetValue(0).ToString());
                        oneInv.Add(reader1.GetValue(1).ToString());
                        oneInv.Add(reader1.GetValue(2).ToString());
                        oneInv.Add(reader1.GetValue(3).ToString());
                        oneInv.Add(reader1.GetValue(4).ToString());
                        oneInv.Add(reader1.GetValue(5).ToString());

                        this.invoicies.Add(oneInv);
                    }
                    conn.Close();
                }
                if (this.invoicies.Count > 0)
                {
                    delete.Enabled = true;
                    button2.Enabled = true;
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
                    textBox8.Text = "";
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
                var visa = 0.0;
                var cash = 0.0;
                var ttotalInvPrice = Convert.ToDouble(totalPriceTextBox.Text);
                cmdString = "select box,visa,cash from employees where userName=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", textBox1.Text);
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    if (reader1.Read())
                    {

                        empBox = reader1.GetValue(0).ToString();
                        visa = Convert.ToDouble(reader1.GetValue(1).ToString());
                        cash = Convert.ToDouble(reader1.GetValue(2).ToString());
                    }
                    conn.Close();
                }
                if (label10.Text == "visa")
                    visa -= Convert.ToDouble(totalPriceTextBox.Text);
                else
                    cash -= Convert.ToDouble(textBox8.Text);
                if (Employee.userNamee == textBox1.Text)
                {
                    Employee.boxx -= Convert.ToDouble(totalPriceTextBox.Text);
                    Employee.visa = visa;
                    Employee.cash = cash;
                }
                cmdString = "update employees set box=@val2,cash=@val3,visa=@val4 where userName=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", textBox1.Text);
                    comm.Parameters.AddWithValue("@val2", Convert.ToDouble(empBox) - ttotalInvPrice);
                    comm.Parameters.AddWithValue("@val3",cash );
                    comm.Parameters.AddWithValue("@val4", visa);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                //update company box
                cmdString = "update companies set box=@val2,visa=@val3,cash=@val4 where id=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    Company.box -= ttotalInvPrice;
                    if (label10.Text == "visa")
                        Company.visa -= ttotalInvPrice;
                    else
                        Company.cash -= Convert.ToDouble(textBox8.Text);
                    comm.Parameters.AddWithValue("@val1", Company.id);
                    comm.Parameters.AddWithValue("@val2", Company.box);
                    comm.Parameters.AddWithValue("@val3", Company.visa);
                    comm.Parameters.AddWithValue("@val4", Company.cash);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.Text == "" || listBox2.Text == "" || textBox6.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("قم بملئ جميع الحقول");
            }
            else
            {

                var row = textBox2.Text;
                var proPrice = 0.0;
                var newInPrice = 0.0;
                var empBox = "";
                var vat = 0.0;
                string cmdString = "";
                var amount = 0;
                var visa = 0.0;
                var cash = 0.0;
                //delete current then insert new
                if (updateOrInsert)//update
                { 
                    proPrice=Convert.ToDouble(productView.Rows[Convert.ToInt32(row)].Cells[7].Value.ToString());
                    vat = Convert.ToDouble(Company.vat)/100;
                    vat *= Convert.ToDouble(proPrice);
                    proPrice += vat;
                    newInPrice =Convert.ToDouble(totalPriceTextBox.Text) - proPrice;
                    totalPriceTextBox.Text= Convert.ToString(newInPrice);
                    cmdString = "delete Inv_Pro where invoice_id=@val1 and product_id=@val2 and proPrice=@val3";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", currentInvoice);
                        comm.Parameters.AddWithValue("@val2", productView.Rows[Convert.ToInt32(row)].Cells[1].Value.ToString());
                        comm.Parameters.AddWithValue("@val3", productView.Rows[Convert.ToInt32(row)].Cells[5].Value.ToString());
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    //
                    cmdString = "select amount from products where id=@val1";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", productView.Rows[Convert.ToInt32(row)].Cells[1].Value.ToString());
                        conn.Open();
                        SqlDataReader reader1 = comm.ExecuteReader();
                        if (reader1.Read())
                            amount = Convert.ToInt32(reader1.GetValue(0).ToString());
                        conn.Close();
                    }
                    amount += Convert.ToInt32(productView.Rows[Convert.ToInt32(row)].Cells[4].Value.ToString());
                    //
                    cmdString = "update products set amount=@val2 where id=@val1";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", productView.Rows[Convert.ToInt32(row)].Cells[1].Value.ToString());
                        comm.Parameters.AddWithValue("@val2", amount);
                        conn.Open();
                        comm.ExecuteReader();
                        conn.Close();
                    }
                    //
                    //
                    cmdString = "update invoices set totalPrice=@val2 where id=@val1";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", currentInvoice);
                        comm.Parameters.AddWithValue("@val2", newInPrice);
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    //update user box
                    empBox = "";
                    cash = 0.0;
                    visa = 0.0;
                    cmdString = "select box,cash,visa from employees where userName=@val1";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1",textBox1.Text);
                        conn.Open();
                        SqlDataReader reader1 = comm.ExecuteReader();
                        if (reader1.Read())
                        {
                            empBox = reader1.GetValue(0).ToString();
                            visa =Convert.ToDouble(reader1.GetValue(2).ToString());
                            cash = Convert.ToDouble(reader1.GetValue(1).ToString());
                        }
                        conn.Close();
                    }
                    if (label10.Text == "visa")
                        visa -= proPrice;
                    else
                        cash -= Convert.ToDouble(productView.Rows[Convert.ToInt32(row)].Cells[7].Value.ToString());
                    if (Employee.userNamee == textBox1.Text)
                    {
                        Employee.boxx -= Convert.ToDouble(empBox);
                        Employee.visa =visa;
                        Employee.cash =cash;
                    }
                    cmdString = "update employees set box=@val2,cash=@val3,visa=@val4 where userName=@val1";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1",textBox1.Text);
                        comm.Parameters.AddWithValue("@val2", Convert.ToDouble(empBox) - proPrice);
                        comm.Parameters.AddWithValue("@val3",cash);
                        comm.Parameters.AddWithValue("@val4", visa);
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    //update company box
                    cmdString = "update companies set box=@val2,visa=@val4,cash=@val5 where id=@val1";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        Company.box -= proPrice;
                        if (label10.Text == "visa")
                            Company.visa -= proPrice;
                        else
                            Company.cash -= Convert.ToDouble(productView.Rows[Convert.ToInt32(row)].Cells[7].Value.ToString());
                        
                        comm.Parameters.AddWithValue("@val1", Company.id);
                        comm.Parameters.AddWithValue("@val2", Company.box);
                        comm.Parameters.AddWithValue("@val4", Company.visa);
                        comm.Parameters.AddWithValue("@val5", Company.cash);
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    productView.Rows.RemoveAt(Convert.ToInt32(row));
                }

                var proIdd =textBox5.Text;
                var totalPri = 0.0;
                if (button4.Text=="لا")
                    totalPri =Convert.ToDouble(textBox6.Text) * Convert.ToDouble(textBox3.Text);
                vat = Convert.ToDouble(Company.vat) / 100;
                vat *=totalPri;
                var helpForCash = totalPri;
                totalPri += vat;
                newInPrice = Convert.ToDouble(totalPriceTextBox.Text) + totalPri;
                totalPriceTextBox.Text = newInPrice.ToString();
                //attache pro to invoice then add totalPrice to user box and company box and invoice
                //
                var check = false;
                if (button4.Text == "لا")
                {
                    cmdString = "select amount,proPrice from Inv_Pro where invoice_id=@val1 and product_id=@val2 and proPrice!=@val5";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", currentInvoice);
                        comm.Parameters.AddWithValue("@val2", proIdd);
                        comm.Parameters.AddWithValue("@val5", "0");
                        conn.Open();
                        SqlDataReader reader1 = comm.ExecuteReader();
                        if (reader1.Read())
                            check = true;
                        conn.Close();
                    }
                }
                //
                if (check)
                {//update

                    cmdString = "update Inv_Pro set amount=@val3 , proPrice=@val4 where invoice_id=@val1 and product_id=@val2 and proPrice!=@val5";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", currentInvoice);
                        comm.Parameters.AddWithValue("@val2", proIdd);
                        comm.Parameters.AddWithValue("@val3", textBox6.Text);
                        comm.Parameters.AddWithValue("@val5","0");
                        if (button4.Text=="لا")
                            comm.Parameters.AddWithValue("@val4", textBox3.Text);
                        else
                            comm.Parameters.AddWithValue("@val4", 0);
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                else
                {//add new
                    cmdString = "insert into Inv_Pro(invoice_id,product_id,amount,proPrice) values(@val1,@val2,@val3,@val4)";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", currentInvoice);
                        comm.Parameters.AddWithValue("@val2", proIdd);
                        comm.Parameters.AddWithValue("@val3", textBox6.Text);
                        if (button4.Text == "لا")
                            comm.Parameters.AddWithValue("@val4", textBox3.Text);
                        else
                            comm.Parameters.AddWithValue("@val4", 0);
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                //
                //
                cmdString = "select amount from products where id=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", proIdd);
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    if (reader1.Read())
                        amount = Convert.ToInt32(reader1.GetValue(0).ToString());
                    conn.Close();
                }

                amount -= Convert.ToInt32(textBox6.Text);
                //
                cmdString = "update products set amount=@val2 where id=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", proIdd);
                    comm.Parameters.AddWithValue("@val2", amount);
                    conn.Open();
                    comm.ExecuteReader();
                    conn.Close();
                }
                //
                //
                cmdString = "update invoices set totalPrice=@val2 where id=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", currentInvoice);
                    comm.Parameters.AddWithValue("@val2", newInPrice);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                //update user box
                empBox = "";
                cash = 0.0;
                visa=0.0;
                cmdString = "select box,visa,cash from employees where userName=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1",textBox1.Text);
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    if (reader1.Read())
                    {
                        empBox = reader1.GetValue(0).ToString();
                        visa = Convert.ToDouble(reader1.GetValue(1).ToString());
                        cash = Convert.ToDouble(reader1.GetValue(2).ToString());
                    }
                    conn.Close();
                }
                if (label10.Text == "visa")
                    visa += proPrice;
                else
                    cash += helpForCash;
                
                cmdString = "update employees set box=@val2,cash=@val3,visa=@val4 where userName=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1",textBox1.Text);
                    comm.Parameters.AddWithValue("@val2", Convert.ToDouble(empBox) + totalPri);
                    comm.Parameters.AddWithValue("@val3",cash);
                    comm.Parameters.AddWithValue("@val4",visa);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                //update company box
                cmdString = "update companies set box=@val2,visa=@val3,cash=@val4 where id=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    Company.box += totalPri;
                    if (label10.Text == "visa")
                        Company.visa += totalPri;
                    else
                        Company.cash += helpForCash;

                    comm.Parameters.AddWithValue("@val1", Company.id);
                    comm.Parameters.AddWithValue("@val2", Company.box);
                    comm.Parameters.AddWithValue("@val3", Company.visa);
                    comm.Parameters.AddWithValue("@val4", Company.cash);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                    if (Employee.userNamee == textBox1.Text)
                    {
                        Employee.boxx += Convert.ToDouble(totalPri);
                        Employee.visa = visa;
                        Employee.cash = cash;
                    }
                }
                if (!updateOrInsert)
                {
                    check = false;
                    if (button4.Text == "لا")
                    {
                        for (var ro = 0; ro < productView.Rows.Count; ro++)
                        {
                            if (Convert.ToString(productView.Rows[ro].Cells[1].Value) == textBox5.Text)
                            {
                                if (Convert.ToString(productView.Rows[ro].Cells[2].Value) == "هدية")
                                    continue;
                                check = true;
                                productView.Rows[ro].Cells[4].Value = Convert.ToInt64(productView.Rows[ro].Cells[4].Value) + Convert.ToInt64(textBox6.Text);
                                productView.Rows[ro].Cells[5].Value = textBox3.Text;
                                productView.Rows[ro].Cells[7].Value = (Convert.ToDouble(textBox3.Text) * Convert.ToDouble(productView.Rows[ro].Cells[4].Value)).ToString();
                                break;

                            }
                        }
                    }
                    if (!check)
                    {

                        if (button4.Text == "لا")
                        productView.Rows.Add(
                            productView.Rows.Count + 1,
                            textBox5.Text,
                            listBox1.Text,
                            listBox2.Text,
                            textBox6.Text,
                            textBox3.Text,
                            textBox4.Text,
                            (Convert.ToDouble(textBox3.Text) * Convert.ToDouble(textBox6.Text)).ToString()
                        );
                        else
                            productView.Rows.Add(
                               productView.Rows.Count + 1,
                               textBox5.Text,
                               "هدية",
                               listBox1.Text+" "+listBox2.Text,
                               textBox6.Text,
                               "0",
                               textBox4.Text,
                               "0"
                            );
                    }
                }
                else {
                    check = false;
                    if (button4.Text == "لا")
                    {
                        for (var ro = 0; ro < productView.Rows.Count; ro++)
                        {
                            if (Convert.ToString(productView.Rows[ro].Cells[1].Value) == textBox5.Text)
                            {
                                if (Convert.ToString(productView.Rows[ro].Cells[2].Value) == "هدية")
                                    continue;
                                check = true;
                                productView.Rows[ro].Cells[4].Value = Convert.ToInt64(textBox6.Text);
                                productView.Rows[ro].Cells[5].Value = textBox3.Text;
                                productView.Rows[ro].Cells[7].Value = (Convert.ToDouble(textBox3.Text) * Convert.ToDouble(productView.Rows[ro].Cells[4].Value)).ToString();
                                break;
                            }
                        }
                    }
                    if (!check)
                    {
                        if(button4.Text=="لا")
                        productView.Rows.Add(
                            productView.Rows.Count + 1,
                            textBox5.Text,
                            listBox1.Text,
                            listBox2.Text,
                            textBox6.Text,
                            textBox3.Text,
                            textBox4.Text,
                            (Convert.ToDouble(textBox3.Text) * Convert.ToDouble(textBox6.Text)).ToString()
                        );
                        else
                            productView.Rows.Add(
                               productView.Rows.Count + 1,
                               textBox5.Text,
                               "هدية",
                               listBox1.Text + " " + listBox2.Text,
                               textBox6.Text,
                               "0",
                               textBox4.Text,
                               "0"
                            );

                    }
                }
                // print invoice
                proPrice = 0.0;
                for (var i = 0; i < productView.Rows.Count; i++)
                {
                    proPrice += Convert.ToDouble(productView.Rows[Convert.ToInt32(i)].Cells[7].Value.ToString());
                }

                var saveVal = Convert.ToDouble(saveTextBox.Text);
                var save = proPrice - saveVal;
                vat = Convert.ToDouble(Company.vat) / 100;
                vat *= save;
                textBox8.Text = save.ToString();
                save += vat;
                ///
                printer.vat = Convert.ToString(vat);
                printer.data = productView;
                printer.empName = textBox1.Text;
                printer.invType = "مبيعات";
                printer.invNum = currentInvoice;
                printer.price = Convert.ToString(save - vat + Convert.ToDouble(saveTextBox.Text) );
                printer.discount = saveTextBox.Text;
                printer.finalPrice = totalPriceTextBox.Text;
                printer.companyBranch = Company.branchName;
                printer.print();
                //
                listBox1.Text = "";
                listBox2.Text = "";
                textBox6.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox2.Text = "";
                textBox5.Text = "";
                updateOrInsert = false;
                button4.Text = "لا";
                button4.ForeColor = Color.Black;
                listBox2.Items.Clear();
                MessageBox.Show("تمت العملية بنجاح");
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.Black;
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.LightGray;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            right.ForeColor = Color.RosyBrown;
        }

        private void productView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8) {//update
                var row = productView.CurrentCell.RowIndex;

                textBox2.Text = row.ToString();
                updateOrInsert = true;
                listBox1.Text = productView.Rows[row].Cells[2].Value.ToString();
                listBox2.Text = productView.Rows[row].Cells[3].Value.ToString();
                textBox6.Text = productView.Rows[row].Cells[4].Value.ToString();
                textBox3.Text = productView.Rows[row].Cells[5].Value.ToString();
                textBox4.Text = productView.Rows[row].Cells[6].Value.ToString();
                textBox5.Text = productView.Rows[row].Cells[1].Value.ToString();
            } else if (e.ColumnIndex == 9) {//delete
                DialogResult dialogResult = MessageBox.Show("متأكد, سيتم حذف المنتج من الفاتورة بشكل نهائي", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    var row = productView.CurrentCell.RowIndex;
                    var proIndex = productView.Rows[row].Cells[1].Value;
                    var vat = Convert.ToDouble(Company.vat) / 100;
                    vat *= Convert.ToDouble(productView.Rows[row].Cells[7].Value);
                    var priceToDle=Convert.ToDouble(productView.Rows[row].Cells[7].Value) + vat;
                    var newInvPrice = Convert.ToDouble(totalPriceTextBox.Text) - priceToDle;

                    string cmdString = "delete Inv_Pro where invoice_id=@val1 and product_id=@val2 and proPrice=@val3";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", currentInvoice);
                        comm.Parameters.AddWithValue("@val2", proIndex);
                        comm.Parameters.AddWithValue("@val3", productView.Rows[row].Cells[5].Value);
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    //
                    var amount = 0;
                    cmdString = "select amount from products where id=@val1";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", productView.Rows[Convert.ToInt32(row)].Cells[1].Value.ToString());
                        conn.Open();
                        SqlDataReader reader1 = comm.ExecuteReader();
                        if (reader1.Read())
                            amount = Convert.ToInt32(reader1.GetValue(0).ToString());
                        conn.Close();
                    }
                    amount += Convert.ToInt32(productView.Rows[Convert.ToInt32(row)].Cells[4].Value.ToString());
                    cmdString = "update products set amount=@val2 where id=@val1";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", productView.Rows[Convert.ToInt32(row)].Cells[1].Value.ToString());
                        comm.Parameters.AddWithValue("@val2", amount);
                        conn.Open();
                        comm.ExecuteReader();
                        conn.Close();
                    }
                    //
                    cmdString = "update invoices set totalPrice=@val2 where id=@val1";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", currentInvoice);
                        comm.Parameters.AddWithValue("@val2", newInvPrice);
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    totalPriceTextBox.Text = newInvPrice.ToString();
                    cmdString = "update companies set box=@val2,visa=@val4,cash=@val5 where id=@val1";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        var newP = Company.box - priceToDle;

                        Company.box = newP;
                        if (label10.Text == "visa")
                            Company.visa -= priceToDle;
                        else
                            Company.cash -= Convert.ToDouble(productView.Rows[Convert.ToInt32(row)].Cells[7].Value.ToString());
                        comm.Parameters.AddWithValue("@val1", Company.id);
                        comm.Parameters.AddWithValue("@val2", newP);
                        comm.Parameters.AddWithValue("@val4", Company.visa);
                        comm.Parameters.AddWithValue("@val5", Company.cash);
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    var empBox = "0";
                    var cash = 0.0;
                    var visa = 0.0;
                    cmdString = "select box,cash,visa from employees where userName=@val1";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", textBox1.Text);
                        conn.Open();
                        SqlDataReader reader1 = comm.ExecuteReader();
                        if (reader1.Read())
                        {
                            empBox = reader1.GetValue(0).ToString();
                            cash = Convert.ToDouble(reader1.GetValue(1).ToString());
                            visa =Convert.ToDouble( reader1.GetValue(2).ToString());
                        }
                        conn.Close();
                    }
                    if (label10.Text == "visa")
                        visa -= priceToDle;
                    else
                        cash -= Convert.ToDouble(productView.Rows[Convert.ToInt32(row)].Cells[7].Value.ToString());
                    if (Employee.userNamee == textBox1.Text)
                    {
                        Employee.boxx -= priceToDle;
                        Employee.visa = visa;
                        Employee.cash = cash;
                    }
                    cmdString = "update employees set box=@val2,cash=@val3,visa=@val4 where userName=@val1";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        var newP = Convert.ToDouble(empBox) - priceToDle;
                        comm.Parameters.AddWithValue("@val1", textBox1.Text);
                        comm.Parameters.AddWithValue("@val2", newP);
                        comm.Parameters.AddWithValue("@val3",cash);
                        comm.Parameters.AddWithValue("@val4", visa);
                        conn.Open();
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    productView.Rows.RemoveAt(row);
                    // print invoice
                    var proPrice = 0.0;
                    for (var i = 0; i < productView.Rows.Count; i++)
                    {
                        proPrice += Convert.ToDouble(productView.Rows[Convert.ToInt32(i)].Cells[7].Value.ToString());
                    }

                    var saveVal = Convert.ToDouble(saveTextBox.Text);
                    var save = proPrice - saveVal;
                    vat = Convert.ToDouble(Company.vat) / 100;
                    vat *= save;
                    textBox8.Text = save.ToString();
                    save += vat;
                    ///
                    printer.vat = Convert.ToString(vat);
                    printer.data = productView;
                    printer.empName = textBox1.Text;
                    printer.invType = "مبيعات";
                    printer.invNum = currentInvoice;
                    printer.price = Convert.ToString(save - vat + Convert.ToDouble(saveTextBox.Text));
                    printer.discount = saveTextBox.Text;
                    printer.finalPrice = totalPriceTextBox.Text;
                    printer.companyBranch = Company.branchName;
                    printer.print();
                    //
                }
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox2.Text = "";
            string cmdString = "select name from products where class=@val1 and isDeleted=@val2";
            using (SqlCommand comm = new SqlCommand(cmdString, conn))
            {
                comm.Parameters.AddWithValue("@val1", listBox1.Text);
                comm.Parameters.AddWithValue("@val2", 0);
                conn.Open();
                SqlDataReader reader1 = comm.ExecuteReader();
                while (reader1.Read())
                    listBox2.Items.Add(reader1.GetValue(0).ToString());
                conn.Close();
            }
        }

        private void listBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            string cmdString = "select price,barcode,id from products where class=@val1 and name=@val2 and isDeleted=@val3";
            using (SqlCommand comm = new SqlCommand(cmdString, conn))
            {
                comm.Parameters.AddWithValue("@val1", listBox1.Text);
                comm.Parameters.AddWithValue("@val2", listBox2.Text);
                comm.Parameters.AddWithValue("@val3", 0);
                conn.Open();
                SqlDataReader reader1 = comm.ExecuteReader();
                while (reader1.Read())
                {
                    textBox3.Text = reader1.GetValue(0).ToString();
                    textBox4.Text = reader1.GetValue(1).ToString();
                    textBox5.Text = reader1.GetValue(2).ToString();
                    textBox6.Text = "0";
                }
                conn.Close();

                textBox6.Text = "1";
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

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("متأكد, سيتم تعديل الخصم من الفاتورة ", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var proPrice = 0.0;
                for (var i=0;i<productView.Rows.Count;i++ )
                {
                    proPrice += Convert.ToDouble(productView.Rows[Convert.ToInt32(i)].Cells[7].Value.ToString());
                }

                var oldPrice= (Convert.ToDouble(totalPriceTextBox.Text));
                var saveVal = Convert.ToDouble(saveTextBox.Text);
                var save = proPrice - saveVal;
                var oldSave =this.oldSave;
                var vat = Convert.ToDouble(Company.vat) / 100;
                vat *= save;
                textBox8.Text = save.ToString();
                save += vat;
                ////////////
                string cmdString = "update invoices set totalPrice=@val2,sav=@val3 where id=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", currentInvoice);
                    comm.Parameters.AddWithValue("@val2", save);
                    comm.Parameters.AddWithValue("@val3", saveTextBox.Text);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                }
                totalPriceTextBox.Text = save.ToString();
                cmdString = "update companies set box=@val2,visa=@val3,cash=@val4 where id=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    if (label10.Text == "visa")
                        Company.visa = (Company.visa - oldPrice) + save;
                    else
                        Company.cash = (Company.cash + Convert.ToDouble(oldSave)) - Convert.ToDouble(saveTextBox.Text);

                    var newP = (Company.box - oldPrice)+save;
                    Company.box = newP;
                    comm.Parameters.AddWithValue("@val1", Company.id);
                    comm.Parameters.AddWithValue("@val2", Company.box);
                    comm.Parameters.AddWithValue("@val3", Company.visa);
                    comm.Parameters.AddWithValue("@val4", Company.cash);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
               }
                var empBox = "0";
                var cash = 0.0;
                var visa = 0.0;
                cmdString = "select box,cash,visa from employees where userName=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", textBox1.Text);
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    if (reader1.Read())
                    {
                        empBox = reader1.GetValue(0).ToString();
                        cash = Convert.ToDouble(reader1.GetValue(1).ToString());
                        visa = Convert.ToDouble(reader1.GetValue(2).ToString());
                    }
                    conn.Close();
                }
                if (label10.Text == "visa")
                    visa = (visa - oldPrice) + save;
                else
                    cash =((cash+ Convert.ToDouble(oldSave))- Convert.ToDouble(saveTextBox.Text));
                if (Employee.userNamee == textBox1.Text)
                {
                    Employee.boxx = (Convert.ToDouble(empBox) - oldPrice) + save;
                    Employee.visa = visa;
                    Employee.cash = cash;
                }
                cmdString = "update employees set box=@val2,cash=@val3,visa=@val4 where userName=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    var newP = (Convert.ToDouble(empBox) - oldPrice) + save;
                    comm.Parameters.AddWithValue("@val1", textBox1.Text);
                    comm.Parameters.AddWithValue("@val2", newP);
                    comm.Parameters.AddWithValue("@val3", cash);
                    comm.Parameters.AddWithValue("@val4", visa);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                    this.savePrice = Convert.ToDouble(saveTextBox.Text);
                }
                // print invoice
                printer.vat = Convert.ToString(vat);
                printer.data = productView;
                printer.empName = textBox1.Text;
                printer.invType = "مبيعات";
                printer.invNum = currentInvoice;
                printer.price = Convert.ToString(Convert.ToDouble(totalPriceTextBox.Text) - vat + Convert.ToDouble(saveTextBox.Text));
                printer.discount = saveTextBox.Text;
                printer.finalPrice = totalPriceTextBox.Text;
                printer.companyBranch = Company.branchName;
                printer.print();
                //
            }
        }

        private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void saveTextBox_TextChanged(object sender, EventArgs e)
        {
            if (saveTextBox.Text == "")
            {
                button2.Enabled = false;
            }
            else
                button2.Enabled = true;
        }

        private void button3_MouseDown(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.Black;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Red;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Black;
        }

        private void button3_MouseUp(object sender, MouseEventArgs e)
        {
            button3.BackColor = Color.LightGray;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("         هل متأكد", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string cmdString = "update invoices set phoneNumber=@val2 where id=@val1";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", currentInvoice);
                    if (textBox7.Text == "")
                        comm.Parameters.AddWithValue("@val2", "0");
                    else
                        comm.Parameters.AddWithValue("@val2", textBox7.Text);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                    this.invoicies[invoiceIndex-1][4] = textBox7.Text;
                }
                MessageBox.Show("تم التعديل بنجاح");
            }
        }

        private void button4_MouseDown(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.Black;
        }

        private void button4_MouseUp(object sender, MouseEventArgs e)
        {
            button4.BackColor = Color.LightGray;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            if(button4.Text=="لا")
                 button4.ForeColor = Color.Black;
            else
                 button4.ForeColor = Color.Green;

        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.ForeColor = Color.Red;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "لا") { 
                button4.ForeColor = Color.Green;
                button4.Text = "نعم";
            }
            else
            {
                button4.ForeColor = Color.Black;
                button4.Text = "لا";
            }
        }
    }
}
