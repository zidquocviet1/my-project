namespace QuanLyBanHang
{
    partial class fReportDoanhThu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fReportDoanhThu));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QuanLyBanHangDataSet1 = new QuanLyBanHang.QuanLyBanHangDataSet1();
            this.USP_DoanhThuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.USP_DoanhThuTableAdapter = new QuanLyBanHang.QuanLyBanHangDataSet1TableAdapters.USP_DoanhThuTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyBanHangDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_DoanhThuBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.USP_DoanhThuBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyBanHang.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(829, 478);
            this.reportViewer1.TabIndex = 0;
            // 
            // QuanLyBanHangDataSet1
            // 
            this.QuanLyBanHangDataSet1.DataSetName = "QuanLyBanHangDataSet1";
            this.QuanLyBanHangDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // USP_DoanhThuBindingSource
            // 
            this.USP_DoanhThuBindingSource.DataMember = "USP_DoanhThu";
            this.USP_DoanhThuBindingSource.DataSource = this.QuanLyBanHangDataSet1;
            // 
            // USP_DoanhThuTableAdapter
            // 
            this.USP_DoanhThuTableAdapter.ClearBeforeFill = true;
            // 
            // fReportDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 477);
            this.Controls.Add(this.reportViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fReportDoanhThu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Báo Cáo Doanh Thu";
            this.Load += new System.EventHandler(this.fReportDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyBanHangDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.USP_DoanhThuBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_DoanhThuBindingSource;
        private QuanLyBanHangDataSet1 QuanLyBanHangDataSet1;
        private QuanLyBanHangDataSet1TableAdapters.USP_DoanhThuTableAdapter USP_DoanhThuTableAdapter;
    }
}