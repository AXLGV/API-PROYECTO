using Microsoft.AspNetCore.Mvc;

namespace MiProyecto.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecordatoriosController : ControllerBase
    {
        // Lista temporal en memoria (simula una base de datos)
        // Cuando conecten una base de datos real, esto se reemplaza
        private static List<Recordatorio> _recordatorios = new List<Recordatorio>
        {
            new Recordatorio { Id = 1, Titulo = "Comprar leche", Descripcion = "Ir al súper por la tarde", Fecha = DateTime.Now.AddDays(1) },
            new Recordatorio { Id = 2, Titulo = "Entregar tarea", Descripcion = "Actividad de APIs", Fecha = DateTime.Now.AddDays(2) }
        };

        // GET: api/recordatorios
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            return Ok(_recordatorios);
        }

        // POST: api/recordatorios
        [HttpPost]
        public IActionResult Crear([FromBody] Recordatorio nuevoRecordatorio)
        {
            nuevoRecordatorio.Id = _recordatorios.Count > 0
                ? _recordatorios.Max(r => r.Id) + 1
                : 1;

            _recordatorios.Add(nuevoRecordatorio);

            return Ok(new
            {
                mensaje = "Recordatorio creado exitosamente",
                recordatorio = nuevoRecordatorio
            });
        }
    }

    public class Recordatorio
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
    }
}