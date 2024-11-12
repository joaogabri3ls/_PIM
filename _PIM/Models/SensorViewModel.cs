using System;
using System.ComponentModel.DataAnnotations;
using _PIM.Models;

namespace _PIM.Models
{
    public class SensorViewModel
    {
        [Key]  // Define a chave primária
        public int Id { get; set; }
        public PlantaModel Planta { get; set; }
        public string Fase { get; set; }
        public SensorModel DadosSensorHumidade { get; set; }
        public SensorModel DadosSensorNutrientes { get; set; }
    }
}
