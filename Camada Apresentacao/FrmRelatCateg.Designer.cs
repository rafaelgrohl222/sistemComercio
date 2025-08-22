
namespace Camada_Apresentacao
{
    partial class FrmRelatCateg
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
            this.bd_comercioDataSet = new Camada_Apresentacao.bd_comercioDataSet();
            this.tbl_categoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbl_categoriaTableAdapter = new Camada_Apresentacao.bd_comercioDataSetTableAdapters.tbl_categoriaTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.bd_comercioDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_categoriaBindingSource)).BeginInit();
            this.SuspendLayout();
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
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.tbl_categoriaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Camada_Apresentacao.ReportRelatorioCateg.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(621, 425);
            this.reportViewer1.TabIndex = 0;
            // 
            // FrmRelatCateg
            // 
            this.ClientSize = new System.Drawing.Size(645, 449);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRelatCateg";
            this.Text = "Relatório Categorias";
            this.Load += new System.EventHandler(this.FrmRelatCateg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bd_comercioDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_categoriaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource tbl_categoriaBindingSource;
        private bd_comercioDataSet bd_comercioDataSet;
        private bd_comercioDataSetTableAdapters.tbl_categoriaTableAdapter tbl_categoriaTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}