using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CamadaDados
{
    public class DCategoria
    {
        private int _Id_categoria;
        private string _Nome;
        private string _Descricao;
        private string _TextoBuscar;

        public int Id_categoria { get => _Id_categoria; set => _Id_categoria = value; }
        public string Nome { get => _Nome; set => _Nome = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }

        //Construtor S/ parâmetros
        public DCategoria() { }

        //Construtor C/ parâmetros
        public DCategoria(int idcategoria, string nome, string descricao, string buscarnome)
        {
            //Receber informações do BDs
            this.Id_categoria = idcategoria;
            this.Nome = nome;
            this.Descricao = descricao;
            this.TextoBuscar = buscarnome;
        }
        //Método Inserir
        public string Inserir(DCategoria Categoria) 
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();//Aberta a conexão

                //Chamando o procedimento / procedure
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;//Receber a conexão
                SqlCmd.CommandText = "spinserir_categoria";//nome da procedimento BD bd_comercio
                SqlCmd.CommandType = CommandType.StoredProcedure;//Executar tipo procedure

                //Estanciar variaveis SQL (@id_categoria)
                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@id_categoria";
                ParIdCategoria.SqlDbType=SqlDbType.Int;//Tratamento tipo
                ParIdCategoria.Direction = ParameterDirection.Output;//Tratamento tipo
                SqlCmd.Parameters.Add(ParIdCategoria);//Adicionar ao parâmetro

                //Estanciar variaveis SQL (@nome)
                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Categoria.Nome;
                SqlCmd.Parameters.Add(ParNome);

                //Estanciar variaveis SQL (@descricao)
                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@descricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 100;
                ParDescricao.Value = Categoria.Descricao;
                SqlCmd.Parameters.Add(ParDescricao);

                //Executar o comando = se inserido informar: OK se não "Registro não foi Inserido!"
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não foi Inserido!";

            }
            catch (Exception ex)
            {
                //Mensagem de erro
                resp = ex.Message;
            }
            finally
            {
                //Se a conexão for aberta e o status estiver aberta, então fechar conexão
                if(SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resp;
        }
        //Método Editar
        public string Editar(DCategoria Categoria) 
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();//Aberta a conexão

                //Chamando o procedimento / procedure
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;//Receber a conexão
                SqlCmd.CommandText = "speditar_categoria";//nome da procedimento BD bd_comercio
                SqlCmd.CommandType = CommandType.StoredProcedure;//Executar tipo procedure

                //Estanciar variaveis SQL (@id_categoria)
                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@id_categoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;//Tratamento tipo
                ParIdCategoria.Value = Categoria.Id_categoria;//Tratamento tipo
                SqlCmd.Parameters.Add(ParIdCategoria);//Adicionar ao parâmetro

                //Estanciar variaveis SQL (@nome)
                SqlParameter ParNome = new SqlParameter();
                ParNome.ParameterName = "@nome";
                ParNome.SqlDbType = SqlDbType.VarChar;
                ParNome.Size = 50;
                ParNome.Value = Categoria.Nome;
                SqlCmd.Parameters.Add(ParNome);

                //Estanciar variaveis SQL (@descricao)
                SqlParameter ParDescricao = new SqlParameter();
                ParDescricao.ParameterName = "@descricao";
                ParDescricao.SqlDbType = SqlDbType.VarChar;
                ParDescricao.Size = 100;
                ParDescricao.Value = Categoria.Descricao;
                SqlCmd.Parameters.Add(ParDescricao);

                //Executar o comando = se edição informar: OK se não "Registro não foi Inserido!"
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "A edição não foi realizada!";

            }
            catch (Exception ex)
            {
                //Mensagem de erro
                resp = ex.Message;
            }
            finally
            {
                //Se a conexão for aberta e o status estiver aberta, então fechar conexão
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resp;
        }
        //Método Excluir
        public string Excluir(DCategoria Categoria) 
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCon.Open();//Aberta a conexão

                //Chamando o procedimento / procedure
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;//Receber a conexão
                SqlCmd.CommandText = "spdeletar_categoria";//nome da procedimento BD bd_comercio
                SqlCmd.CommandType = CommandType.StoredProcedure;//Executar tipo procedure

                //Estanciar variaveis SQL (@id_categoria)
                SqlParameter ParIdCategoria = new SqlParameter();
                ParIdCategoria.ParameterName = "@id_categoria";
                ParIdCategoria.SqlDbType = SqlDbType.Int;//Tratamento tipo
                ParIdCategoria.Value = Categoria.Id_categoria;//Tratamento tipo
                SqlCmd.Parameters.Add(ParIdCategoria);//Adicionar ao parâmetro

                //Executar o comando = se exclusão informar: OK se não "Registro não foi Inserido!"
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "A exclusão não foi realizada!";

            }
            catch (Exception ex)
            {
                //Mensagem de erro
                resp = ex.Message;
            }
            finally
            {
                //Se a conexão for aberta e o status estiver aberta, então fechar conexão
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return resp;
        }
        //Método Mostrar
        public DataTable Mostrar() 
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Chamando o procedimento / procedure
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;//Receber a conexão
                SqlCmd.CommandText = "spmostrar_categoria";//nome da procedimento BD bd_comercio
                SqlCmd.CommandType = CommandType.StoredProcedure;//Executar tipo procedure
                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);//Mostrar usar SqlDataAdapter
                sqlDat.Fill(DtResultado);//Preencher a tabela e exibir resultado
            }
            catch (Exception ex)
            {
                DtResultado = null;//Não mostrainformação se houver erro.
            }
            return DtResultado;
        }
        //Método Buscar Nome
        public DataTable BuscarNome(DCategoria Categoria) 
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Chamando o procedimento / procedure
                SqlCon.ConnectionString = Conexao.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;//Receber a conexão
                SqlCmd.CommandText = "spbuscar_nome";//nome da procedimento BD bd_comercio
                SqlCmd.CommandType = CommandType.StoredProcedure;//Executar tipo procedure
                SqlDataAdapter sqlDat = new SqlDataAdapter(SqlCmd);//Mostrar usar SqlDataAdapter
                sqlDat.Fill(DtResultado);//Preencher a tabela e exibir resultado

                //Estanciar variaveis SQL (@descricao)
                SqlParameter ParTextoBuscar = new SqlParameter();
                ParTextoBuscar.ParameterName = "@testobuscar";
                ParTextoBuscar.SqlDbType = SqlDbType.VarChar;
                ParTextoBuscar.Size = 50;
                ParTextoBuscar.Value = Categoria.TextoBuscar;
                SqlCmd.Parameters.Add(ParTextoBuscar);
            }
            catch (Exception ex)
            {
                DtResultado = null;//Não mostrainformação se houver erro.
            }
            return DtResultado;
        }
    }
}
