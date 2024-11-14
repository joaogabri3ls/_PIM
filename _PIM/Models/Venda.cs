namespace _PIM.Models
{
    using _PIM.Models;
    public class Venda
    {
        public int VendaId { get; set; }
        public string UserId { get; set; }
        public DateTime DataVenda { get; set; }
        public MetodoPagamento MetodoPagamento { get; set; }
        public StatusEnvio StatusEnvio { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }

        public ICollection<ItemVenda> ItensVenda { get; set; }
        public ApplicationUser User { get; set; }

        public decimal Total => ItensVenda?.Sum(item => item.PrecoUnitario * item.Quantidade) ?? 0;

    }

    public enum StatusEnvio
    {
        Pendente,
        Enviado
    }

}