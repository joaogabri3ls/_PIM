using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace _PIM.Models
{
    public class SensorModel
    {
    [Key]
    public int SensorId { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; }
    [Required]
    [StringLength(50)]
    public string TipoSensor { get; set; } 

    [Required]
    public int CulturaId { get; set; } 

    [ForeignKey("CulturaId")]
    public Cultura Cultura { get; set; } 

    [Required]
    public double Valor { get; set; } 

    [Required]
    public DateTime UltimaLeitura { get; set; } 
}
}
