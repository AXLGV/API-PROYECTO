using Microsoft.AspNetCore.Mvc;

namespace MiProyecto.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Aquí iría tu lógica real de validación (base de datos, etc.)
            if (request.Usuario == "admin" && request.Password == "1234")
            {
                return Ok(new { mensaje = "Login exitoso", token = "token-de-ejemplo" });
            }

            return Unauthorized(new { mensaje = "Credenciales incorrectas" });
        }
    }

    public class LoginRequest
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}