using System.ComponentModel.DataAnnotations;
using static MandrilAPI.Models.Habilidad;

namespace MandrilAPI.Models;

public class HabilidadInsert
{
  [Required(ErrorMessage = "El nombre es obligatorio.")]
  public string Nombre { get; set; } = string.Empty;

  [Required(ErrorMessage = "La potencia es obligatoria.")]
  public EPotencia Potencia { get; set; }
}
