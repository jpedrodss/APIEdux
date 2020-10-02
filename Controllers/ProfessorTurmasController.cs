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
    public class ProfessorTurmasController : ControllerBase
    {
        private readonly EduxContext _context;

        public ProfessorTurmasController(EduxContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lista todos itens do Objeto ProfessorTurma
        /// </summary>
        /// <returns>Lista ProfessorTurma</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessorTurma>>> GetProfessorTurma()
        {
            return await _context.ProfessorTurma.ToListAsync();
        }

        /// <summary>
        /// Procura um ProfessorTurma expecifico por ID
        /// </summary>
        /// <param name="id"> id de pesquisa </param>
        /// <returns> ProfessorTurma pesquisado </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessorTurma>> GetProfessorTurma(int id)
        {
            var professorTurma = await _context.ProfessorTurma.FindAsync(id);

            if (professorTurma == null)
            {
                return NotFound();
            }

            return professorTurma;
        }

        /// <summary>
        /// Edita um ProfessorTurma
        /// </summary>
        /// <param name="id">ID para pesquisar o ProfessorTurma</param>
        /// <param name="professorTurma">ProfessorTurma para ser editado</param>
        /// <returns>Resultado da edição</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProfessorTurma(int id, ProfessorTurma professorTurma)
        {
            if (id != professorTurma.IdProfessorTurma)
            {
                return BadRequest();
            }

            _context.Entry(professorTurma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorTurmaExists(id))
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
        /// Adiciona um ProfessorTurma
        /// </summary>
        /// <param name="professorTurma">ProfessorTurma a ser adicionado</param>
        /// <returns>ProfessorTurma adicionado</returns>
        [HttpPost]
        public async Task<ActionResult<ProfessorTurma>> PostProfessorTurma(ProfessorTurma professorTurma)
        {
            _context.ProfessorTurma.Add(professorTurma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProfessorTurma", new { id = professorTurma.IdProfessorTurma }, professorTurma);
        }

        /// <summary>
        /// Exclui um ProfessorTurma
        /// </summary>
        /// <param name="id">ID do ProfessorTurma para ser excluido</param>
        /// <returns>Status code da ação</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProfessorTurma>> DeleteProfessorTurma(int id)
        {
            var professorTurma = await _context.ProfessorTurma.FindAsync(id);
            if (professorTurma == null)
            {
                return NotFound();
            }

            _context.ProfessorTurma.Remove(professorTurma);
            await _context.SaveChangesAsync();

            return professorTurma;
        }

        private bool ProfessorTurmaExists(int id)
        {
            return _context.ProfessorTurma.Any(e => e.IdProfessorTurma == id);
        }
    }
}
