using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIEdux.Contexts;
using APIEdux.Domains;
using Microsoft.EntityFrameworkCore;

namespace APIEdux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicasController : ControllerBase
    {
        private EduxContext _context = new EduxContext();

        /// <summary>
        /// Lista todos itens do Objeto Dicas
        /// </summary>
        /// <returns>Dica Categoria</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dica>>> GetDica()
        {
            return await _context.Dica.ToListAsync();
        }

        /// <summary>
        /// Busca Objeto Dica por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Dica Buscada</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Dica>> GetDica(int id)
        {
            var dica = await _context.Dica.FindAsync(id);

            if (dica == null)
            {
                return NotFound();
            }

            return dica;
        }

        /// <summary>
        /// Edita Objeto dica
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dica"></param>
        /// <returns>Itens dica a serem editados</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDica(int id, Dica dica)
        {
            if (id != dica.IdDica)
            {
                return BadRequest();
            }

            _context.Entry(dica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DicaExists(id))
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
        /// Adiciona Objeto Dica
        /// </summary>
        /// <param name="dica"></param>
        /// <returns>Objeto dica a ser adicionado</returns>
        [HttpPost]
        public async Task<ActionResult<Dica>> PostDica(Dica dica)
        {
            _context.Dica.Add(dica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDica", new { id = dica.IdDica }, dica);
        }
        /// <summary>
        /// Exclui Objeto Dica
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto dica a ser Excluido</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dica>> DeleteDica(int id)
        {
            var dica = await _context.Dica.FindAsync(id);
            if (dica == null)
            {
                return NotFound();
            }

            _context.Dica.Remove(dica);
            await _context.SaveChangesAsync();

            return dica;
        }

        private bool DicaExists(int id)
        {
            return _context.Dica.Any(e => e.IdDica == id);
        }
    }
}
