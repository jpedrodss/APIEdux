using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIEdux.Contexts;
using APIEdux.Domains;
using APIEdux.Repositories;
using Microsoft.EntityFrameworkCore;

namespace APIEdux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorTurmasController : ControllerBase
    {
        private readonly ProfessorTurmaRepository _professorTurmasRepository;
        public ProfessorTurmasController()
        {
            _professorTurmasRepository = new ProfessorTurmaRepository();
        }

        /// <summary>
        /// Lista todos itens do Objeto ProfessorTurma
        /// </summary>
        /// <returns>Lista ProfessorTurma</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var professorTurmas = _professorTurmasRepository.Listar();

                if (professorTurmas.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = professorTurmas.Count,
                    data = professorTurmas
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Envie um email para email@email.com informando que ocorreu um erro no endpoit Get/ProfessorTurma "
                });
            }
        }

        /// <summary>
        /// Procura um ProfessorTurma expecifico por ID
        /// </summary>
        /// <param name="id"> id de pesquisa </param>
        /// <returns> ProfessorTurma pesquisado </returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                ProfessorTurma professorTurma = _professorTurmasRepository.BuscarID(id);

                if (professorTurma == null)
                    return NotFound();

                return Ok(professorTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edita um ProfessorTurma
        /// </summary>
        /// <param name="id">ID para pesquisar o ProfessorTurma</param>
        /// <param name="professorTurma">ProfessorTurma para ser editado</param>
        /// <returns>Resultado da edição</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorTurma professorTurma)
        {
            try
            {
                var professorTurmaTemp = _professorTurmasRepository.BuscarID(id);

                if (professorTurmaTemp == null)
                    return NotFound();

                professorTurma.IdProfessorTurma = id;
                _professorTurmasRepository.Editar(professorTurma);

                return Ok(professorTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Adiciona um ProfessorTurma
        /// </summary>
        /// <param name="professorTurma">ProfessorTurma a ser adicionado</param>
        /// <returns>ProfessorTurma adicionado</returns>
        [HttpPost]
        public IActionResult Post(ProfessorTurma professorTurma)
        {
            try
            {
                _professorTurmasRepository.Adicionar(professorTurma);

                return Ok(professorTurma);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Exclui um ProfessorTurma
        /// </summary>
        /// <param name="id">ID do ProfessorTurma para ser excluido</param>
        /// <returns>Status code da ação</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _professorTurmasRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
