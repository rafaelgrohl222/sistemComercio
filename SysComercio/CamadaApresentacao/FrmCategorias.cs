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

        //Método - Habilitar Text Box
        private void HabilitarTextBox(bool valor)
        {
            this.txtNome.ReadOnly = !valor;// ReadOnly = apenas leitura, nevar(!) somenteleitura
            this.txtDescricao.ReadOnly = !valor;
            this.txtIdCategoria.ReadOnly = !valor;
        }

        //Método - Habilitar Botões
        private void HabilitarBotoes()
        {
            if(this.eNovo || eEditar)
            {
                this.HabilitarTextBox(true);
                this.btnNovo.Enabled = false;
                this.btnEditar.Enabled = false;
                this.btnSalvar.Enabled = true;
                this.btnCancelar.Enabled = true;
            } 
            else
            {
                this.HabilitarTextBox(false);
                this.btnNovo.Enabled = true;
                this.btnEditar.Enabled = true;
                this.btnSalvar.Enabled = false;
                this.btnCancelar.Enabled = false;
            }
        }

        //Metodo - Ocutar Colunas do Grid
        private void OcutarTabelaGrid()
        {
            this.dataLista.Columns[0].Visible = false;// Visible = visibilidade
            this.dataLista.Columns[1].Visible = false;
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {

        }
        //Parei aula 42 00min00seg
    }
}
