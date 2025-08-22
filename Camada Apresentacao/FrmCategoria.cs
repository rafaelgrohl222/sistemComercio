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
using Camada_Apresentacao;

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
            this.ttMensagemErro.SetToolTip(this.txtDescricao, "Inserir a descrição da Categoria");
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
        private void HabilitarBotoes()
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
            //this.dataLista.Columns[1].Visible = false;
        }

        //Método - Mostrar no DataGrid
        private void MostrarDataGrid()
        {
            this.dataLista.DataSource = NCategoria.Mostrar();
            this.ocutarColunas();
            lblTotal.Text = Convert.ToString(dataLista.Rows.Count);
        }

        //Método - Buscar pelo Nome
        private void BuscarNome()
        {
            this.dataLista.DataSource = NCategoria.BuscarNome(this.txtBuscar.Text);//txtBuscar vem formulário
            this.ocutarColunas();
            lblTotal.Text = Convert.ToString(dataLista.Rows.Count);
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.MostrarDataGrid();
            this.HabilitarTextBox(false);
            this.HabilitarBotoes();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNome();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNome();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            this.eNovo = true;
            this.eEditar = false;
            this.HabilitarBotoes();
            this.Limpar();
            this.HabilitarTextBox(true);
            this.txtNome.Focus();//Foco no formulário nome
            this.txtIdCategoria.Enabled = false;//Campo desabilitado
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                string resp = "";
                if(this.txtNome.Text == string.Empty)//empty=vazio
                {
                    MensagemError("Preencha todos os campos!");
                    errorIcone.SetError(txtNome, "Inserir o Nome!");
                } else
                {
                    if(this.eNovo)
                    {
                        //Iguinorar espaço vazio: .Trim()
                        resp = NCategoria.Incerir(this.txtNome.Text.Trim().ToUpper(), this.txtDescricao.Text.Trim());
                    } else
                    {
                        //Converter em caixa alta: .ToUpper()
                        resp = NCategoria.Editar(Convert.ToInt32(this.txtIdCategoria.Text), this.txtNome.Text.Trim().ToUpper(), this.txtDescricao.Text.Trim());
                    }
                    //Se amensagem q/ vier for Equals: igual
                    if (resp.Equals("OK"))
                    {
                        if(this.eNovo)
                        {
                            this.MensagemOk("Registro salvo com sucesso!");
                        } else
                        {
                            this.MensagemOk("Registro editado com sucesso!");
                        }
                    } else
                    {
                        this.MensagemError(resp);
                    }
                    this.eNovo = false;
                    this.eEditar = false;
                    this.HabilitarBotoes();
                    this.Limpar();
                    this.MostrarDataGrid();
                }
            }
            catch (Exception ex)
            {
                //Mensagem de detalhamento do error
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void dataLista_DoubleClick(object sender, EventArgs e)
        {
            //Recuperar dados dataLista e grid recupera BD
            //CurrentRow: Local clicado, na celuna idcategoria
            this.txtIdCategoria.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["id_categoria"].Value);
            this.txtNome.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["nome"].Value);
            this.txtDescricao.Text = Convert.ToString(this.dataLista.CurrentRow.Cells["descricao"].Value);
            //Recupere p/ tabControl1 aba 1 (aba 0: Lista,1: Configurações)
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.txtIdCategoria.Text.Equals(""))
            {
                this.MensagemError("Selecione um registro para inserir!");
            } else
            {
                this.eEditar = true;
                this.HabilitarBotoes();
                this.HabilitarTextBox(true);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.eNovo = false;
            this.eEditar = false;
            this.HabilitarBotoes();
            this.HabilitarTextBox(false);
            this.Limpar();
        }

        private void chkDeletar_CheckedChanged(object sender, EventArgs e)
        {
            //CheckBox extiver selecionado (Checked)
            if(chkDeletar.Checked)
            {
                //DataGridView coluna 0 
                this.dataLista.Columns[0].Visible = true;
            } else
            {
                this.dataLista.Columns[0].Visible = false;
            }
        }

        private void dataLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dataLista.Columns["Deletar"].Index)
            {
                DataGridViewCheckBoxCell ChkDeletar = (DataGridViewCheckBoxCell)dataLista.Rows[e.RowIndex].Cells["Deletar"];
                ChkDeletar.Value = !Convert.ToBoolean(ChkDeletar.Value);
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcao;
                Opcao = MessageBox.Show("Realmente Deseja apagar os registros?", "Sistema Comércio", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if(Opcao == DialogResult.OK)
                {
                    string Codigo;
                    string Resp = "";

                    foreach(DataGridViewRow row in dataLista.Rows) 
                    {
                        if(Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Resp = NCategoria.Excluir(Convert.ToInt32(Codigo));

                            if(Resp.Equals("OK"))
                            {
                                this.MensagemOk("Registro excluido com Sucesso!");
                            } else
                            {
                                this.MensagemError(Resp);
                            }
                        }
                    }
                    this.MostrarDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmRelatCateg rlt = new FrmRelatCateg();
            rlt.ShowDialog();
        }
    }
}
