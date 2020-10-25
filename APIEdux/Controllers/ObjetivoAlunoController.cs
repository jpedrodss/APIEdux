using APIEdux.Domains;
using APIEdux.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;

namespace APIEdux.Controllers
{
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
        /// Edita um ObjetivoAluno
        /// </summary>
        /// <param name="id">ID do ObjetivoAluno</param>
        /// <param name="objetivoAluno">AlunoTurma para ser editado</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, ObjetivoAluno objetivoAluno)
        {
            try
            {
                var objetivoAlunoTemp = _objetivoAlunoRepository.BuscarID(id);

                if (objetivoAlunoTemp == null)
                    return NotFound();

                objetivoAluno.IdObjetivo = id;
                _objetivoAlunoRepository.Editar(objetivoAluno);

                return Ok(objetivoAluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Procura um ObjetivoAluno especifico por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objetivo pesquisado</returns>
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
        /// Adiciona um ObjetivoAluno
        /// </summary>
        /// <param name="objetivoAluno">ObjetivoAluno a ser adicionado</param>
        /// <returns>ObjetivoAluno adicionado</returns>
        /// 
        [HttpPost]
        public IActionResult Post(ObjetivoAluno objetivoAluno)
        {
            try
            {
                _objetivoAlunoRepository.Adicionar(objetivoAluno);

                return Ok(objetivoAluno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um ObjetivoAluno
        /// </summary>
        /// <param name="id">ID do ObjetivoAluno para ser excluido</param>
        /// <returns>Status code da ação</returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _objetivoAlunoRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
