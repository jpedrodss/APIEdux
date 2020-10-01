using APIEdux.Contexts;
using APIEdux.Domains;
using APIEdux.Repositories;
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
        private readonly ObjetivoAlunoRepository _objetivoAlunoRepository;
        public ObjetivoAlunoController()
        {
            _objetivoAlunoRepository = new ObjetivoAlunoRepository();
        }

        /// <summary>
        /// Lista todos os ObjetivoAluno
        /// </summary>
        /// <returns>Retorna os ObjetivoAluno cadastrados</returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var objetivoAlunos = _objetivoAlunoRepository.Listar();

                if (objetivoAlunos.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = objetivoAlunos.Count,
                    data = objetivoAlunos
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Envie um email para email@email.com informando que ocorreu um erro no endpoint Get/Usuarios"
                });
            }
        }

        /// <summary>
        /// Procura um ObjetivoAluno especifico por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ObjetivoAluno pesquisado</returns>

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                ObjetivoAluno objetivoAluno = _objetivoAlunoRepository.BuscarID(id);

                if (objetivoAluno == null)
                    return NotFound();

                return Ok(objetivoAluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Edita um ObjetivoAluno
        /// </summary>
        /// <param name="id">ID do ObjetivoAluno</param>
        /// <param name="objetivoAluno">AlunoTurma para ser editado</param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                ObjetivoAluno objetivoAluno = _objetivoAlunoRepository.BuscarID(id);

                if (perfil == null)
                    return NotFound();

                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um ObjetivoAluno
        /// </summary>
        /// <param name="objetivoAluno">ObjetivoAluno a ser adicionado</param>
        /// <returns>ObjetivoAluno adicionado</returns>
        /// 
        [HttpPost]
        

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
