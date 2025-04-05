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
    public partial class FrmCategoria : Form
    {
        //Identificar de está em modo novo ou editar
        private bool eNovo = false;
        private bool eEditar = false;

        public FrmCategoria()
        {
            InitializeComponent();
            this.ttMensagem.SetToolTip(this.txtNome, "Insira o nome da Categoria");//Mensagem do textBox p/ usuário
        }

        //Método - Mostrar mensagem de confirmação
        private void MensagemOk (string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema Comércio", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Método - Mostrar mensagem de erro
        private void MensagemErro (string mensagem)
        {
            MessageBox.Show(mensagem, "Sistema Comércio", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Método - Limpar campo
        private void Limpar()
        {
            this.txtNome.Text = string.Empty;//Empty: Limpar/vazio
            this.txtIdCategoria.Text = string.Empty;
            this.txtDescricao.Text = string.Empty;
        }

        //Método - Habilitar os textBox
        private void Habilitar(bool valor)
        {
            this.txtNome.ReadOnly = !valor;//ReadOnly: Somente leitura / Inabilitado
            this.txtDescricao.ReadOnly = !valor;
            this.txtIdCategoria.ReadOnly = !valor;
        }

        //Método - Habilitar botões
        private void botoes()
        {
            if (this.eNovo || this.eEditar)
            {
                this.Habilitar(true);
                this.btnNovo.Enabled = false;//enabled / Habilitado
                this.btnSalvar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNovo.Enabled = true;
                this.btnSalvar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }

        //Método - Ocutar Colunas Grid
        private void ocutarColunas()
        {
            this.dataLista.Columns[0].Visible = false;
            this.dataLista.Columns[1].Visible = false;
        }

        //Método - Mostrar Data Grid
        private void Mostrar()
        {
            this.dataLista.DataSource = NCategoria.Mostrar(); //dataSource: Carrega os dados
            this.ocutarColunas();//Ocutar colunas
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataLista.Rows.Count);//Realiza a contagem de registro BD (converte texto)
        }

        //Método - Buscar pelo Nome
        private void BuscarNome()
        {
            this.dataLista.DataSource = NCategoria.BuscarNome(this.txtBuscar.Text); //dataSource: Carrega os dados
            this.ocutarColunas();//Ocutar colunas
            lblTotal.Text = "Total de registros: " + Convert.ToString(dataLista.Rows.Count);//Realiza a contagem de registro BD (converte texto)
        }

        //Método = Ao entrar no FrmCategoria
        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.botoes();
        }
    }
}// parei aula 44 - 0min00seg
