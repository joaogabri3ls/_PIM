using System.ComponentModel.DataAnnotations;

namespace _PIM.Models
{
    public class ProdutoModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        [Display(Name = "Nome do Produto")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O preço do produto é obrigatório.")]
        [Range(0.01, 99999.99, ErrorMessage = "O preço deve ser maior que zero e no máximo R$ 99.999,99.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Preço do Produto")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "A quantidade do produto em estoque é obrigatória.")]
        [Range(0, 50, ErrorMessage = "A quantidade deve estar entre 0 e 1000.")]
        [Display(Name = "Quantidade em Estoque")]
        public int Quantity { get; set; }

        [Display(Name = "Imagem do Produto")]
        public string? UrlImagem { get; set; }

        [Required(ErrorMessage = "A categoria do produto é obrigatória.")]
        [StringLength(50, ErrorMessage = "A categoria deve ter no máximo 50 caracteres.")]
        [Display(Name = "Categoria do Produto")]
        public string? Categoria { get; set; }

        [DataType(DataType.Date)] // Define que este campo será tratado como uma data
        [Display(Name = "Data de Criação")]
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
