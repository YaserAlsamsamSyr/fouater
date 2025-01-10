namespace fouater
{
    partial class المشتريات
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label saveLabel;
            System.Windows.Forms.Label totalPriceLabel;
            this.productsTableAdapter = new fouater.modelDataSetTableAdapters.productsTableAdapter();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.productsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.modelDataSet = new fouater.modelDataSet();
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.yearTextBox = new System.Windows.Forms.TextBox();
            this.monthTextBox = new System.Windows.Forms.TextBox();
            this.dayTextBox = new System.Windows.Forms.TextBox();
            this.saveTextBox = new System.Windows.Forms.TextBox();
            this.listBox2 = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.productView = new System.Windows.Forms.DataGridView();
            this.numbrt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.totalPriceTextBox = new System.Windows.Forms.TextBox();
            this.save = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            saveLabel = new System.Windows.Forms.Label();
            totalPriceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productView)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 12F);
            label3.Location = new System.Drawing.Point(486, 42);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(79, 19);
            label3.TabIndex = 73;
            label3.Text = "اسم الفرع";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 12F);
            label2.Location = new System.Drawing.Point(745, 27);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(50, 19);
            label2.TabIndex = 71;
            label2.Text = "التاريخ";
            // 
            // label1
            // 
            label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 12F);
            label1.Location = new System.Drawing.Point(1066, 26);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(116, 19);
            label1.TabIndex = 70;
            label1.Text = "أسم المستخدم";
            // 
            // saveLabel
            // 
            saveLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            saveLabel.AutoSize = true;
            saveLabel.Font = new System.Drawing.Font("Tahoma", 12F);
            saveLabel.Location = new System.Drawing.Point(1093, 74);
            saveLabel.Name = "saveLabel";
            saveLabel.Size = new System.Drawing.Size(89, 19);
            saveLabel.TabIndex = 68;
            saveLabel.Text = "قيمة الخصم";
            // 
            // totalPriceLabel
            // 
            totalPriceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            totalPriceLabel.AutoSize = true;
            totalPriceLabel.Font = new System.Drawing.Font("Tahoma", 20F);
            totalPriceLabel.Location = new System.Drawing.Point(1035, 635);
            totalPriceLabel.Name = "totalPriceLabel";
            totalPriceLabel.Size = new System.Drawing.Size(156, 33);
            totalPriceLabel.TabIndex = 101;
            totalPriceLabel.Text = "السعر الكلي";
            // 
            // productsTableAdapter
            // 
            this.productsTableAdapter.ClearBeforeFill = true;
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label13.ForeColor = System.Drawing.Color.IndianRed;
            this.label13.Location = new System.Drawing.Point(408, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 19);
            this.label13.TabIndex = 100;
            this.label13.Text = "مشتريات";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label12.Location = new System.Drawing.Point(483, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 19);
            this.label12.TabIndex = 99;
            this.label12.Text = "نوع الفاتورة";
            // 
            // productsBindingSource1
            // 
            this.productsBindingSource1.DataMember = "products";
            this.productsBindingSource1.DataSource = this.modelDataSet;
            // 
            // modelDataSet
            // 
            this.modelDataSet.DataSetName = "modelDataSet";
            this.modelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataMember = "products";
            this.productsBindingSource.DataSource = this.modelDataSet;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.ForeColor = System.Drawing.Color.IndianRed;
            this.label4.Location = new System.Drawing.Point(310, 42);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(170, 32);
            this.label4.TabIndex = 77;
            this.label4.Text = "رررررررر";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 20F);
            this.textBox1.ForeColor = System.Drawing.Color.IndianRed;
            this.textBox1.Location = new System.Drawing.Point(910, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox1.Size = new System.Drawing.Size(150, 40);
            this.textBox1.TabIndex = 72;
            // 
            // yearTextBox
            // 
            this.yearTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.yearTextBox.Font = new System.Drawing.Font("Tahoma", 20F);
            this.yearTextBox.ForeColor = System.Drawing.Color.IndianRed;
            this.yearTextBox.Location = new System.Drawing.Point(672, 10);
            this.yearTextBox.Name = "yearTextBox";
            this.yearTextBox.ReadOnly = true;
            this.yearTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.yearTextBox.Size = new System.Drawing.Size(67, 40);
            this.yearTextBox.TabIndex = 65;
            this.yearTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.yearTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.saveTextBox_KeyPress);
            // 
            // monthTextBox
            // 
            this.monthTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.monthTextBox.Font = new System.Drawing.Font("Tahoma", 20F);
            this.monthTextBox.ForeColor = System.Drawing.Color.IndianRed;
            this.monthTextBox.Location = new System.Drawing.Point(625, 10);
            this.monthTextBox.Name = "monthTextBox";
            this.monthTextBox.ReadOnly = true;
            this.monthTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.monthTextBox.Size = new System.Drawing.Size(41, 40);
            this.monthTextBox.TabIndex = 66;
            this.monthTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.monthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.saveTextBox_KeyPress);
            // 
            // dayTextBox
            // 
            this.dayTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dayTextBox.Font = new System.Drawing.Font("Tahoma", 20F);
            this.dayTextBox.ForeColor = System.Drawing.Color.IndianRed;
            this.dayTextBox.Location = new System.Drawing.Point(574, 10);
            this.dayTextBox.Name = "dayTextBox";
            this.dayTextBox.ReadOnly = true;
            this.dayTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dayTextBox.Size = new System.Drawing.Size(45, 40);
            this.dayTextBox.TabIndex = 67;
            this.dayTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dayTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.saveTextBox_KeyPress);
            // 
            // saveTextBox
            // 
            this.saveTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveTextBox.Font = new System.Drawing.Font("Tahoma", 20F);
            this.saveTextBox.ForeColor = System.Drawing.Color.IndianRed;
            this.saveTextBox.Location = new System.Drawing.Point(910, 60);
            this.saveTextBox.Name = "saveTextBox";
            this.saveTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.saveTextBox.Size = new System.Drawing.Size(150, 40);
            this.saveTextBox.TabIndex = 69;
            this.saveTextBox.Text = "0";
            this.saveTextBox.TextChanged += new System.EventHandler(this.saveTextBox_TextChanged);
            this.saveTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.saveTextBox_KeyPress);
            // 
            // listBox2
            // 
            this.listBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.listBox2.Font = new System.Drawing.Font("Tahoma", 20F);
            this.listBox2.ForeColor = System.Drawing.Color.IndianRed;
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(536, 113);
            this.listBox2.Name = "listBox2";
            this.listBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox2.Size = new System.Drawing.Size(230, 41);
            this.listBox2.TabIndex = 116;
            this.listBox2.SelectedValueChanged += new System.EventHandler(this.listBox2_SelectedValueChanged);
            this.listBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBox1_KeyPress);
            // 
            // listBox1
            // 
            this.listBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.listBox1.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.productsBindingSource, "class", true));
            this.listBox1.Font = new System.Drawing.Font("Tahoma", 20F);
            this.listBox1.ForeColor = System.Drawing.Color.IndianRed;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(772, 113);
            this.listBox1.Name = "listBox1";
            this.listBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listBox1.Size = new System.Drawing.Size(216, 41);
            this.listBox1.TabIndex = 115;
            this.listBox1.SelectedValueChanged += new System.EventHandler(this.listBox1_SelectedValueChanged);
            this.listBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.listBox1_KeyPress);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(57, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 51);
            this.button1.TabIndex = 114;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label11.Location = new System.Drawing.Point(478, 81);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 19);
            this.label11.TabIndex = 113;
            this.label11.Text = "الكمية";
            // 
            // textBox6
            // 
            this.textBox6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox6.Font = new System.Drawing.Font("Tahoma", 20F);
            this.textBox6.ForeColor = System.Drawing.Color.IndianRed;
            this.textBox6.Location = new System.Drawing.Point(458, 114);
            this.textBox6.Name = "textBox6";
            this.textBox6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox6.Size = new System.Drawing.Size(72, 40);
            this.textBox6.TabIndex = 112;
            this.textBox6.Text = "0";
            this.textBox6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label9.Location = new System.Drawing.Point(317, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 19);
            this.label9.TabIndex = 111;
            this.label9.Text = "باركود";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label8.Location = new System.Drawing.Point(402, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 19);
            this.label8.TabIndex = 110;
            this.label8.Text = "السعر";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label7.Location = new System.Drawing.Point(621, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 19);
            this.label7.TabIndex = 109;
            this.label7.Text = "اسم المنتج";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label6.Location = new System.Drawing.Point(824, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 19);
            this.label6.TabIndex = 108;
            this.label6.Text = "الصنف";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label5.Location = new System.Drawing.Point(1102, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 19);
            this.label5.TabIndex = 107;
            this.label5.Text = "رقم المنتج";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox4.Font = new System.Drawing.Font("Tahoma", 20F);
            this.textBox4.ForeColor = System.Drawing.Color.IndianRed;
            this.textBox4.Location = new System.Drawing.Point(150, 114);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox4.Size = new System.Drawing.Size(213, 40);
            this.textBox4.TabIndex = 106;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox3.Font = new System.Drawing.Font("Tahoma", 20F);
            this.textBox3.ForeColor = System.Drawing.Color.IndianRed;
            this.textBox3.Location = new System.Drawing.Point(369, 114);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox3.Size = new System.Drawing.Size(83, 40);
            this.textBox3.TabIndex = 105;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 20F);
            this.textBox2.ForeColor = System.Drawing.Color.IndianRed;
            this.textBox2.Location = new System.Drawing.Point(993, 114);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textBox2.Size = new System.Drawing.Size(93, 40);
            this.textBox2.TabIndex = 104;
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
            this.totalPrice,
            this.remove});
            this.productView.Location = new System.Drawing.Point(-1, 159);
            this.productView.Name = "productView";
            this.productView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.productView.Size = new System.Drawing.Size(1205, 446);
            this.productView.TabIndex = 103;
            this.productView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.productView_CellClick);
            // 
            // numbrt
            // 
            this.numbrt.HeaderText = "رقم";
            this.numbrt.Name = "numbrt";
            this.numbrt.ReadOnly = true;
            this.numbrt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.numbrt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id.HeaderText = "رقم المنتج";
            this.id.Name = "id";
            this.id.ReadOnly = true;
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
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "amount";
            this.dataGridViewTextBoxColumn4.HeaderText = "الكمية";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "barcode";
            this.dataGridViewTextBoxColumn6.HeaderText = "barcode";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            // remove
            // 
            this.remove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.remove.HeaderText = "ازالة";
            this.remove.Name = "remove";
            // 
            // totalPriceTextBox
            // 
            this.totalPriceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.totalPriceTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.totalPriceTextBox.Font = new System.Drawing.Font("Tahoma", 20F);
            this.totalPriceTextBox.ForeColor = System.Drawing.Color.Green;
            this.totalPriceTextBox.Location = new System.Drawing.Point(808, 635);
            this.totalPriceTextBox.Name = "totalPriceTextBox";
            this.totalPriceTextBox.ReadOnly = true;
            this.totalPriceTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.totalPriceTextBox.Size = new System.Drawing.Size(209, 40);
            this.totalPriceTextBox.TabIndex = 102;
            this.totalPriceTextBox.Text = "0";
            this.totalPriceTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // save
            // 
            this.save.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.save.ForeColor = System.Drawing.Color.ForestGreen;
            this.save.Location = new System.Drawing.Point(12, 12);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(141, 67);
            this.save.TabIndex = 117;
            this.save.Text = "حفظ";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            this.save.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button2_MouseDown);
            this.save.MouseEnter += new System.EventHandler(this.button2_MouseEnter);
            this.save.MouseLeave += new System.EventHandler(this.button2_MouseLeave);
            this.save.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button2_MouseUp);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.SaddleBrown;
            this.button3.Location = new System.Drawing.Point(159, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(145, 67);
            this.button3.TabIndex = 118;
            this.button3.Text = "استعلام";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.toolStripButton1_Click);
            this.button3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button3_MouseDown);
            this.button3.MouseEnter += new System.EventHandler(this.button3_MouseEnter);
            this.button3.MouseLeave += new System.EventHandler(this.button3_MouseLeave);
            this.button3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button3_MouseUp);
            // 
            // المشتريات
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1203, 692);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.save);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.productView);
            this.Controls.Add(totalPriceLabel);
            this.Controls.Add(this.totalPriceTextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.Controls.Add(label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(this.yearTextBox);
            this.Controls.Add(this.monthTextBox);
            this.Controls.Add(this.dayTextBox);
            this.Controls.Add(saveLabel);
            this.Controls.Add(this.saveTextBox);
            this.Name = "المشتريات";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فواتير | المشتريات";
            this.Load += new System.EventHandler(this.المشتريات_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private modelDataSetTableAdapters.productsTableAdapter productsTableAdapter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.BindingSource productsBindingSource1;
        private modelDataSet modelDataSet;
        private System.Windows.Forms.BindingSource productsBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox yearTextBox;
        private System.Windows.Forms.TextBox monthTextBox;
        private System.Windows.Forms.TextBox dayTextBox;
        private System.Windows.Forms.TextBox saveTextBox;
        private System.Windows.Forms.ComboBox listBox2;
        private System.Windows.Forms.ComboBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.DataGridView productView;
        private System.Windows.Forms.DataGridViewTextBoxColumn numbrt;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPrice;
        private System.Windows.Forms.DataGridViewButtonColumn remove;
        private System.Windows.Forms.TextBox totalPriceTextBox;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button button3;
    }
}