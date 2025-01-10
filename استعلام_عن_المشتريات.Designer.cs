namespace fouater
{
    partial class استعلام_عن_المشتريات
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
            System.Windows.Forms.Label totalPriceLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label saveLabel;
            System.Windows.Forms.Label label2;
            this.delete = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            this.year = new System.Windows.Forms.ComboBox();
            this.month = new System.Windows.Forms.ComboBox();
            this.day = new System.Windows.Forms.ComboBox();
            this.totalPriceTextBox = new System.Windows.Forms.TextBox();
            this.totalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.right = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numbrt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.saveTextBox = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productView = new System.Windows.Forms.DataGridView();
            totalPriceLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            saveLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productView)).BeginInit();
            this.SuspendLayout();
            // 
            // totalPriceLabel
            // 
            totalPriceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            totalPriceLabel.AutoSize = true;
            totalPriceLabel.Font = new System.Drawing.Font("Tahoma", 20F);
            totalPriceLabel.Location = new System.Drawing.Point(1023, 608);
            totalPriceLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            totalPriceLabel.Name = "totalPriceLabel";
            totalPriceLabel.Size = new System.Drawing.Size(156, 33);
            totalPriceLabel.TabIndex = 87;
            totalPriceLabel.Text = "السعر الكلي";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 12F);
            label3.Location = new System.Drawing.Point(213, 66);
            label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(79, 19);
            label3.TabIndex = 83;
            label3.Text = "اسم الفرع";
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 12F);
            label1.Location = new System.Drawing.Point(1063, 25);
            label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(116, 19);
            label1.TabIndex = 81;
            label1.Text = "أسم المستخدم";
            // 
            // saveLabel
            // 
            saveLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            saveLabel.AutoSize = true;
            saveLabel.Font = new System.Drawing.Font("Tahoma", 12F);
            saveLabel.Location = new System.Drawing.Point(1090, 73);
            saveLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            saveLabel.Name = "saveLabel";
            saveLabel.Size = new System.Drawing.Size(89, 19);
            saveLabel.TabIndex = 79;
            saveLabel.Text = "قيمة الخصم";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 12F);
            label2.Location = new System.Drawing.Point(662, 29);
            label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(50, 19);
            label2.TabIndex = 78;
            label2.Text = "التاريخ";
            // 
            // delete
            // 
            this.delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.delete.BackColor = System.Drawing.Color.LightGray;
            this.delete.Enabled = false;
            this.delete.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.delete.ForeColor = System.Drawing.Color.DarkRed;
            this.delete.Location = new System.Drawing.Point(25, 595);
            this.delete.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(267, 65);
            this.delete.TabIndex = 96;
            this.delete.Text = "حذف";
            this.delete.UseVisualStyleBackColor = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            this.delete.MouseDown += new System.Windows.Forms.MouseEventHandler(this.delete_MouseDown);
            this.delete.MouseEnter += new System.EventHandler(this.delete_MouseEnter);
            this.delete.MouseLeave += new System.EventHandler(this.delete_MouseLeave);
            this.delete.MouseUp += new System.Windows.Forms.MouseEventHandler(this.delete_MouseUp);
            // 
            // left
            // 
            this.left.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.left.BackColor = System.Drawing.Color.LightGray;
            this.left.Enabled = false;
            this.left.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.left.ForeColor = System.Drawing.Color.OrangeRed;
            this.left.Location = new System.Drawing.Point(412, 83);
            this.left.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(55, 50);
            this.left.TabIndex = 94;
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
            this.search.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.search.BackColor = System.Drawing.Color.LightGray;
            this.search.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.search.ForeColor = System.Drawing.Color.OrangeRed;
            this.search.Location = new System.Drawing.Point(475, 83);
            this.search.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(161, 50);
            this.search.TabIndex = 93;
            this.search.Text = "بحث";
            this.search.UseVisualStyleBackColor = false;
            this.search.Click += new System.EventHandler(this.search_Click);
            this.search.MouseDown += new System.Windows.Forms.MouseEventHandler(this.search_MouseDown);
            this.search.MouseEnter += new System.EventHandler(this.search_MouseEnter);
            this.search.MouseLeave += new System.EventHandler(this.search_MouseLeave);
            this.search.MouseUp += new System.Windows.Forms.MouseEventHandler(this.search_MouseUp);
            // 
            // year
            // 
            this.year.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.year.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.year.Font = new System.Drawing.Font("Tahoma", 16F);
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
            "2033"});
            this.year.Location = new System.Drawing.Point(583, 21);
            this.year.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(69, 33);
            this.year.TabIndex = 92;
            this.year.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.year_KeyPress);
            // 
            // month
            // 
            this.month.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.month.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.month.Font = new System.Drawing.Font("Tahoma", 16F);
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
            this.month.Location = new System.Drawing.Point(500, 21);
            this.month.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(75, 33);
            this.month.TabIndex = 91;
            this.month.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.year_KeyPress);
            // 
            // day
            // 
            this.day.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.day.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.day.Font = new System.Drawing.Font("Tahoma", 16F);
            this.day.ForeColor = System.Drawing.Color.IndianRed;
            this.day.FormattingEnabled = true;
            this.day.Items.AddRange(new object[] {
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
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.day.Location = new System.Drawing.Point(418, 21);
            this.day.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(74, 33);
            this.day.TabIndex = 90;
            this.day.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.year_KeyPress);
            // 
            // totalPriceTextBox
            // 
            this.totalPriceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPriceTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.totalPriceTextBox.Font = new System.Drawing.Font("Tahoma", 20F);
            this.totalPriceTextBox.ForeColor = System.Drawing.Color.Green;
            this.totalPriceTextBox.Location = new System.Drawing.Point(749, 605);
            this.totalPriceTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.totalPriceTextBox.Name = "totalPriceTextBox";
            this.totalPriceTextBox.ReadOnly = true;
            this.totalPriceTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.totalPriceTextBox.Size = new System.Drawing.Size(251, 40);
            this.totalPriceTextBox.TabIndex = 88;
            this.totalPriceTextBox.Text = "0";
            this.totalPriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // totalPrice
            // 
            this.totalPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.totalPrice.DataPropertyName = "totalPrice";
            this.totalPrice.HeaderText = "السعر الاجمالي";
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.ReadOnly = true;
            this.totalPrice.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.totalPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.totalPrice.ToolTipText = "dd";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "barcode";
            this.dataGridViewTextBoxColumn6.HeaderText = "barcode";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "price";
            this.dataGridViewTextBoxColumn5.HeaderText = "السعر";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "amount";
            this.dataGridViewTextBoxColumn4.HeaderText = "الكمية";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn3.HeaderText = "اسم المنتج";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // right
            // 
            this.right.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.right.BackColor = System.Drawing.Color.LightGray;
            this.right.Enabled = false;
            this.right.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.right.ForeColor = System.Drawing.Color.OrangeRed;
            this.right.Location = new System.Drawing.Point(644, 83);
            this.right.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(56, 50);
            this.right.TabIndex = 95;
            this.right.Text = ">";
            this.right.UseVisualStyleBackColor = false;
            this.right.Click += new System.EventHandler(this.right_Click);
            this.right.MouseDown += new System.Windows.Forms.MouseEventHandler(this.right_MouseDown);
            this.right.MouseEnter += new System.EventHandler(this.right_MouseEnter);
            this.right.MouseLeave += new System.EventHandler(this.right_MouseLeave);
            this.right.MouseUp += new System.Windows.Forms.MouseEventHandler(this.right_MouseUp);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "class";
            this.dataGridViewTextBoxColumn2.HeaderText = "الصنف";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // numbrt
            // 
            this.numbrt.HeaderText = "رقم";
            this.numbrt.Name = "numbrt";
            this.numbrt.ReadOnly = true;
            this.numbrt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.numbrt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label13.ForeColor = System.Drawing.Color.IndianRed;
            this.label13.Location = new System.Drawing.Point(967, 114);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 19);
            this.label13.TabIndex = 86;
            this.label13.Text = "مشتريات";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label12.Location = new System.Drawing.Point(1097, 114);
            this.label12.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 19);
            this.label12.TabIndex = 85;
            this.label12.Text = "نوع الفاتورة";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.ForeColor = System.Drawing.Color.IndianRed;
            this.label4.Location = new System.Drawing.Point(14, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(189, 26);
            this.label4.TabIndex = 84;
            this.label4.Text = "سسس";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 20F);
            this.textBox1.ForeColor = System.Drawing.Color.IndianRed;
            this.textBox1.Location = new System.Drawing.Point(791, 11);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(245, 40);
            this.textBox1.TabIndex = 82;
            // 
            // saveTextBox
            // 
            this.saveTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.saveTextBox.Font = new System.Drawing.Font("Tahoma", 20F);
            this.saveTextBox.ForeColor = System.Drawing.Color.IndianRed;
            this.saveTextBox.Location = new System.Drawing.Point(791, 59);
            this.saveTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.saveTextBox.Name = "saveTextBox";
            this.saveTextBox.ReadOnly = true;
            this.saveTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.saveTextBox.Size = new System.Drawing.Size(245, 40);
            this.saveTextBox.TabIndex = 80;
            this.saveTextBox.Text = "0";
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id.HeaderText = "رقم المنتج";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // productView
            // 
            this.productView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.productView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.productView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numbrt,
            this.id,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.totalPrice});
            this.productView.Location = new System.Drawing.Point(0, 156);
            this.productView.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.productView.Name = "productView";
            this.productView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.productView.Size = new System.Drawing.Size(1205, 431);
            this.productView.TabIndex = 89;
            // 
            // استعلام_عن_المشتريات
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1203, 665);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.left);
            this.Controls.Add(this.search);
            this.Controls.Add(this.year);
            this.Controls.Add(this.month);
            this.Controls.Add(this.day);
            this.Controls.Add(this.totalPriceTextBox);
            this.Controls.Add(this.right);
            this.Controls.Add(totalPriceLabel);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.Controls.Add(label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(label1);
            this.Controls.Add(saveLabel);
            this.Controls.Add(this.saveTextBox);
            this.Controls.Add(label2);
            this.Controls.Add(this.productView);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "استعلام_عن_المشتريات";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فواتير | استعلام عن المشتريات";
            this.Load += new System.EventHandler(this.استعلام_عن_المشتريات_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.ComboBox year;
        private System.Windows.Forms.ComboBox month;
        private System.Windows.Forms.ComboBox day;
        private System.Windows.Forms.TextBox totalPriceTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn numbrt;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox saveTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridView productView;
    }
}