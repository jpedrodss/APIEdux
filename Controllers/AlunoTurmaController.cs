using System;
using Microsoft.AspNetCore.Mvc;
using APIEdux.Domains;
using Microsoft.AspNetCore.Authorization;
using APIEdux.Repositories;
using Microsoft.EntityFrameworkCore;

namespace APIEdux.Controllers
{
    [Authorize(Roles = "Professor")]
    [Route("api/[controller]")]
    [ApiController]

    public class AlunoTurmaController : ControllerBase
    {
        private readonly AlunoTurmaRepository _alunoTurmaRepository;

        public AlunoTurmaController()
        {
            _alunoTurmaRepository = new AlunoTurmaRepository();
        }

        /// <summary>
        /// Lista todos os AlunoTurma
        /// </summary>
        /// <returns> retorna todos os AlunoTurma cadastrados </returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var alunoTurmas = _alunoTurmaRepository.Listar();

                if (alunoTurmas.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = alunoTurmas.Count,
                    data = alunoTurmas
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Envie um email para email@email.com informando que ocorreu um erro no endpoit Get/AlunoTurma "
                });
            }
        }
        
        /// <summary>
        /// Procura um AlunoTurma expecifico por ID
        /// </summary>
        /// <param name="id"> id de pesquisa </param>
        /// <returns> AlunoTurma pesquisado </returns>
        [HttpGet("{id}")]
          public IActionResult Get(int id)
        {
            try
            {
                AlunoTurma alunoTurma = _alunoTurmaRepository.BuscarID(id);

                if (alunoTurma == null)
                    return NotFound();

                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edita um AlunoTurma
        /// </summary>
        /// <param name="id">ID para pesquisar o AlunoTurma</param>
        /// <param name="alunoTurma">AlunoTurma para ser editado</param>
        /// <returns>Resultado da edição</returns>
      
        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoTurma alunoTurma)
        {
           try
            {
                var alunoTurmaTemp = _alunoTurmaRepository.BuscarID(id);

                if (alunoTurmaTemp == null)
                    return NotFound();

                alunoTurma.IdAlunoTurma = id;
                _alunoTurmaRepository.Editar(alunoTurma);

                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um AlunoTurma
        /// </summary>
        /// <param name="alunoTurma">AlunoTurma a ser adicionado</param>
        /// <returns>AlunoTurma adicionado</returns>
        [HttpPost]
        public IActionResult Post (AlunoTurma alunoTurma)
        {
            try
            {
                _alunoTurmaRepository.Adicionar(alunoTurma);

                return Ok(alunoTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Exclui um AlunoTurma
        /// </summary>
        /// <param name="id">ID do AlunoTurma para ser excluido</param>
        /// <returns>Status code da ação</returns>
        [HttpDelete("{id}")]
       public IActionResult Delete(int id)
        {
            try
            {
                _alunoTurmaRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

