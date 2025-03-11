using Agenda.Shared.Model;
using API_Agenda.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace API_Agenda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<object>> GetUsuarios()
        {
            var stopwatch = Stopwatch.StartNew();
            var usuarios = await _context.Usuarios.ToListAsync();
            stopwatch.Stop();

            return Ok(new
            {
                data = usuarios,
                tiempoEjecucion = $"{stopwatch.ElapsedMilliseconds} ms"
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetUsuario(int id)
        {
            var stopwatch = Stopwatch.StartNew();
            var usuario = await _context.Usuarios.FindAsync(id);
            stopwatch.Stop();

            if (usuario == null)
            {
                return NotFound(new { mensaje = "Usuario no encontrado", tiempoEjecucion = $"{stopwatch.ElapsedMilliseconds} ms" });
            }

            return Ok(new
            {
                data = usuario,
                tiempoEjecucion = $"{stopwatch.ElapsedMilliseconds} ms"
            });
        }

        [HttpPost]
        public async Task<ActionResult<object>> CreateUsuario([FromBody] Usuario usuario)
        {
            var stopwatch = Stopwatch.StartNew();

            if (!ModelState.IsValid)
            {
                stopwatch.Stop();
                return BadRequest(new { errores = ModelState, tiempoEjecucion = $"{stopwatch.ElapsedMilliseconds} ms" });
            }

            var errores = new List<string>();
            bool emailExists = await _context.Usuarios.AnyAsync(u => u.Correo == usuario.Correo);
            bool phoneExists = await _context.Usuarios.AnyAsync(u => u.Telefono == usuario.Telefono);

            if (emailExists) errores.Add("El correo electrónico ya está en uso.");
            if (phoneExists) errores.Add("El número de teléfono ya está en uso.");

            if (errores.Count > 0)
            {
                stopwatch.Stop();
                return BadRequest(new { mensajes = errores, tiempoEjecucion = $"{stopwatch.ElapsedMilliseconds} ms" });
            }

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            stopwatch.Stop();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, new
            {
                data = usuario,
                tiempoEjecucion = $"{stopwatch.ElapsedMilliseconds} ms"
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] Usuario usuario)
        {
            var stopwatch = Stopwatch.StartNew();

            var usuarioExistente = await _context.Usuarios.FindAsync(id);
            if (usuarioExistente == null)
            {
                stopwatch.Stop();
                return NotFound(new { mensaje = "Usuario no encontrado", tiempoEjecucion = $"{stopwatch.ElapsedMilliseconds} ms" });
            }

            if (!string.IsNullOrEmpty(usuario.Correo) && usuario.Correo != usuarioExistente.Correo)
            {
                bool emailExists = await _context.Usuarios.AnyAsync(u => u.Correo == usuario.Correo);
                if (emailExists)
                {
                    stopwatch.Stop();
                    return BadRequest(new { mensaje = "El correo electrónico ya está en uso.", tiempoEjecucion = $"{stopwatch.ElapsedMilliseconds} ms" });
                }
            }

            if (!string.IsNullOrEmpty(usuario.Telefono) && usuario.Telefono != usuarioExistente.Telefono)
            {
                bool phoneExists = await _context.Usuarios.AnyAsync(u => u.Telefono == usuario.Telefono);
                if (phoneExists)
                {
                    stopwatch.Stop();
                    return BadRequest(new { mensaje = "El número de teléfono ya está en uso.", tiempoEjecucion = $"{stopwatch.ElapsedMilliseconds} ms" });
                }
            }

            usuarioExistente.Nombre = usuario.Nombre ?? usuarioExistente.Nombre;
            usuarioExistente.Correo = usuario.Correo ?? usuarioExistente.Correo;
            usuarioExistente.Telefono = usuario.Telefono ?? usuarioExistente.Telefono;
            usuarioExistente.Favorito = usuario.Favorito; 
            usuarioExistente.ListaNegra = usuario.ListaNegra; 

            _context.Entry(usuarioExistente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            stopwatch.Stop();

            return Ok(new
            {
                mensaje = "Usuario actualizado correctamente",
                data = usuarioExistente,
                tiempoEjecucion = $"{stopwatch.ElapsedMilliseconds} ms"
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var stopwatch = Stopwatch.StartNew();

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                stopwatch.Stop();
                return NotFound(new { mensaje = "Usuario no encontrado", tiempoEjecucion = $"{stopwatch.ElapsedMilliseconds} ms" });
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            stopwatch.Stop();

            return Ok(new
            {
                mensaje = "Usuario eliminado correctamente",
                tiempoEjecucion = $"{stopwatch.ElapsedMilliseconds} ms"
            });
        }
    }
}
