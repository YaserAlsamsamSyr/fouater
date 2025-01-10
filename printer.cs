using System;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;
using ZXing;
using System.Reflection;
using System.IO;
using System.Security.Policy;

namespace fouater
{
    internal class printer
    {
        public static DataGridView data;
        public static String invNum;
        public static String empName;
        public static String price;
        public static String discount;
        public static String vat;
        public static String finalPrice;
        public static String invType;
        public static String companyBranch;
        public static String lastDate;
        public static String number;
        public static void print()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = الاجهزة_المتصلة.bilPrinter;
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public static void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            System.Drawing.Font headingFont = new System.Drawing.Font("Calibri", 13, System.Drawing.FontStyle.Bold);
            System.Drawing.Font boldFont = new System.Drawing.Font("Calibri", 11, System.Drawing.FontStyle.Bold);
            System.Drawing.Font normalFont = new System.Drawing.Font("Calibri", 11, System.Drawing.FontStyle.Regular);
            //Create DataTable for Sales Details
            DataTable dt = new DataTable();
            dt.Columns.Add("Product");
            dt.Columns.Add("Price");
            dt.Columns.Add("Qty");
            dt.Columns.Add("Total");
            //Add Sales Details into DataTable
            DataRow dr = dt.NewRow();
            for(int i = 0; i < data.Rows.Count; i++)
            {
                dr[0] =data.Rows[i].Cells[2].Value+" "+data.Rows[i].Cells[3].Value;
                dr[1] = data.Rows[i].Cells[4].Value;
                dr[2] = data.Rows[i].Cells[5].Value;
                dr[3] = data.Rows[i].Cells[7].Value;
                dt.Rows.Add(dr);
                if(i+1 < data.Rows.Count)
                    dr = dt.NewRow();
            }
            //
            string receipt_no = invNum;
            string line = "------------------------------------------------------------------";
            float height = 30;
            int startX = 90;
            int startY = 0;
            // Load the logo image
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var s = outPutDirectory.Split('\\');
            var url = "";
            for (int i = 1; i < s.Length; i++)
            {
                url += s[i] + "\\";
            }
            var iconPath = Path.Combine(url, "aawtar.jpg");
            //var iconPath = "|DataDirectory|\\aawtar.jpg";
            Image logo = Image.FromFile(iconPath);
            Bitmap imgbitmap = new Bitmap(logo);
            Image newLogo = resizeImage(imgbitmap, new Size(100, 100));
            ev.Graphics.DrawImage(newLogo, new Point(startX, startY));
            height += 80;
            //Print Company Name
            ev.Graphics.DrawString("أوتار السلطنة", headingFont, Brushes.Black, 95, height, new StringFormat());
            height += 30;
            //Print Company Address
            ev.Graphics.DrawString("شمس الخليج البرونذية-س.ت:1351953", normalFont, Brushes.Black, 30, height, new StringFormat());
            height += 20;
            ev.Graphics.DrawString("              VAT NO. الرقم الضريبي", normalFont, Brushes.Black, 30, height, new StringFormat());
            height += 20;
            ev.Graphics.DrawString("                OM1100267881", normalFont, Brushes.Black, 30, height, new StringFormat());
            height += 30;
            //Print Line
            ev.Graphics.DrawString(line, normalFont, Brushes.Black, 5, height, new StringFormat());
            height += 20;
            //Print Receipt No
            ev.Graphics.DrawString(empName, headingFont, Brushes.Black, 5, height, new StringFormat());
            ev.Graphics.DrawString(receipt_no, boldFont, Brushes.Black, 140, height, new StringFormat());
            height += 20;
            ev.Graphics.DrawString(line, normalFont, Brushes.Black, 5, height, new StringFormat());
            height += 20;
            ev.Graphics.DrawString(DateTime.Now.ToString(), boldFont, Brushes.Black, 70, height, new StringFormat());
            height += 20;
            ev.Graphics.DrawString(line, normalFont, Brushes.Black, 5, height, new StringFormat());
            height += 20;
            //Printe Table Headings
            ev.Graphics.DrawString("Description", headingFont, Brushes.Black, 5, height, new StringFormat());
            ev.Graphics.DrawString("Qty", headingFont, Brushes.Black, 100, height, new StringFormat());
            ev.Graphics.DrawString("Price", headingFont, Brushes.Black, 150, height, new StringFormat());
            ev.Graphics.DrawString("Total", headingFont, Brushes.Black, 220, height, new StringFormat());
            height += 20;
            ev.Graphics.DrawString("الوصف", headingFont, Brushes.Black, 5, height, new StringFormat());
            ev.Graphics.DrawString("العدد", headingFont, Brushes.Black, 100, height, new StringFormat());
            ev.Graphics.DrawString("السعر", headingFont, Brushes.Black, 150, height, new StringFormat());
            ev.Graphics.DrawString("السعر لكلي", headingFont, Brushes.Black, 220, height, new StringFormat());
            height += 20;
            //Print Line
            ev.Graphics.DrawString(line, normalFont, Brushes.Black, 5, height, new StringFormat());
            height += 20;
            //Printe Table Rows
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SizeF qtyWidth = ev.Graphics.MeasureString(dt.Rows[i][1].ToString(), normalFont);
                SizeF priceWidth = ev.Graphics.MeasureString(dt.Rows[i][2].ToString(), normalFont);
                SizeF totalWidth = ev.Graphics.MeasureString(dt.Rows[i][3].ToString(), normalFont);
                ev.Graphics.DrawString(dt.Rows[i][0].ToString(), normalFont, Brushes.Black, 5, height, new StringFormat());
                ev.Graphics.DrawString(dt.Rows[i][1].ToString(), normalFont, Brushes.Black, 100, height, new StringFormat());
                ev.Graphics.DrawString(dt.Rows[i][2].ToString(), normalFont, Brushes.Black, 150, height, new StringFormat());
                ev.Graphics.DrawString(dt.Rows[i][3].ToString(), normalFont, Brushes.Black, 220, height, new StringFormat());
                height += 30;
            }
            //Print Line
            ev.Graphics.DrawString(line, normalFont, Brushes.Black, 10, height, new StringFormat());
            height += 20;
            //Print pric Total
            ev.Graphics.DrawString("Total :", normalFont, Brushes.Black, 5, height, new StringFormat());
            ev.Graphics.DrawString(": الاجمالي", normalFont, Brushes.Black, 220, height, new StringFormat());

