using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _PIM.Models
{
    public class Venda
    {
        public int Id { get; set; }

        public string ClienteId { get; set; }  // Relacionamento com o usuário (ApplicationUser)
        public ApplicationUser Cliente { get; set; }  // O usuário (cliente) que fez a compra

        public DateTime DataVenda { get; set; }

        public List<ItemVenda> Itens { get; set; }  // Itens da venda

        public decimal Total { get; set; }  // Total da venda (pode ser calculado na hora da venda)
    }
}
