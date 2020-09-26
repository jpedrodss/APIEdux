using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIEdux.Contexts;
using APIEdux.Domains;

namespace APIEdux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtidaController : ControllerBase
    {
        private readonly EduxContext _context;

        public CurtidaController(EduxContext context)
        {
            _context = context;
        }

        // GET: api/Curtida
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curtida>>> GetCurtida()
        {
            return await _context.Curtida.ToListAsync();
        }

        // GET: api/Curtida/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Curtida>> GetCurtida(int id)
        {
            var curtida = await _context.Curtida.FindAsync(id);

            if (curtida == null)
            {
                return NotFound();
            }

            return curtida;
        }

        // PUT: api/Curtida/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurtida(int id, Curtida curtida)
        {
            if (id != curtida.IdCurtida)
            {
                return BadRequest();
            }

            _context.Entry(curtida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurtidaExists(id))
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

        // POST: api/Curtida
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Curtida>> PostCurtida(Curtida curtida)
        {
            _context.Curtida.Add(curtida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurtida", new { id = curtida.IdCurtida }, curtida);
        }

        // DELETE: api/Curtida/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Curtida>> DeleteCurtida(int id)
        {
            var curtida = await _context.Curtida.FindAsync(id);
            if (curtida == null)
            {
                return NotFound();
            }

            _context.Curtida.Remove(curtida);
            await _context.SaveChangesAsync();

            return curtida;
        }

        private bool CurtidaExists(int id)
        {
            return _context.Curtida.Any(e => e.IdCurtida == id);
        }
    }
}
