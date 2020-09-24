using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIEdux.Contexts;
using APIEdux.Domains;
using Microsoft.AspNetCore.Authorization;

namespace APIEdux.Controllers
{
    [Authorize(Roles = "Professor")]
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private EduxContext _context = new EduxContext();

        /// <summary>
        /// Lista todas as turmas.
        /// </summary>
        /// <returns>Lista das turmas cadastrados</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Turma>>> GetTurma()
        {
            return await _context.Turma.ToListAsync();
        }

        /// <summary>
        /// Procura uma Turma específico por ID
        /// </summary>
        /// <param name="id">ID de pesquisa</param>
        /// <returns>Turma pesquisada</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Turma>> GetTurma(int id)
        {
            var turma = await _context.Turma.FindAsync(id);

            if (turma == null)
            {
                return NotFound();
            }

            return turma;
        }

        /// <summary>
        /// Edita uma Turma
        /// </summary>
        /// <param name="id">ID para pesquisar a Turma</param>
        /// <param name="turma">Turma a ser editada</param>
        /// <returns>Resultado da edição</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurma(int id, Turma turma)
        {
            if (id != turma.IdTurma)
            {
                return BadRequest();
            }

            _context.Entry(turma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurmaExists(id))
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
        /// Adiciona um perfil
        /// </summary>
        /// <param name="turma">Turma a ser adicionada</param>
        /// <returns>Turma adicionada</returns>
        [HttpPost]
        public async Task<ActionResult<Turma>> PostTurma(Turma turma)
        {
            _context.Turma.Add(turma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTurma", new { id = turma.IdTurma }, turma);
        }

        /// <summary>
        /// Exclui uma turma
        /// </summary>
        /// <param name="id">ID da turma para ser excluida</param>
        /// <returns>Status code da ação</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Turma>> DeleteTurma(int id)
        {
            var turma = await _context.Turma.FindAsync(id);
            if (turma == null)
            {
                return NotFound();
            }

            _context.Turma.Remove(turma);
            await _context.SaveChangesAsync();

            return turma;
        }

        private bool TurmaExists(int id)
        {
            return _context.Turma.Any(e => e.IdTurma == id);
        }
    }
}
