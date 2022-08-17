using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaWebDev.Dominio.Entidades
{
    public class Pedido
    {
        public Guid Id { get; private set; }
        public Guid ClienteId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public Cliente Cliente { get; private set; }
        public Produto Produto { get; private set; }
        public DateTime DataPedido { get; private set; }

        public Pedido(Guid id, Guid clienteId, Guid produtoId)
        {
            Id = id;
            ClienteId = clienteId;
            ProdutoId = produtoId;
            DataPedido = DateTime.UtcNow;
        }

        public Pedido(Guid clienteId, Guid produtoId)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
            DataPedido = DateTime.UtcNow;
        }

    }
}
