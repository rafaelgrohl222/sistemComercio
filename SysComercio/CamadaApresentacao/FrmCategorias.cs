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

namespace CamadaApresentacao
{
    public partial class FrmCategorias : Form
    {
        private bool eNovo = false;
        private bool eEditar = false;

        public FrmCategorias()
        {
            InitializeComponent();
            this.ttMensagem.SetToolTip(this.txtNome, "Insira o nome da Categoria");// mensagem ao usuário
        }

        //Método - Mostrar mensagem de Configuração
        private void MensagemOk(string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema Comércio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Método - Mostrar mensagem de Erro
        private void MessansagemErro(string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema Comércio", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Método - Limpar Campos
        private void Limpar()
        {
            this.txtNome.Text = string.Empty;
            this.txtIdCategoria.Text = string.Empty;
            this.txtDescricao.Text = string.Empty;
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {

        }
    }
}
