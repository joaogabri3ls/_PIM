using _PIM.Models;
using NuGet.Protocol.Plugins;
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations; 

public class Cultura
{
    [Key]
    public int CulturaId { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } 

    public double UmidadeSoloIdeal { get; set; } 

    public double NivelNutrientesIdeal { get; set; } 

    public ICollection<SensorModel> Sensores { get; set; }
}
