using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace _PIM.Models
{
    public class SensorModel
    {
        [Key]  // Define a chave primária
        public int Id { get; set; }
        [Display(Name = "Tipo de Sensor")]
        public string Tipo { get; set; }

        [Range(0, 100)]
        [Display(Name = "Valor")]
        public int Valor { get; set; }

        [Display(Name = "Unidade")]
        public string Unidade { get; set; }
    }
}
