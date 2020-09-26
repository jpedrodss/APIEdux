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


    public class ObjetivoController : ControllerBase
    {
        private EduxContext _context = new EduxContext();

        /// <summary>
        /// Lista todos os Objetivos
        /// </summary>
        /// <returns>Retorna os Objetivos cadastrados</returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objetivo>>> GetObjetivo()
        {
            return await _context.Objetivo.ToListAsync();
        }

        /// <summary>
        /// Procura um Objetivo especifico por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objetivo pesquisado</returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<Objetivo>> GetObjetivo(int id)
        {
            var Objetivo = await _context.Objetivo.FindAsync(id);

            if (Objetivo == null)
            {
                return NotFound();
            }

            return Objetivo;
        }

        /// <summary>
        /// Edita um Objetivo
        /// </summary>
        /// <param name="id">ID do Objetivo</param>
        /// <param name="objetivo">Objetivo para ser editado</param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjetivo(int id, Objetivo objetivo)
        {
            if (id != objetivo.IdObjetivo)
            {
                return BadRequest();
            }

            _context.Entry(objetivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjetivoExists(id))
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
        /// Adiciona um Objetivo
        /// </summary>
        /// <param name="objetivo">Objetivo a ser adicionado</param>
        /// <returns>Objetivo adicionado</returns>
        /// 
        [HttpPost]
        public async Task<ActionResult<Perfil>> PostObjetivo(Objetivo objetivo)
        {
            _context.Objetivo.Add(objetivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjetivo", new { id = objetivo.IdObjetivo}, objetivo);
        }

        /// <summary>
        /// Exclui um Objetivo
        /// </summary>
        /// <param name="id">ID do Objetivo para ser excluido</param>
        /// <returns>Status code da ação</returns>

        [HttpDelete("{id}")]
        public async Task<ActionResult<Objetivo>> DeleteObjetivo(int id)
        {
            var objetivo = await _context.Objetivo.FindAsync(id);
            if (objetivo == null)
            {
                return NotFound();
            }

            _context.Objetivo.Remove(objetivo);
            await _context.SaveChangesAsync();

            return objetivo;
        }


        private bool ObjetivoExists(int id)
        {
            return _context.Objetivo.Any(e => e.IdObjetivo == id);
        }
    }
}