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

        //Método - Mensagem de Confirmação
        private void MensagemOk( string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema Comércio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Método - Mensagem de Erro
        private void MensagemError( string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema Comércio", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Método - Limpar Campo
        private void Limpar()
        {
            this.txtNome.Text = string.Empty;//Vazio
            this.txtIdCategoria.Text = string.Empty;
            this.txtDescricao.Text = string.Empty;
        }

        //Método - Habilitar textBox
        private void HabilitarTextBox( bool valor)
        {
            this.txtNome.ReadOnly = !valor;
            this.txtIdCategoria.ReadOnly = !valor;
            this.txtDescricao.ReadOnly = !valor;
        }

        //Método - Habilitar Botões
        private void HabilitarBotoes( bool valor)
        {
            if (this.eNovo || this.eEditar)
            {
                this.HabilitarTextBox(true);
                this.btnNovo.Enabled = false;//Enabled: Desabilitado
                this.btnSalvar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            } else
            {
                this.HabilitarTextBox(false);
                this.btnNovo.Enabled = true;
                this.btnSalvar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        //Método - Ocutar Colunas do Grid
        private void ocutarColunas()
        {
            this.dataLista.Columns[0].Visible = false;
            this.dataLista.Columns[1].Visible = false;
        }

        //Método - Mostrar no DataGrid
        private void MostarDataGrid()
        {
            this.dataLista.DataSource = NCategoria.Mostrar();
            this.ocutarColunas();
            lblTotal.Text = Convert.ToString(dataLista.Rows.Count);
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {

        }
    }
}
