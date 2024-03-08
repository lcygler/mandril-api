using System.ComponentModel.DataAnnotations;

namespace MandrilAPI.Models;

public class MandrilInsert
{
  [Required(ErrorMessage = "El nombre es obligatorio.")]
  [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
  public string Nombre { get; set; } = string.Empty;

  [Required(ErrorMessage = "El apellido es obligatorio.")]
  [MaxLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres.")]
  public string Apellido { get; set; } = string.Empty;
}
