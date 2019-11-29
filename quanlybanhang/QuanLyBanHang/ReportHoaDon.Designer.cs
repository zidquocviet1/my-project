namespace QuanLyBanHang
{
    partial class ReportHoaDon
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportHoaDon));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QuanLyBanHangDataSet3 = new QuanLyBanHang.QuanLyBanHangDataSet3();
            this.USP_GetBillInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.USP_GetBillInfoTableAdapter = new QuanLyBanHang.QuanLyBanHangDataSet3TableAdapters.USP_GetBillInfoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyBanHangDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetBillInfoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.USP_GetBillInfoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyBanHang.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(484, 478);
            this.reportViewer1.TabIndex = 0;
            // 
            // QuanLyBanHangDataSet3
            // 
            this.QuanLyBanHangDataSet3.DataSetName = "QuanLyBanHangDataSet3";
            this.QuanLyBanHangDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_GetBillInfoBindingSource
            // 
            this.USP_GetBillInfoBindingSource.DataMember = "USP_GetBillInfo";
            this.USP_GetBillInfoBindingSource.DataSource = this.QuanLyBanHangDataSet3;
            // 
            // USP_GetBillInfoTableAdapter
            // 
            this.USP_GetBillInfoTableAdapter.ClearBeforeFill = true;
            // 
            // ReportHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 477);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportHoaDon";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Hóa Đơn Bán Hàng";
            this.Load += new System.EventHandler(this.ReportHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyBanHangDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetBillInfoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_GetBillInfoBindingSource;
        private QuanLyBanHangDataSet3 QuanLyBanHangDataSet3;
        private QuanLyBanHangDataSet3TableAdapters.USP_GetBillInfoTableAdapter USP_GetBillInfoTableAdapter;
    }
}