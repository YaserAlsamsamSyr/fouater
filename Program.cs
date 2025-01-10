using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fouater
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try { 
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
                Company.databasePath = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Yaser\\Desktop\\فواتير\\fouater\\fouater\\fouater.mdf;Integrated Security=True";
                Application.Run(new تسجيل_الدخول());
            }
            catch (Exception ex)
            {
                MessageBox.Show("حدث خطأ في التطبيق");
                MessageBox.Show(ex.Message);
            }
        }
    }
}
