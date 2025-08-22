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
        private int _IdCategoria;
        private string _Nome;
        private string _Descricao;
        private string _TextoBuscar;

        //Método: get recupera, set envia o valo BD
        public int IdCategoria { get => _IdCategoria; set => _IdCategoria = value; }
        public string Nome { get => _Nome; set => _Nome = value; }
        public string Descricao { get => _Descricao; set => _Descricao = value; }
        public string TextoBuscar { get => _TextoBuscar; set => _TextoBuscar = value; }
        
        //Costrutor Vasio - P/ permitir usar classe
        public DCategoria() { }

        //Costrutor c/ Parametros - Relacionar os campos que vai receber do BD que estão no get e set
        public DCategoria(int idcategoria, string nome, string descricao, string textobuscar) 
        {
            this.IdCategoria = idcategoria;
            this.Nome = nome;
            this.Descricao = descricao;
            this.TextoBuscar = textobuscar;
        }

        //Método Inserir
        public string Inserir(DCategoria Categoria)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();//Abrir conexão
            try //Executa
            {
                //Link de conexão: Cn
                SqlCon.ConnectionString = Conexao.Cn;//Chamar link conexâo
                SqlCon.Open();//Abrir nova conexão

                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,//Receber a conexâo
                    CommandText = "spinserir_categoria",//Recebe procedure
                    CommandType = CommandType.StoredProcedure//Executar o comando da procedure
                };//Estanciar

                SqlParameter ParIdcategoria = new SqlParameter
                {
                    //Procedure @id_categoria
                    ParameterName = "@id_categoria",//Executar a procedure
                    SqlDbType = SqlDbType.Int,//Tipo de dados
                    Direction = ParameterDirection.Output//Direção
                };//Estanciar
                SqlCmd.Parameters.Add(ParIdcategoria);//Add no SQL

                //Procedure @nome
                SqlParameter ParNome = new SqlParameter
                {
                    ParameterName = "@nome",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Categoria.Nome
                };
                SqlCmd.Parameters.Add(ParNome);

                //Procedure @descricao
                SqlParameter ParDescricao = new SqlParameter
                {
                    ParameterName = "@descricao",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = Categoria.Descricao
                };
                SqlCmd.Parameters.Add(ParDescricao);

                //                                       se sim? caso contrario : "Não Inserido"
                //Executar o comando - Teste de execução se = 1? "OK" : "Não Inserido";
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "Registro não Inserido!";//Executando procedure: ExecuteNonQuery

            }
            catch (Exception ex)//Caso der erro executa
            {
                resp = ex.Message;//Mensagem de erro
            }
            finally //Sempre executa
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();// Fechar conexão se estiver aberta
            }
            return resp;
        }

        //Método Editar
        public string Editar(DCategoria Categoria)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();//Abrir conexão
            try //Executa
            {
                //Link de conexão: Cn
                SqlCon.ConnectionString = Conexao.Cn;//Chamar link conexâo
                SqlCon.Open();//Abrir nova conexão

                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,//Receber a conexâo
                    CommandText = "speditar_categoria",//Recebe procedure
                    CommandType = CommandType.StoredProcedure//Executar o comando da procedure
                };//Estanciar

                SqlParameter ParIdcategoria = new SqlParameter
                {
                    //Procedure @id_categoria
                    ParameterName = "@id_categoria",//Executar a procedure
                    SqlDbType = SqlDbType.Int,//Tipo de dados
                    Value = Categoria.IdCategoria//Value
                };//Estanciar
                SqlCmd.Parameters.Add(ParIdcategoria);//Add no SQL

                //Procedure @nome
                SqlParameter ParNome = new SqlParameter
                {
                    ParameterName = "@nome",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Categoria.Nome
                };
                SqlCmd.Parameters.Add(ParNome);

                //Procedure @descricao
                SqlParameter ParDescricao = new SqlParameter
                {
                    ParameterName = "descricao",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Value = Categoria.Descricao
                };
                SqlCmd.Parameters.Add(ParDescricao);

                //                                       se sim? caso contrario : "Não Inserido"
                //Executar o comando - Teste de execução se = 1? "OK" : "Edição não realizada";
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "A edição não Realizada!";//Executando procedure: ExecuteNonQuery

            }
            catch (Exception ex)//Caso der erro executa
            {
                resp = ex.Message;//Mensagem de erro
            }
            finally //Sempre executa
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();// Fechar conexão se estiver aberta
            }
            return resp;
        }

        //Método Excluir
        public string Excluir(DCategoria Categoria)
        {
            string resp = "";
            SqlConnection SqlCon = new SqlConnection();//Abrir conexão
            try //Executa
            {
                //Link de conexão: Cn
                SqlCon.ConnectionString = Conexao.Cn;//Chamar link conexâo
                SqlCon.Open();//Abrir nova conexão

                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,//Receber a conexâo
                    CommandText = "spdeletar_categoria",//Recebe procedure
                    CommandType = CommandType.StoredProcedure//Executar o comando da procedure
                };//Estanciar

                SqlParameter ParIdcategoria = new SqlParameter
                {
                    //Procedure @id_categoria
                    ParameterName = "@id_categoria",//Executar a procedure
                    SqlDbType = SqlDbType.Int,//Tipo de dados
                    Value = Categoria.IdCategoria//Value
                };//Estanciar
                SqlCmd.Parameters.Add(ParIdcategoria);//Add no SQL

                //                                       se sim? caso contrario : "Não Inserido"
                //Executar o comando - Teste de execução se = 1? "OK" : "Edição não realizada";
                resp = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "A exclusão não Realizada!";//Executando procedure: ExecuteNonQuery

            }
            catch (Exception ex)//Caso der erro executa
            {
                resp = ex.Message;//Mensagem de erro
            }
            finally //Sempre executa
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();// Fechar conexão se estiver aberta
            }
            return resp;
        }

        //Método Mostrar Nome
        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("categoria");
            SqlConnection SqlCon = new SqlConnection();

            try
            {
                SqlCon.ConnectionString = Conexao.Cn;//Chamar link conexâo
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,//Receber a conexâo
                    CommandText = "spmostrar_categoria",//Recebe procedure
                    CommandType = CommandType.StoredProcedure//Tipo de comendo
                };//Estanciar
                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);//Guardar informações
                SqlDat.Fill(DtResultado);//Preencher da tabela
            }
            catch (Exception ex)
            {
                DtResultado = null;//Não mostra na tabela
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
                SqlCon.ConnectionString = Conexao.Cn;//Chamar link conexâo
                SqlCommand SqlCmd = new SqlCommand
                {
                    Connection = SqlCon,//Receber a conexâo
                    CommandText = "spbuscar_nome",//Recebe procedure
                    CommandType = CommandType.StoredProcedure//Tipo de comendo
                };//Estanciar

                //Procedure @descricao
                SqlParameter ParTextoBuscar = new SqlParameter
                {
                    ParameterName = "@testobuscar",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 50,
                    Value = Categoria.TextoBuscar
                };
                SqlCmd.Parameters.Add(ParTextoBuscar);

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);//Guardar informações
                SqlDat.Fill(DtResultado);//Preencher da tabela
            }
            catch (Exception ex)
            {
                DtResultado = null;//Não mostra na tabela
            }
            return DtResultado;
        }
    }
}