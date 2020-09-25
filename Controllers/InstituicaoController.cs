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
    public class InstituicaoController : ControllerBase
    {
        private readonly EduxContext _context;

        public InstituicaoController(EduxContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista intens do Objeto Instituição 
        /// </summary>
        /// <returns>Lista Instituições</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Instituicao>>> GetInstituicao()
        {
            return await _context.Instituicao.ToListAsync();
        }

        /// <summary>
        /// Busca Objeto Instituição por id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Instituição</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Instituicao>> GetInstituicao(int id)
        {
            var instituicao = await _context.Instituicao.FindAsync(id);

            if (instituicao == null)
            {
                return NotFound();
            }

            return instituicao;
        }

        /// <summary>
        /// Edita itens do objeto instituição
        /// </summary>
        /// <param name="id"></param>
        /// <param name="instituicao"></param>
        /// <returns>Edição Instituição</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstituicao(int id, Instituicao instituicao)
        {
            if (id != instituicao.IdInstituicao)
            {
                return BadRequest();
            }

            _context.Entry(instituicao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstituicaoExists(id))
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
        /// Adiciona Itens no objeto Instituição
        /// </summary>
        /// <param name="instituicao"></param>
        /// <returns>Adicionarintens no objeto instituição</returns>
        [HttpPost]
        public async Task<ActionResult<Instituicao>> PostInstituicao(Instituicao instituicao)
        {
            _context.Instituicao.Add(instituicao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstituicao", new { id = instituicao.IdInstituicao }, instituicao);
        }

        /// <summary>
        /// Remove Objeto Curso
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Remove Objeto Curso</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Instituicao>> DeleteInstituicao(int id)
        {
            var instituicao = await _context.Instituicao.FindAsync(id);
            if (instituicao == null)
            {
                return NotFound();
            }

            _context.Instituicao.Remove(instituicao);
            await _context.SaveChangesAsync();

            return instituicao;
        }

        private bool InstituicaoExists(int id)
        {
            return _context.Instituicao.Any(e => e.IdInstituicao == id);
        }
    }
}
