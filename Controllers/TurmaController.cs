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
using APIEdux.Repositories;
using APIEdux.Interfaces;

namespace APIEdux.Controllers
{
    [Authorize(Roles = "Professor")]
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurma _turmaRepository;

        public TurmaController()
        {
            _turmaRepository = new TurmaRepository();
        }

        /// <summary>
        /// Lista todas as turmas.
        /// </summary>
        /// <returns>Lista das turmas cadastrados</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var turmas = _turmaRepository.Listar();

                if (turmas.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = turmas.Count,
                    data = turmas
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
        /// Procura uma Turma específico por ID
        /// </summary>
        /// <param name="id">ID de pesquisa</param>
        /// <returns>Turma pesquisada</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Turma turma = _turmaRepository.BuscarID(id);

                if (turma == null)
                    return NotFound();

                return Ok(turma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edita uma Turma
        /// </summary>
        /// <param name="id">ID para pesquisar a Turma</param>
        /// <param name="turma">Turma a ser editada</param>
        /// <returns>Resultado da edição</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Turma turma)
        {
            try
            {
                var turmaTemp = _turmaRepository.BuscarID(id);

                if (turmaTemp == null)
                    return NotFound();

                turma.IdTurma = id;
                _turmaRepository.Editar(turma);

                return Ok(turma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona uma turma
        /// </summary>
        /// <param name="turma">Turma a ser adicionada</param>
        /// <returns>Turma adicionada</returns>
        [HttpPost]
        public IActionResult Post(Turma turma)
        {
            try
            {
                _turmaRepository.Adicionar(turma);

                return Ok(turma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui uma turma
        /// </summary>
        /// <param name="id">ID da turma para ser excluida</param>
        /// <returns>Status code da ação</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _turmaRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
