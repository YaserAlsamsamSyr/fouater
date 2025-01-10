namespace fouater
{
    partial class ارقام_الزبائن
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label3;
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.ComboBox();
            this.month = new System.Windows.Forms.ComboBox();
            this.left = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.numm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phonNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 12F);
            label3.Location = new System.Drawing.Point(246, 101);
            label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(50, 19);
            label3.TabIndex = 108;
            label3.Text = "التاريخ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.phone});
            this.dataGridView1.Location = new System.Drawing.Point(1, 222);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.Size = new System.Drawing.Size(753, 350);
            this.dataGridView1.TabIndex = 0;
            // 
            // num
            // 
            this.num.HeaderText = "الرقم";
            this.num.Name = "num";
            this.num.ReadOnly = true;
            this.num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.num.Width = 90;
            // 
            // phone
            // 
            this.phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.phone.HeaderText = "رقم الهاتف";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            this.phone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(171, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "عدد الأرقام الكلي";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.ForeColor = System.Drawing.Color.Coral;
            this.label2.Location = new System.Drawing.Point(14, 48);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(147, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "0";
            // 
            // year
            // 
            this.year.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.year.Font = new System.Drawing.Font("Tahoma", 20F);
            this.year.ForeColor = System.Drawing.Color.IndianRed;
            this.year.FormattingEnabled = true;
            this.year.Items.AddRange(new object[] {
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035"});
            this.year.Location = new System.Drawing.Point(124, 87);
            this.year.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(100, 41);
            this.year.TabIndex = 111;
            this.year.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.year_KeyPress);
            // 
            // month
            // 
            this.month.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.month.Font = new System.Drawing.Font("Tahoma", 20F);
            this.month.ForeColor = System.Drawing.Color.IndianRed;
            this.month.FormattingEnabled = true;
            this.month.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.month.Location = new System.Drawing.Point(39, 87);
            this.month.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(75, 41);
            this.month.TabIndex = 110;
            this.month.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.year_KeyPress);
            // 
            // left
            // 
            this.left.BackColor = System.Drawing.Color.LightGray;
            this.left.Enabled = false;
            this.left.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.left.ForeColor = System.Drawing.Color.OrangeRed;
            this.left.Location = new System.Drawing.Point(14, 139);
            this.left.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(73, 68);
            this.left.TabIndex = 113;
            this.left.Text = "<";
            this.left.UseVisualStyleBackColor = false;
            this.left.Click += new System.EventHandler(this.left_Click);
            this.left.MouseDown += new System.Windows.Forms.MouseEventHandler(this.left_MouseDown);
            this.left.MouseEnter += new System.EventHandler(this.left_MouseEnter);
            this.left.MouseLeave += new System.EventHandler(this.left_MouseLeave);
            this.left.MouseUp += new System.Windows.Forms.MouseEventHandler(this.left_MouseUp);
            // 
            // search
            // 
            this.search.BackColor = System.Drawing.Color.LightGray;
            this.search.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.search.ForeColor = System.Drawing.Color.OrangeRed;
            this.search.Location = new System.Drawing.Point(97, 139);
            this.search.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(127, 68);
            this.search.TabIndex = 112;
            this.search.Text = "بحث";
            this.search.UseVisualStyleBackColor = false;
            this.search.Click += new System.EventHandler(this.search_Click);
            this.search.MouseDown += new System.Windows.Forms.MouseEventHandler(this.search_MouseDown);
            this.search.MouseEnter += new System.EventHandler(this.search_MouseEnter);
            this.search.MouseLeave += new System.EventHandler(this.search_MouseLeave);
            this.search.MouseUp += new System.Windows.Forms.MouseEventHandler(this.search_MouseUp);
            // 
            // right
            // 
            this.right.BackColor = System.Drawing.Color.LightGray;
            this.right.Enabled = false;
            this.right.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.right.ForeColor = System.Drawing.Color.OrangeRed;
            this.right.Location = new System.Drawing.Point(234, 139);
            this.right.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(82, 68);
            this.right.TabIndex = 114;
            this.right.Text = ">";
            this.right.UseVisualStyleBackColor = false;
            this.right.Click += new System.EventHandler(this.right_Click);
            this.right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.right_MouseDown);
            this.right.MouseEnter += new System.EventHandler(this.right_MouseEnter);
            this.right.MouseLeave += new System.EventHandler(this.right_MouseLeave);
            this.right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.right_MouseUp);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numm,
            this.emp,
            this.phonNum});
            this.dataGridView2.Location = new System.Drawing.Point(324, 12);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView2.Size = new System.Drawing.Size(430, 204);
            this.dataGridView2.TabIndex = 115;
            // 
            // numm
            // 
            this.numm.HeaderText = "رقم";
            this.numm.Name = "numm";
            this.numm.ReadOnly = true;
            this.numm.Width = 30;
            // 
            // emp
            // 
            this.emp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.emp.HeaderText = "الموظف";
            this.emp.Name = "emp";
            this.emp.ReadOnly = true;
            // 
            // phonNum
            // 
            this.phonNum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.phonNum.HeaderText = "عدد الارقام";
            this.phonNum.Name = "phonNum";
            this.phonNum.ReadOnly = true;
            // 
            // ارقام_الزبائن
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(755, 576);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.left);
            this.Controls.Add(this.search);
            this.Controls.Add(this.right);
            this.Controls.Add(this.year);
            this.Controls.Add(this.month);
            this.Controls.Add(label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.Name = "ارقام_الزبائن";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فواتير | أرقام الزبائن";
            this.Load += new System.EventHandler(this.ارقام_الزبائن_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox year;
        private System.Windows.Forms.ComboBox month;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn numm;
        private System.Windows.Forms.DataGridViewTextBoxColumn emp;
        private System.Windows.Forms.DataGridViewTextBoxColumn phonNum;
    }
}