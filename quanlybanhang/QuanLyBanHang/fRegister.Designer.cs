namespace QuanLyBanHang
{
    partial class fRegister
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
            this.tbUsername = new System.Windows.Forms.TextBox();
            this.tbDisplayname = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbType = new System.Windows.Forms.TextBox();
            this.btCreate = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbUsername
            // 
            this.tbUsername.ForeColor = System.Drawing.Color.Gray;
            this.tbUsername.Location = new System.Drawing.Point(76, 61);
            this.tbUsername.Name = "tbUsername";
            this.tbUsername.Size = new System.Drawing.Size(175, 20);
            this.tbUsername.TabIndex = 0;
            this.tbUsername.Text = "user name";
            this.tbUsername.Enter += new System.EventHandler(this.TbUsername_Enter);
            this.tbUsername.Leave += new System.EventHandler(this.TbUsername_Leave);
            // 
            // tbDisplayname
            // 
            this.tbDisplayname.ForeColor = System.Drawing.Color.Gray;
            this.tbDisplayname.Location = new System.Drawing.Point(76, 87);
            this.tbDisplayname.Name = "tbDisplayname";
            this.tbDisplayname.Size = new System.Drawing.Size(175, 20);
            this.tbDisplayname.TabIndex = 1;
            this.tbDisplayname.Text = "name";
            this.tbDisplayname.Enter += new System.EventHandler(this.TbDisplayname_Enter);
            this.tbDisplayname.Leave += new System.EventHandler(this.TbDisplayname_Leave);
            // 
            // tbPass
            // 
            this.tbPass.ForeColor = System.Drawing.Color.Gray;
            this.tbPass.Location = new System.Drawing.Point(76, 113);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(175, 20);
            this.tbPass.TabIndex = 2;
            this.tbPass.Text = "password";
            this.tbPass.Enter += new System.EventHandler(this.TbPass_Enter);
            this.tbPass.Leave += new System.EventHandler(this.TbPass_Leave);
            // 
            // tbType
            // 
            this.tbType.ForeColor = System.Drawing.Color.Gray;
            this.tbType.Location = new System.Drawing.Point(76, 139);
            this.tbType.Name = "tbType";
            this.tbType.Size = new System.Drawing.Size(175, 20);
            this.tbType.TabIndex = 3;
            this.tbType.Text = "0 : admin - 1: staff";
            this.tbType.Enter += new System.EventHandler(this.TbType_Enter);
            this.tbType.Leave += new System.EventHandler(this.TbType_Leave);
            // 
            // btCreate
            // 
            this.btCreate.Location = new System.Drawing.Point(76, 175);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(75, 23);
            this.btCreate.TabIndex = 4;
            this.btCreate.Text = "Create";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.BtCreate_Click);
            // 
            // btClose
            // 
            this.btClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btClose.Location = new System.Drawing.Point(176, 175);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 5;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.BtClose_Click);
            // 
            // fRegister
            // 
            this.AcceptButton = this.btCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btClose;
            this.ClientSize = new System.Drawing.Size(319, 235);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.tbType);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbDisplayname);
            this.Controls.Add(this.tbUsername);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đăng Ký";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbUsername;
        private System.Windows.Forms.TextBox tbDisplayname;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbType;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.Button btClose;
    }
}