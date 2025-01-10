namespace fouater
{
    partial class الموظفين
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.modelDataSet = new fouater.modelDataSet();
            this.userView = new System.Windows.Forms.DataGridView();
            this.roleBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.ppassword = new System.Windows.Forms.TextBox();
            this.nname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userTableAdapter = new fouater.modelDataSetTableAdapters.employeesTableAdapter();
            this.tableAdapterManager = new fouater.modelDataSetTableAdapters.TableAdapterManager();
            this.roleTableAdapter = new fouater.modelDataSetTableAdapters.RoleTableAdapter();
            this.rrole = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.authh = new System.Windows.Forms.ComboBox();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.auth = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // modelDataSet
            // 
            this.modelDataSet.DataSetName = "modelDataSet";
            this.modelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // userView
            // 
            this.userView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.num,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.auth,
            this.Column1,
            this.update,
            this.delete});
            this.userView.Location = new System.Drawing.Point(0, 105);
            this.userView.Name = "userView";
            this.userView.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.userView.Size = new System.Drawing.Size(1083, 446);
            this.userView.TabIndex = 1;
            this.userView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.userView_CellClick);
            // 
            // roleBindingSource1
            // 
            this.roleBindingSource1.DataMember = "Role";
            this.roleBindingSource1.DataSource = this.modelDataSet;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.Font = new System.Drawing.Font("Tahoma", 16F);
            this.button1.ForeColor = System.Drawing.Color.Brown;
            this.button1.Location = new System.Drawing.Point(62, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 58);
            this.button1.TabIndex = 2;
            this.button1.Tag = "";
            this.button1.Text = "حفظ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            this.button1.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.button1.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            this.button1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button1_MouseUp);
            // 
            // ppassword
            // 
            this.ppassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ppassword.Font = new System.Drawing.Font("Tahoma", 20F);
            this.ppassword.ForeColor = System.Drawing.Color.IndianRed;
            this.ppassword.Location = new System.Drawing.Point(597, 59);
            this.ppassword.Name = "ppassword";
            this.ppassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ppassword.Size = new System.Drawing.Size(204, 40);
            this.ppassword.TabIndex = 4;
            // 
            // nname
            // 
            this.nname.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.nname.Font = new System.Drawing.Font("Tahoma", 20F);
            this.nname.ForeColor = System.Drawing.Color.IndianRed;
            this.nname.Location = new System.Drawing.Point(807, 59);
            this.nname.Name = "nname";
            this.nname.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.nname.Size = new System.Drawing.Size(222, 40);
            this.nname.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label1.Location = new System.Drawing.Point(461, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "نوع الموظف";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label2.Location = new System.Drawing.Point(669, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "كلمة سر";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label3.Location = new System.Drawing.Point(895, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "الاسم";
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataMember = "employees";
            this.userBindingSource.DataSource = this.modelDataSet;
            // 
            // userTableAdapter
            // 
            this.userTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.companiesTableAdapter = null;
            this.tableAdapterManager.employeesTableAdapter = this.userTableAdapter;
            this.tableAdapterManager.Inv_ProTableAdapter = null;
            this.tableAdapterManager.invoicesTableAdapter = null;
            this.tableAdapterManager.productsTableAdapter = null;
            this.tableAdapterManager.RoleTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = fouater.modelDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // roleTableAdapter
            // 
            this.roleTableAdapter.ClearBeforeFill = true;
            // 
            // rrole
            // 
            this.rrole.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.rrole.Font = new System.Drawing.Font("Tahoma", 20F);
            this.rrole.ForeColor = System.Drawing.Color.IndianRed;
            this.rrole.FormattingEnabled = true;
            this.rrole.Items.AddRange(new object[] {
            "مدير",
            "موظف"});
            this.rrole.Location = new System.Drawing.Point(415, 58);
            this.rrole.Name = "rrole";
            this.rrole.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rrole.Size = new System.Drawing.Size(176, 41);
            this.rrole.TabIndex = 9;
            this.rrole.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rrole_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F);
            this.label4.Location = new System.Drawing.Point(281, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "صلاحية الخصم";
            // 
            // authh
            // 
            this.authh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.authh.Font = new System.Drawing.Font("Tahoma", 20F);
            this.authh.ForeColor = System.Drawing.Color.IndianRed;
            this.authh.FormattingEnabled = true;
            this.authh.Items.AddRange(new object[] {
            "نعم",
            "لا"});
            this.authh.Location = new System.Drawing.Point(259, 58);
            this.authh.Name = "authh";
            this.authh.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.authh.Size = new System.Drawing.Size(150, 41);
            this.authh.TabIndex = 11;
            this.authh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // num
            // 
            this.num.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.num.HeaderText = "الرقم";
            this.num.Name = "num";
            this.num.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "رقم الموظف";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "userName";
            this.dataGridViewTextBoxColumn2.HeaderText = "الاسم";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "password";
            this.dataGridViewTextBoxColumn3.HeaderText = "كلمة سر";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "role";
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn4.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dataGridViewTextBoxColumn4.HeaderText = "نوع الموظف";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // auth
            // 
            this.auth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.auth.DefaultCellStyle = dataGridViewCellStyle2;
            this.auth.HeaderText = "صلاحية الخصم";
            this.auth.Name = "auth";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // update
            // 
            this.update.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.update.HeaderText = "تعديل";
            this.update.Name = "update";
            this.update.Text = "حذف";
            // 
            // delete
            // 
            this.delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.delete.HeaderText = "حذف";
            this.delete.Name = "delete";
            this.delete.Text = "حذف";
            // 
            // الموظفين
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1082, 551);
            this.Controls.Add(this.authh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rrole);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nname);
            this.Controls.Add(this.ppassword);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.userView);
            this.Name = "الموظفين";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فواتير | الموظفين";
            this.Load += new System.EventHandler(this.الموظفين_Load);
            ((System.ComponentModel.ISupportInitialize)(this.modelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roleBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private modelDataSet modelDataSet;
        private System.Windows.Forms.DataGridView userView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox ppassword;
        private System.Windows.Forms.TextBox nname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource roleBindingSource1;
        private System.Windows.Forms.BindingSource userBindingSource;
        private modelDataSetTableAdapters.employeesTableAdapter userTableAdapter;
        private modelDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private modelDataSetTableAdapters.RoleTableAdapter roleTableAdapter;
        private System.Windows.Forms.ComboBox rrole;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox authh;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewComboBoxColumn auth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn update;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
    }
}