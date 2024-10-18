using _PIM.Models;
using NuGet.Protocol.Plugins;
using System.Collections.Generic; // Para ICollection
using System.ComponentModel.DataAnnotations; // Para Data Annotations

public class Cultura
{
    [Key]
    public int CulturaId { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; } // Nome da cultura (Alface, Tomate ou Rúcula)

    public double UmidadeSoloIdeal { get; set; } // Umidade ideal do solo (%)

    public double NivelNutrientesIdeal { get; set; } // Nível ideal de nutrientes

    public ICollection<SensorModel> Sensores { get; set; } // Sensores associados a essa cultura
}
