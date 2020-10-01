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
        private EduxContext _context = new EduxContext();

        /// <summary>
        /// Lista todos itens do Objeto Curtida
        /// </summary>
        /// <returns>Lista Curtida</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curtida>>> GetCurtida()
        {
            return await _context.Curtida.ToListAsync();
        }

        /// <summary>
        /// Busca Objeto curtida por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Busca curtida por id</returns>
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

        /// <summary>
        /// Edita Itens do Objeto Curtida
        /// </summary>
        /// <param name="id"></param>
        /// <param name="curtida"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Adiciona Objeto Curtida
        /// </summary>
        /// <param name="curtida"></param>
        /// <returns>Adiciona Curtida</returns>
[HttpPost]
        public async Task<ActionResult<Curtida>> PostCurtida(Curtida curtida)
        {
            _context.Curtida.Add(curtida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCurtida", new { id = curtida.IdCurtida }, curtida);
        }

        /// <summary>
        /// Exclui Objeto Curtida
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Exclui Curtida</returns>
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
