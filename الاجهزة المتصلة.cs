using System;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace fouater
{
    public partial class الاجهزة_المتصلة : Form
    {
        public static string bilPrinter="";
        public static string barcodePrinter="";
        private string connString = Company.databasePath;
        public الاجهزة_المتصلة()
        {
            InitializeComponent();

        }

        private void الاجهزة_المتصلة_Load(object sender, EventArgs e)
        {
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                comboBox1.Items.Add(strPrinter);
                comboBox2.Items.Add(strPrinter);
            }
            string cmdString = "select * from printers";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    conn.Open();
                    SqlDataReader reader1 = comm.ExecuteReader();
                    while (reader1.Read())
                    {
                        if (reader1.GetValue(2).ToString()=="bill")
                            comboBox2.Text= reader1.GetValue(1).ToString();
                        if (reader1.GetValue(2).ToString() == "barcode")
                            comboBox1.Text = reader1.GetValue(1).ToString();
                    }
                    conn.Close();
                }
            }
            bilPrinter = comboBox2.Text;
            barcodePrinter = comboBox1.Text;
            label8.Text = bilPrinter;
            label6.Text = barcodePrinter;
            label2.Text = "barcode reader";
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            barcodePrinter =comboBox1.Text;
            label6.Text = barcodePrinter;
            string cmdString = "update printers set name=@val2 where type=@val3";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val2", barcodePrinter);
                    comm.Parameters.AddWithValue("@val3", "barcode");
                    conn.Open();
                    comm.ExecuteReader();
                    conn.Close();
                }
            }

        }

        private void comboBox2_SelectedValueChanged(object sender, EventArgs e)
        {
            bilPrinter =comboBox2.Text;
            label8.Text = bilPrinter;
            string cmdString = "update printers set name=@val2 where type=@val3";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlCommand comm = new SqlCommand(cmdString, conn))
                {
                    comm.Parameters.AddWithValue("@val2", bilPrinter);
                    comm.Parameters.AddWithValue("@val3", "bill");
                    conn.Open();
                    comm.ExecuteReader();
                    conn.Close();
                }
            }
        }
    }
}
