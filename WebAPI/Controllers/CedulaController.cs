using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dominio;
using Persistencia;
using System.Text.Json;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CedulaController : ControllerBase
    {
        private readonly pruebaContext _context;

        public CedulaController(pruebaContext context)
        {
            _context = context;
        }

        // GET: api/Cedula
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cedulado>>> GetCedulados()
        {
            return await _context.Cedulados.ToListAsync();
        }

        // GET: api/Cedula/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cedulado>> GetCedulado(int id)
        {
            var cedulado = await _context.Cedulados.FindAsync(id);

            if (cedulado == null)
            {
                return NotFound();
            }

            return cedulado;
        }

        // PUT: api/Cedula/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCedulado(int id, Cedulado cedulado)
        {
            if (id != cedulado.NumeroCedula)
            {
                cedulado.NumeroCedula = id;
            }

            _context.Entry(cedulado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CeduladoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Cedula
        
        [HttpPost]
        public async Task<ActionResult<Cedulado>> PostCedulado(Cedulado cedulado)
        {
            _context.Cedulados.Add(cedulado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CeduladoExists(cedulado.NumeroCedula))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCedulado", new { id = cedulado.NumeroCedula }, cedulado);
        }

        // DELETE: api/Cedula/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCedulado(int id)
        {
            var cedulado = await _context.Cedulados.FindAsync(id);
            if (cedulado == null)
            {
                return NotFound();
            }

            _context.Cedulados.Remove(cedulado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CeduladoExists(int id)
        {
            return _context.Cedulados.Any(e => e.NumeroCedula == id);
        }
    }
}
