
namespace SysComercio
{
    partial class FormRelatCategoria
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.bd_comercioDataSet = new SysComercio.bd_comercioDataSet();
            this.tbl_categoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_categoriaTableAdapter = new SysComercio.bd_comercioDataSetTableAdapters.tbl_categoriaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bd_comercioDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_categoriaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbl_categoriaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SysComercio.ReportCategorias.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(499, 421);
            this.reportViewer1.TabIndex = 0;
            // 
            // bd_comercioDataSet
            // 
            this.bd_comercioDataSet.DataSetName = "bd_comercioDataSet";
            this.bd_comercioDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_categoriaBindingSource
            // 
            this.tbl_categoriaBindingSource.DataMember = "tbl_categoria";
            this.tbl_categoriaBindingSource.DataSource = this.bd_comercioDataSet;
            // 
            // tbl_categoriaTableAdapter
            // 
            this.tbl_categoriaTableAdapter.ClearBeforeFill = true;
            // 
            // FormRelatCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 421);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormRelatCategoria";
            this.Text = "FormRelatCategoria";
            this.Load += new System.EventHandler(this.FormRelatCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bd_comercioDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_categoriaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tbl_categoriaBindingSource;
        private bd_comercioDataSet bd_comercioDataSet;
        private bd_comercioDataSetTableAdapters.tbl_categoriaTableAdapter tbl_categoriaTableAdapter;
    }
}