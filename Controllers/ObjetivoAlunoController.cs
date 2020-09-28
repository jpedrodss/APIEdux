using APIEdux.Contexts;
using APIEdux.Domains;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Controllers
{
    [Authorize(Roles = "Professor")]
    [Route("api/[controller]")]
    [ApiController]


    public class ObjetivoAlunoController : ControllerBase
    {
        private EduxContext _context = new EduxContext();

        /// <summary>
        /// Lista todos os ObjetivoAluno
        /// </summary>
        /// <returns>Retorna os ObjetivoAluno cadastrados</returns>
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObjetivoAluno>>> GetObjetivoAluno()
        {
            return await _context.ObjetivoAluno.ToListAsync();
        }

        /// <summary>
        /// Procura um ObjetivoAluno especifico por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ObjetivoAluno pesquisado</returns>
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ObjetivoAluno>> GetObjetivoAluno(int id)
        {
            var ObjetivoAluno = await _context.ObjetivoAluno.FindAsync(id);

            if (ObjetivoAluno == null)
            {
                return NotFound();
            }

            return ObjetivoAluno;
        }

        /// <summary>
        /// Edita um ObjetivoAluno
        /// </summary>
        /// <param name="id">ID do ObjetivoAluno</param>
        /// <param name="objetivoAluno">AlunoTurma para ser editado</param>
        /// <returns></returns>
       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjetivoAluno(int id, ObjetivoAluno objetivoAluno)
        {
            if (id != objetivoAluno.IdObjetivoAluno)
            {
                return BadRequest();
            }

            _context.Entry(objetivoAluno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjetivoAlunoExists(id))
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
        /// Adiciona um ObjetivoAluno
        /// </summary>
        /// <param name="objetivoAluno">ObjetivoAluno a ser adicionado</param>
        /// <returns>ObjetivoAluno adicionado</returns>
        /// 
        [HttpPost]
        public async Task<ActionResult<Perfil>> PostObjetivoAluno(ObjetivoAluno objetivoAluno)
        {
            _context.ObjetivoAluno.Add(objetivoAluno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjetivoAluno", new { id = objetivoAluno.IdObjetivoAluno }, objetivoAluno);
        }

        /// <summary>
        /// Exclui um ObjetivoAluno
        /// </summary>
        /// <param name="id">ID do ObjetivoAluno para ser excluido</param>
        /// <returns>Status code da ação</returns>
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ObjetivoAluno>> DeleteObjetivoAluno(int id)
        {
            var objetivoAluno = await _context.ObjetivoAluno.FindAsync(id);
            if (objetivoAluno == null)
            {
                return NotFound();
            }

            _context.ObjetivoAluno.Remove(objetivoAluno);
            await _context.SaveChangesAsync();

            return objetivoAluno;
        }


        private bool ObjetivoAlunoExists(int id)
        {
            return _context.ObjetivoAluno.Any(e => e.IdObjetivoAluno == id);
        }
    }
}
