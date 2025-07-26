using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaDados;
using System.Data;

namespace CamadaNegocio
{
    class NCategoria
    {
        //Método Inserir
        public static string Incerir(string nome, string descricao)
        {
            DCategoria Obj = new CamadaDados.DCategoria();
            Obj.Nome = nome;
            Obj.Descricao = descricao;
            return Obj.Inserir(Obj);
        }

        //Método Editar
        public static string Editar(int idcategoria, string nome, string descricao)
        {
            DCategoria Obj = new CamadaDados.DCategoria();
            Obj.IdCategoria = idcategoria;
            Obj.Nome = nome;
            Obj.Descricao = descricao;
            return Obj.Editar(Obj);
        }

        //Método Deletar
        public static string Excluir(int idcategoria)
        {
            DCategoria Obj = new CamadaDados.DCategoria();
            Obj.IdCategoria = idcategoria;
            return Obj.Excluir(Obj);
        }

        //Método Mostrar
        public static DataTable Mostar()
        {
            return new DCategoria().Mostrar();
        }
    }
}
