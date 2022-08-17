using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaWebDev.Dominio.Entidades
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Documento { get; private set; }
        public string Email { get; private set; }
        public ICollection<Pedido> Pedidos { get; private set; }

        public Cliente(Guid id, string nome, string documento, string email)
        {
            Id = id;
            Nome = nome;
            Documento = documento;
            Email = email;
        }

        public Cliente(string nome, string documento, string email)
        {
            Nome = nome;
            Documento = documento;
            Email = email;
        }
    }
}
