using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NikeStoreApi.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
    }
}