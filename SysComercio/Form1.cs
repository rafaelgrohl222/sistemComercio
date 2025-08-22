using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysComercio
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }

        private void form1_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'bd_comercioDataSet.tbl_categoria'. Você pode movê-la ou removê-la conforme necessário.
            this.tbl_categoriaTableAdapter.Fill(this.bd_comercioDataSet.tbl_categoria);

            this.reportViewer1.RefreshReport();
        }
    }
}
