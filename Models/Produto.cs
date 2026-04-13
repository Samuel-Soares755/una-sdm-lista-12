using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikeStoreApi.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public decimal Preco { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}