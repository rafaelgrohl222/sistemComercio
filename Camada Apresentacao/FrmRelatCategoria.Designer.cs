
namespace Camada_Apresentacao
{
    partial class FrmRelatCategoria
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
            this.tbl_categoriaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bd_comercioDataSet = new Camada_Apresentacao.bd_comercioDataSet();
            this.tbl_categoriaTableAdapter = new Camada_Apresentacao.bd_comercioDataSetTableAdapters.tbl_categoriaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_categoriaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bd_comercioDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tbl_categoriaBindingSource
            // 
            this.tbl_categoriaBindingSource.DataMember = "tbl_categoria";
            this.tbl_categoriaBindingSource.DataSource = this.bd_comercioDataSet;
            // 
            // bd_comercioDataSet
            // 
            this.bd_comercioDataSet.DataSetName = "bd_comercioDataSet";
            this.bd_comercioDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbl_categoriaTableAdapter
            // 
            this.tbl_categoriaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRelatCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 393);
            this.Name = "FrmRelatCategoria";
            this.Text = "Relatório Categoria";
            this.Load += new System.EventHandler(this.FomRelatCategoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_categoriaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bd_comercioDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource tbl_categoriaBindingSource;
        private bd_comercioDataSet bd_comercioDataSet;
        private bd_comercioDataSetTableAdapters.tbl_categoriaTableAdapter tbl_categoriaTableAdapter;
    }
}