            ev.Graphics.DrawString(price, normalFont, Brushes.Black, 110, height, new StringFormat());
            height += 20;
            //print discount
            ev.Graphics.DrawString("Discount :", normalFont, Brushes.Black, 5, height, new StringFormat());
            ev.Graphics.DrawString(": الخصم", normalFont, Brushes.Black, 220, height, new StringFormat());

            ev.Graphics.DrawString(discount, normalFont, Brushes.Black, 110, height, new StringFormat());
            height += 20;
            //print vat
            ev.Graphics.DrawString("Vat :", normalFont, Brushes.Black, 5, height, new StringFormat());
            ev.Graphics.DrawString(": الضريبة", normalFont, Brushes.Black, 220, height, new StringFormat());

            ev.Graphics.DrawString(vat, normalFont, Brushes.Black, 110, height, new StringFormat());
            height += 20;
            //print final price
            ev.Graphics.DrawString("Final Price :", normalFont, Brushes.Black, 5, height, new StringFormat());
            ev.Graphics.DrawString(": السعر النهائي", normalFont, Brushes.Black, 220, height, new StringFormat());
            
            ev.Graphics.DrawString(finalPrice, normalFont, Brushes.Black, 110, height, new StringFormat());
            height += 20;
            //Print Line
            ev.Graphics.DrawString(line, normalFont, Brushes.Black, 10, height, new StringFormat());
            height += 20;
            startX = 90;
            startY = Convert.ToInt32(height);
            // Load the logo image

            outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            s = outPutDirectory.Split('\\');
            url = "";
            for (int i = 1; i < s.Length; i++)
            {
                url += s[i] + "\\";
            }
            iconPath = Path.Combine(url, "b.png");
            //iconPath = "|DataDirectory|\\b.png";
            logo = Image.FromFile(iconPath);
            imgbitmap = new Bitmap(logo);
            newLogo = resizeImage(imgbitmap, new Size(100, 100));
            ev.Graphics.DrawImage(newLogo, new Point(startX, startY));
            height += 120;
            ev.Graphics.DrawString(companyBranch+" - هاتف : 95310290", normalFont, Brushes.Black, 50, height, new StringFormat());
            height += 20;
            ev.Graphics.DrawString(invType + " | ", normalFont, Brushes.Black, 5, height, new StringFormat());
            ev.HasMorePages = false;
        }
        public static void printReset()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                //PrinterSettings ps = new PrinterSettings();
                pd.PrinterSettings.PrinterName = الاجهزة_المتصلة.bilPrinter;
                pd.PrintPage += new PrintPageEventHandler(printReset);

                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void printReset(object sender, PrintPageEventArgs ev)
        {
            System.Drawing.Font headingFont = new System.Drawing.Font("Calibri", 13, System.Drawing.FontStyle.Bold);
            System.Drawing.Font boldFont = new System.Drawing.Font("Calibri", 11, System.Drawing.FontStyle.Bold);
            System.Drawing.Font normalFont = new System.Drawing.Font("Calibri", 11, System.Drawing.FontStyle.Regular);
         
            string line = "------------------------------------------------------------------";
            float height = 30;
            int startX = 90;
            int startY = 0;
            // Load the logo image
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            var s = outPutDirectory.Split('\\');
            var url = "";
            for (int i = 1; i < s.Length; i++)
            {
                url += s[i] + "\\";
            }
            var iconPath = Path.Combine(url, "aawtar.jpg");
            //var iconPath = "|DataDirectory|\\aawtar.jpg";
            Image logo = Image.FromFile(iconPath); 
            Bitmap imgbitmap = new Bitmap(logo);
            Image newLogo = resizeImage(imgbitmap, new Size(100, 100));
            ev.Graphics.DrawImage(newLogo, new Point(startX, startY));
            height += 80;
            //Print Company Name
            ev.Graphics.DrawString("أوتار السلطنة", headingFont, Brushes.Black, 95, height, new StringFormat());
            height += 30;
           
            //Print Line
            ev.Graphics.DrawString(line, normalFont, Brushes.Black, 5, height, new StringFormat());
            height += 20;
           
            ev.Graphics.DrawString(DateTime.Now.ToString(), boldFont, Brushes.Black, 70, height, new StringFormat());
            height += 20;
            ev.Graphics.DrawString(line, normalFont, Brushes.Black, 5, height, new StringFormat());
            height += 20;
           

            ev.Graphics.DrawString(": اسم الفرع", normalFont, Brushes.Black, 220, height, new StringFormat());

            ev.Graphics.DrawString(companyBranch, normalFont, Brushes.Black, 110, height, new StringFormat());
            height += 20;

            ev.Graphics.DrawString(": الموظف", normalFont, Brushes.Black, 220, height, new StringFormat());

            ev.Graphics.DrawString(empName, normalFont, Brushes.Black, 110, height, new StringFormat());
            height += 20;
            ev.Graphics.DrawString(": نوع الموظف", normalFont, Brushes.Black, 205, height, new StringFormat());

            ev.Graphics.DrawString(Employee.rolee, normalFont, Brushes.Black, 110, height, new StringFormat());
            height += 10; 
            ev.Graphics.DrawString(line, normalFont, Brushes.Black, 10, height, new StringFormat());
            height += 20;

            //print vat
            //print final price
            ev.Graphics.DrawString(": قيمة الكاش", normalFont, Brushes.Black, 215, height, new StringFormat());

            ev.Graphics.DrawString(Convert.ToString(Employee.cash), normalFont, Brushes.Black, 110, height, new StringFormat());

            height += 30; 
            ev.Graphics.DrawString(": قيمة الفيزا", normalFont, Brushes.Black, 215, height, new StringFormat());

            ev.Graphics.DrawString(Convert.ToString(Employee.visa), normalFont, Brushes.Black, 110, height, new StringFormat());

            height += 30;
            ev.Graphics.DrawString(": المبلغ الكلي مع الضريبة", normalFont, Brushes.Black, 160, height, new StringFormat());

            ev.Graphics.DrawString(finalPrice, normalFont, Brushes.Black, 70, height, new StringFormat());
            height += 20;
            //Print Line
            ev.Graphics.DrawString(line, normalFont, Brushes.Black, 10, height, new StringFormat());
            height += 20;
            ev.Graphics.DrawString(": نسبة", normalFont, Brushes.Black, 220, height, new StringFormat());
            height += 40;
            ev.Graphics.DrawString(line, normalFont, Brushes.Black, 10, height, new StringFormat());
            height += 10;
            ev.Graphics.DrawString(line, normalFont, Brushes.Black, 10, height, new StringFormat());
            height += 20;
            ev.Graphics.DrawString(": تاريخ اخر تفريغ للصندوق", normalFont, Brushes.Black, 145, height, new StringFormat());

            ev.Graphics.DrawString(lastDate, normalFont, Brushes.Black, 5, height, new StringFormat());

            ev.HasMorePages = false;
        }

        public static void openCasher()
        {
            try
            {
                PrintDocument pd = new PrintDocument();
                //PrinterSettings ps = new PrinterSettings();
                pd.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void printBarcode()
        {
            try
            {
                using (PrintDocument pd = new PrintDocument())
                {
                    pd.PrinterSettings.PrinterName = الاجهزة_المتصلة.barcodePrinter;
                    pd.PrintPage += new PrintPageEventHandler(printBarcode);
                    pd.PrinterSettings.Copies = Convert.ToInt16(number);
                    pd.Print();   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static void printBarcode(object sender, PrintPageEventArgs ev)
        {

            System.Drawing.Font normalFont = new System.Drawing.Font("Calibri", 11, System.Drawing.FontStyle.Regular);
            System.Drawing.Font header = new System.Drawing.Font("Calibri", 10, System.Drawing.FontStyle.Regular);
            float height = 1;
                int startX = 77;
                int startY = 35;
                var barcodeWriter = new BarcodeWriter
                {
                    Format = BarcodeFormat.CODE_128,
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Width = 130,
                        Height = 40
                    }
                };
                using (Bitmap bitmap = barcodeWriter.Write(باركود.barcode.ToString()))
                {
                ev.Graphics.DrawImage((Image)bitmap, new Point(startX, startY));
                }
                ev.Graphics.DrawString("أوتار السلطنة", header, Brushes.Black, 110, height, new StringFormat());
                height = 15;
                ev.Graphics.DrawString(باركود.name, header, Brushes.Black, 110, height, new StringFormat());
                height += 61;
                ev.Graphics.DrawString(باركود.price + " ر يال", normalFont, Brushes.Black, 120, height, new StringFormat());
                ev.HasMorePages = false;

        }
    }
}
