using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaWebDev.Dominio.Entidades
{
    public class Categoria
    {
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public int Codigo { get; set; }
        public ICollection<Produto> Produtos { get; set; }

        public Categoria(Guid id, string descricao, int codigo)
        {
            Id = id;
            Descricao = descricao;
            Codigo = codigo;
        }

        public Categoria(string descricao, int codigo)
        {
            Descricao = descricao;
            Codigo = codigo;
        }
    }
}
