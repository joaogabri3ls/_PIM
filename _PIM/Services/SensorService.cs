using _PIM.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _PIM.Services
{
    public class ServicoSensor
    {
        private readonly Random _random = new Random();
        private readonly List<PlantaModel> _plantas;

        public ServicoSensor()
        {
            _plantas = InicializarPlantas();
        }

        public List<PlantaModel> ObterPlantas()
        {
            return _plantas;
        }

        public SensorModel ObterDadosSensorHumidade(PlantaModel planta, FasePlantaModel fase)
        {
            var necessidades = ObterNecessidadesFase(planta, fase);
            int valor = _random.Next(necessidades.MinHumidade, necessidades.MaxHumidade);

            return new SensorModel
            {
                Tipo = "Umidade",
                Valor = valor,
                Unidade = "%"
            };
        }

        public SensorModel ObterDadosSensorNutrientes(PlantaModel planta, FasePlantaModel fase)
        {
            var necessidades = ObterNecessidadesFase(planta, fase);
            int valor = _random.Next(necessidades.MinNutrientes, necessidades.MaxNutrientes);

            return new SensorModel
            {
                Tipo = "Nutrientes",
                Valor = valor,
                Unidade = "ppm"
            };
        }

        private NecessidadePlanta ObterNecessidadesFase(PlantaModel planta, FasePlantaModel fase)
        {
            return fase switch
            {
                FasePlantaModel.Germinacao => planta.Germinacao,
                FasePlantaModel.CrescimentoVegetativo => planta.Vegetativo,
                FasePlantaModel.Florescimento => planta.Florescimento,
                _ => throw new ArgumentOutOfRangeException(nameof(fase), fase, null)
            };
        }

        private List<PlantaModel> InicializarPlantas()
        {
            return new List<PlantaModel>
            {
                new PlantaModel
                {
                    Nome = "Tomate",
                    Germinacao = new NecessidadePlanta { MinHumidade = 70, MaxHumidade = 90, MinNutrientes = 10, MaxNutrientes = 20 },
                    Vegetativo = new NecessidadePlanta { MinHumidade = 60, MaxHumidade = 75, MinNutrientes = 30, MaxNutrientes = 50 },
                    Florescimento = new NecessidadePlanta { MinHumidade = 50, MaxHumidade = 65, MinNutrientes = 40, MaxNutrientes = 70 }
                },
                new PlantaModel
                {
                    Nome = "Alface",
                    Germinacao = new NecessidadePlanta { MinHumidade = 80, MaxHumidade = 95, MinNutrientes = 10, MaxNutrientes = 15 },
                    Vegetativo = new NecessidadePlanta { MinHumidade = 70, MaxHumidade = 85, MinNutrientes = 20, MaxNutrientes = 30 },
                    Florescimento = new NecessidadePlanta { MinHumidade = 60, MaxHumidade = 75, MinNutrientes = 30, MaxNutrientes = 50 }
                },
                // Adicione outras plantas com dados semelhantes
            };
        }
    }
}
