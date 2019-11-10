namespace QuanLyBanHang
{
    partial class fNhaCungCap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fNhaCungCap));
            this.dgvNhaCC = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUnSelect = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIDCongTy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.mskPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhaCC)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNhaCC
            // 
            this.dgvNhaCC.AllowUserToAddRows = false;
            this.dgvNhaCC.AllowUserToDeleteRows = false;
            this.dgvNhaCC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNhaCC.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvNhaCC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNhaCC.Location = new System.Drawing.Point(12, 166);
            this.dgvNhaCC.Name = "dgvNhaCC";
            this.dgvNhaCC.ReadOnly = true;
            this.dgvNhaCC.RowHeadersVisible = false;
            this.dgvNhaCC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNhaCC.Size = new System.Drawing.Size(694, 194);
            this.dgvNhaCC.TabIndex = 54;
            this.dgvNhaCC.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvNhaCC_CellClick);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(389, 371);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 46);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Location = new System.Drawing.Point(632, 371);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 46);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Đóng";
            this.btnExit.UseVisualStyleBackColor = true;
            // 
            // btnUnSelect
            // 
            this.btnUnSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnUnSelect.Location = new System.Drawing.Point(551, 371);
            this.btnUnSelect.Name = "btnUnSelect";
            this.btnUnSelect.Size = new System.Drawing.Size(75, 46);
            this.btnUnSelect.TabIndex = 9;
            this.btnUnSelect.Text = "Hủy";
            this.btnUnSelect.UseVisualStyleBackColor = true;
            this.btnUnSelect.Click += new System.EventHandler(this.BtnUnSelect_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(470, 371);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 46);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(277, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 24);
            this.label1.TabIndex = 60;
            this.label1.Text = "NHÀ CUNG CẤP";
            // 
            // txtIDCongTy
            // 
            this.txtIDCongTy.Enabled = false;
            this.txtIDCongTy.Location = new System.Drawing.Point(101, 85);
            this.txtIDCongTy.Name = "txtIDCongTy";
            this.txtIDCongTy.ReadOnly = true;
            this.txtIDCongTy.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtIDCongTy.Size = new System.Drawing.Size(127, 20);
            this.txtIDCongTy.TabIndex = 61;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(9, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 15);
            this.label5.TabIndex = 62;
            this.label5.Text = "Mã công ty: ";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(101, 122);
            this.txtName.Name = "txtName";
            this.txtName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtName.Size = new System.Drawing.Size(127, 20);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(9, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 64;
            this.label2.Text = "Tên công ty: ";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(326, 122);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAddress.Size = new System.Drawing.Size(127, 20);
            this.txtAddress.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(266, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 66;
            this.label3.Text = "Địa chỉ: ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(326, 85);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEmail.Size = new System.Drawing.Size(127, 20);
            this.txtEmail.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(266, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 68;
            this.label4.Text = "Email: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label6.Location = new System.Drawing.Point(491, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 15);
            this.label6.TabIndex = 70;
            this.label6.Text = "Số điện thoại: ";
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(579, 122);
            this.txtFax.Name = "txtFax";
            this.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFax.Size = new System.Drawing.Size(127, 20);
            this.txtFax.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label7.Location = new System.Drawing.Point(491, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 15);
            this.label7.TabIndex = 72;
            this.label7.Text = "Fax: ";
            // 
            // mskPhoneNumber
            // 
            this.mskPhoneNumber.Location = new System.Drawing.Point(579, 85);
            this.mskPhoneNumber.Mask = "000-0000000";
            this.mskPhoneNumber.Name = "mskPhoneNumber";
            this.mskPhoneNumber.Size = new System.Drawing.Size(127, 20);
            this.mskPhoneNumber.TabIndex = 4;
            // 
            // fNhaCungCap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(718, 425);
            this.Controls.Add(this.mskPhoneNumber);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIDCongTy);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnUnSelect);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dgvNhaCC);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fNhaCungCap";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nhà Cung Cấp";
            this.Load += new System.EventHandler(this.FNhaCungCap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNhaCC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNhaCC;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnUnSelect;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIDCongTy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox mskPhoneNumber;
    }
}