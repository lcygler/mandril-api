using MandrilAPI.Helpers;
using MandrilAPI.Models;
using MandrilAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace MandrilAPI.Controllers;

[ApiController]
[Route("api/mandril/{mandrilId}/[controller]")]
public class HabilidadController : ControllerBase
{
  // GET: api/mandril/{mandrilId}/habilidad
  [HttpGet]
  public ActionResult<IEnumerable<Habilidad>> GetHabilidades(int mandrilId)
  {
    var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

    if (mandril == null)
      return NotFound(Mensajes.Mandril.NotFound);

    return Ok(mandril.Habilidades);
  }

  // GET: api/mandril/{mandrilId}/habilidad/{habilidadId}
  [HttpGet("{habilidadId}")]
  public ActionResult<Habilidad> GetHabilidad(int mandrilId, int habilidadId)
  {
    var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

    if (mandril == null)
      return NotFound(Mensajes.Mandril.NotFound);

    var habilidad = mandril.Habilidades?.FirstOrDefault(h => h.Id == habilidadId);

    if (habilidad == null)
      return NotFound(Mensajes.Habilidad.NotFound);

    return Ok(habilidad);
  }

  // POST: api/mandril/{mandrilId}/habilidad
  [HttpPost]
  public ActionResult<Habilidad> PostHabilidad(int mandrilId, HabilidadInsert habilidadInsert)
  {
    var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

    if (mandril == null)
      return NotFound(Mensajes.Mandril.NotFound);

    var habilidadExistente = mandril.Habilidades?.FirstOrDefault(h => h.Nombre == habilidadInsert.Nombre);

    if (habilidadExistente != null)
      return BadRequest(Mensajes.Habilidad.NombreExistente);

    var maxHabilidad = mandril.Habilidades?.Max(h => h.Id) ?? 0;

    var habilidadNueva = new Habilidad()
    {
      Id = maxHabilidad + 1,
      Nombre = habilidadInsert.Nombre,
      Potencia = habilidadInsert.Potencia
    };

    mandril.Habilidades?.Add(habilidadNueva);

    return CreatedAtAction(nameof(GetHabilidad),
        new { mandrilId = mandrilId, habilidadId = habilidadNueva.Id },
        habilidadNueva
    );

  }

  // PUT: api/mandril/{mandrilId}/habilidad/{habilidadId}
  [HttpPut("{habilidadId}")]
  public ActionResult<Habilidad> PutHabilidad(int mandrilId, int habilidadId, HabilidadInsert habilidadInsert)
  {
    // Validaciones
    var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

    if (mandril == null)
      return NotFound(Mensajes.Mandril.NotFound);

    var habilidadExistente = mandril.Habilidades?.FirstOrDefault(h => h.Id == habilidadId);

    if (habilidadExistente == null)
      return NotFound(Mensajes.Habilidad.NotFound);

    var habilidadMismoNombre = mandril.Habilidades?
        .FirstOrDefault(h => h.Id != habilidadId && h.Nombre == habilidadInsert.Nombre);

    if (habilidadMismoNombre != null)
      return BadRequest(Mensajes.Habilidad.NombreExistente);

    // Asignacion
    habilidadExistente.Nombre = habilidadInsert.Nombre;
    habilidadExistente.Potencia = habilidadInsert.Potencia;

    return NoContent();
  }

  // DELETE: api/mandril/{mandrilId}/habilidad/{habilidadId}
  [HttpDelete("{habilidadId}")]
  public ActionResult<Habilidad> DeleteHabilidad(int mandrilId, int habilidadId)
  {
    // Validaciones
    var mandril = MandrilDataStore.Current.Mandriles.FirstOrDefault(x => x.Id == mandrilId);

    if (mandril == null)
      return NotFound(Mensajes.Mandril.NotFound);

    var habilidadExistente = mandril.Habilidades?.FirstOrDefault(h => h.Id == habilidadId);

    if (habilidadExistente == null)
      return NotFound(Mensajes.Habilidad.NotFound);

    // Eliminacion
    mandril.Habilidades?.Remove(habilidadExistente);

    return NoContent();
  }
}
