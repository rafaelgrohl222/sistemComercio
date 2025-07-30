using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CamadaNegocio;

namespace Camada_Apresentacao
{
    public partial class FrmCategoria : Form
    {
        private bool eNovo = false;
        private bool eEditar = false;

        public FrmCategoria()
        {
            InitializeComponent();
            //Instrução para o usuário - posicionar o mause mostra mensagem 
            this.ttMensagemErro.SetToolTip(this.txtNome, "Inserir o nome da Categoria!");
        }

        //Método - Mostra mensagem de confirmação
        private void MensagemOk( string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema Comércio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {

        }
    }
}
