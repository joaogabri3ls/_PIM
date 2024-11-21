namespace _PIM.Models
{
    public class ItemVenda
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }  // Relacionamento com Produto
        public ProdutoModel Produto { get; set; }  // O produto que foi comprado

        public int Quantidade { get; set; }  // Quantidade do produto na venda
        public decimal PrecoUnitario { get; set; }  // Preço do produto na venda
        public decimal SubTotal => PrecoUnitario * Quantidade;  // Calcula o subtotal do item

        public int VendaId { get; set; }  // Relacionamento com a venda
        public Venda Venda { get; set; }  // A venda a que o item pertence
    }
}
