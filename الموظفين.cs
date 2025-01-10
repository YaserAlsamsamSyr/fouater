using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace fouater
{
    public partial class الموظفين : Form
    {
        private string connString;
        public الموظفين()
        {
            InitializeComponent();
        }

        private void الموظفين_Load(object sender, EventArgs e)
        {
            userView.DefaultCellStyle.Font = new Font("Tahoma", 10);
            userView.RowTemplate.Height = 50;
            connString = Company.databasePath;
            getAllUsers();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (nname.Text==""|| ppassword.Text ==""|| rrole.Text==""||authh.Text=="")
            {
                MessageBox.Show("قم بملئ جميع الحقول");
            }
            else {
                var check = false;
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    string cmdString = "select userName from employees where userName=@val1";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", nname.Text);
                        try
                        {
                            conn.Open(); 
                            SqlDataReader reader1 = comm.ExecuteReader();
                            if (reader1.Read())
                                 check=true;
                            conn.Close();
                        }
                        catch (SqlException err)
                        {
                            MessageBox.Show("يوجد خطأ");
                            MessageBox.Show(err.Message);
                        }
                    }
                    if (check)
                        MessageBox.Show("هذا الموظف موجود مسبقا");
                    else
                    {
                        cmdString = "INSERT INTO employees (userName,password,role,company_id,auth) VALUES (@val1, @val2, @val3,@val4,@val5)";
                        using (SqlCommand comm = new SqlCommand(cmdString, conn))
                        {
                            comm.Parameters.AddWithValue("@val1", nname.Text);
                            comm.Parameters.AddWithValue("@val2", ppassword.Text);
                            comm.Parameters.AddWithValue("@val3", rrole.Text);
                            comm.Parameters.AddWithValue("@val4", Company.id);
                            comm.Parameters.AddWithValue("@val5", authh.Text);
                            try
                            {
                                conn.Open();
                                comm.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show("تمت الاضافة بنجاح");
                                this.getAllUsers();

                            }
                            catch (SqlException err)
                            {
                                MessageBox.Show("يوجد خطأ");
                                MessageBox.Show(err.Message);
                            }
                        }
                    }
                }
            }
        }

        private void getAllUsers()
        {
            //'Hide the last blank line.
            userView.AllowUserToAddRows = false;
            userView.Rows.Clear();
            string cmdString = "select * from employees";
             using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    var count = 1;
                    while (reader1.Read())
                    {
                        userView.Rows.Add(
                         count.ToString(),
                         reader1.GetValue(0).ToString(),//id
                         reader1.GetValue(1).ToString(),//userName
                         reader1.GetValue(2).ToString()//password
                         //reader1.GetValue(3).ToString()//role
                        );
                        DataGridViewComboBoxCell comboBoxCell = (userView.Rows[count - 1].Cells["dataGridViewTextBoxColumn4"] as DataGridViewComboBoxCell);
                        //Insert the Default Item to ComboBoxCell.
                        comboBoxCell.Items.Add("مدير");
                        comboBoxCell.Items.Add("موظف");
                        //Set the Default Value as the Selected Value.
                        comboBoxCell.Value = reader1.GetValue(3).ToString();

                        DataGridViewComboBoxCell comboBoxCell2 = (userView.Rows[count - 1].Cells["auth"] as DataGridViewComboBoxCell);
                        //Insert the Default Item to ComboBoxCell.

                        comboBoxCell2.Items.Add("نعم");
                        comboBoxCell2.Items.Add("لا");
                        //Set the Default Value as the Selected Value.
                        comboBoxCell2.Value = reader1.GetValue(7).ToString();
                        count++;
                    }
                    conn.Close();
                }
            }
        }
        private void deleteEmp(string id)
        {
            string cmdString = "DELETE FROM employees WHERE id =" + id;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    conn.Open();
                    comm.ExecuteReader();
                    conn.Close();
                    MessageBox.Show("تمت عملية الحذف");
                }
            }
        }
        private void updateEmp(Employee emp)
        {
            var check = false;
            using (SqlConnection conn = new SqlConnection(connString))
            {

                string cmdString = "select userName from employees where userName=@val1 and id!=@val2";
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val1", emp.userName);
                    comm.Parameters.AddWithValue("@val2", emp.id);
                    try
                    {
                        conn.Open();
                        SqlDataReader reader1 = comm.ExecuteReader();
                        if (reader1.Read())
                            check = true;
                        conn.Close();
                    }
                    catch (SqlException err)
                    {
                        MessageBox.Show("يوجد خطأ");
                        MessageBox.Show(err.Message);
                    }
                }
                if (check) 
                    MessageBox.Show("هذا الموظف موجود مسبقا");
                else
                {
                    cmdString = "Update employees SET userName =@val1, password =@val2, role =@val3, auth=@val5 WHERE id =@val4;";
                    using (SqlCommand comm = new SqlCommand(cmdString, conn))
                    {
                        comm.Parameters.AddWithValue("@val1", emp.userName);
                        comm.Parameters.AddWithValue("@val2", emp.password);
                        comm.Parameters.AddWithValue("@val3", emp.role);
                        comm.Parameters.AddWithValue("@val4", emp.id);
                        comm.Parameters.AddWithValue("@val5", emp.auth);
                        conn.Open();
                        comm.ExecuteReader();
                        conn.Close();
                        MessageBox.Show("تمت عملية التعديل");
                        if (emp.id == Employee.idd)
                        {
                            Employee.userNamee = emp.userName;
                            Employee.passwordd = emp.password;
                            Employee.rolee = emp.role;
                            Employee.authh = emp.auth;
                        }
                    }
                }
            }
        }
        /// for view grade
        private void userView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6) { //update
                var emp=new Employee();
                var colIndex = 1;
                int row = userView.CurrentCellAddress.Y;
                emp.id=Convert.ToInt32( userView[colIndex, row].EditedFormattedValue.ToString());
                emp.userName = userView[colIndex + 1, row].EditedFormattedValue.ToString();
                emp.password = userView[colIndex + 2, row].EditedFormattedValue.ToString();
                emp.role = userView[colIndex + 3, row].EditedFormattedValue.ToString();
                emp.auth = userView[colIndex + 4, row].EditedFormattedValue.ToString();
                this.updateEmp(emp);
                this.getAllUsers();
            } else if (e.ColumnIndex == 7) { //delete
                DialogResult dialogResult = MessageBox.Show("متأكد, سيتم حذف الموظف بشكل نهائي", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    int row = userView.CurrentCellAddress.Y;
                    if (userView[4, row].EditedFormattedValue.ToString() == "مدير")
                    {
                        dialogResult = MessageBox.Show("هذا الموظف مدير هل متأكد من الحذف", "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            var empId = userView[1, row].EditedFormattedValue.ToString();
                            this.deleteEmp(empId);
                            this.getAllUsers();
                        }
                    }
                    else
                    {
                        var empId = userView[1, row].EditedFormattedValue.ToString();
                        this.deleteEmp(empId);
                        this.getAllUsers();
                    }
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
            button1.ForeColor = Color.Brown;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void rrole_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        ///
    }
}