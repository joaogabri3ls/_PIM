namespace _PIM.Models
{
    public class ItemVenda
    {
        public int ItemVendaId { get; set; }
        public int VendaId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }

        public virtual Venda Venda { get; set; }
        public virtual ProdutoModel Produto { get; set; }
    }

}
