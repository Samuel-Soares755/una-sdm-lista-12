using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikeStoreApi.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int ClienteId { get; set; }
        public DateTime DataPedido { get; set; }
        public int QuantidadeItens { get; set; }
    }
}