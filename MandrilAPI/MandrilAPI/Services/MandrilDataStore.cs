using MandrilAPI.Models;

namespace MandrilAPI.Services;

public class MandrilDataStore
{
  public List<Mandril> Mandriles { get; set; }

  public static MandrilDataStore Current { get; } = new MandrilDataStore();

  public MandrilDataStore()
  {
    Mandriles = new List<Mandril>() {
            new Mandril() {
                Id = 1,
                Nombre = "Mini Mandril",
                Apellido = "Fulano",
                Habilidades = new List<Habilidad>() {
                    new Habilidad() {
                        Id = 1,
                        Nombre = "Saltar",
                        Potencia = Habilidad.EPotencia.Moderado
                    }
                }
            },
            new Mandril() {
                Id = 2,
                Nombre = "Super Mandril",
                Apellido = "Mengano",
                Habilidades = new List<Habilidad>() {
                    new Habilidad() {
                        Id = 1,
                        Nombre = "Saltar",
                        Potencia = Habilidad.EPotencia.Moderado
                    },
                    new Habilidad() {
                        Id = 2,
                        Nombre = "Caminar",
                        Potencia = Habilidad.EPotencia.Intenso
                    },
                    new Habilidad() {
                        Id = 3,
                        Nombre = "Gritar",
                        Potencia = Habilidad.EPotencia.Potente
                    }
                }
            },
            new Mandril() {
                Id = 3,
                Nombre = "Mega Mandril",
                Apellido = "Legrand",
                Habilidades = new List<Habilidad>() {
                    new Habilidad() {
                        Id = 1,
                        Nombre = "Nadar",
                        Potencia = Habilidad.EPotencia.Intenso
                    },
                    new Habilidad() {
                        Id = 2,
                        Nombre = "Correr",
                        Potencia = Habilidad.EPotencia.Extremo
                    },
                    new Habilidad() {
                        Id = 3,
                        Nombre = "Trepar",
                        Potencia = Habilidad.EPotencia.Potente
                    }
                }
            }
        };
  }
}
