using System.ComponentModel.DataAnnotations;

namespace _PIM.Models
{
    public class PlantaModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome da Planta")]
        public string Nome { get; set; }

        [Display(Name = "Requisitos na Germinação")]
        public NecessidadePlanta Germinacao { get; set; }

        [Display(Name = "Requisitos no Crescimento Vegetativo")]
        public NecessidadePlanta Vegetativo { get; set; }

        [Display(Name = "Requisitos no Florescimento")]
        public NecessidadePlanta Florescimento { get; set; }
    }

    public class NecessidadePlanta
    {
        [Key]
        public int Id { get; set; }

        [Range(0, 100)]
        [Display(Name = "Umidade Mínima (%)")]
        public int MinHumidade { get; set; }

        [Range(0, 100)]
        [Display(Name = "Umidade Máxima (%)")]
        public int MaxHumidade { get; set; }

        [Range(0, 100)]
        [Display(Name = "Nutrientes Mínimos (ppm)")]
        public int MinNutrientes { get; set; }

        [Range(0, 100)]
        [Display(Name = "Nutrientes Máximos (ppm)")]
        public int MaxNutrientes { get; set; }
    }
}

