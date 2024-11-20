namespace _PIM.Models
{
    public class ItemCarrinho
    {
        public int ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public decimal PrecoProduto { get; set; }
        public int Quantidade { get; set; }
        public string ImagemUrl { get; set; }
    }

}
