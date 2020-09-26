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

    public class AlunoTurmaController : ControllerBase
    {
        private EduxContext _context = new EduxContext();

        /// <summary>
        /// Lista todos os AlunoTurma
        /// </summary>
        /// <returns> retorna todos os AlunoTurma cadastrados </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlunoTurma>>> GetAlunoTurma()
        {
            return await _context.AlunoTurma.ToListAsync();
        }
        
        /// <summary>
        /// Procura um AlunoTurma expecifico por ID
        /// </summary>
        /// <param name="id"> id de pesquisa </param>
        /// <returns> AlunoTurma pesquisado </returns>
        [HttpGet("{id}")]
          public async Task<ActionResult<AlunoTurma>> GetAlunoTurma(int id)
        {
            var AlunoTurma = await _context.AlunoTurma.FindAsync(id);

            if (AlunoTurma == null)
            {
                return NotFound();
            }

            return AlunoTurma;
        }

        /// <summary>
        /// Edita um AlunoTurma
        /// </summary>
        /// <param name="id">ID para pesquisar o perfil</param>
        /// <param name="alunoTurma">AlunoTurma para ser editado</param>
        /// <returns>Resultado da edição</returns>
        /// 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlunoTurma(int id, AlunoTurma alunoTurma)
        {
            if (id != alunoTurma.IdAlunoTurma)
            {
                return BadRequest();
            }

            _context.Entry(alunoTurma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlunoTurmaExists(id))
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
        /// <param name="alunoTurma">AlunoTurma a ser adicionado</param>
        /// <returns>AlunoTurma adicionado</returns>
        [HttpPost]
        public async Task<ActionResult<Perfil>> PostAlunoTurma(AlunoTurma alunoTurma)
        {
            _context.AlunoTurma.Add(alunoTurma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlunoTurma", new { id = alunoTurma.IdAlunoTurma }, alunoTurma);
        }
        /// <summary>
        /// Exclui um AlunoTurma
        /// </summary>
        /// <param name="id">ID do AlunoTurma para ser excluido</param>
        /// <returns>Status code da ação</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<AlunoTurma>> DeleteAlunoTurma(int id)
        {
            var alunoTurma = await _context.AlunoTurma.FindAsync(id);
            if (alunoTurma == null)
            {
                return NotFound();
            }

            _context.AlunoTurma.Remove(alunoTurma);
            await _context.SaveChangesAsync();

            return alunoTurma;
        }


        private bool AlunoTurmaExists(int id)
        {
            return _context.AlunoTurma.Any(e => e.IdAlunoTurma == id);
        }
    }
}

