using System;
using Microsoft.AspNetCore.Mvc;
using APIEdux.Domains;
using APIEdux.Repositories;
using Microsoft.EntityFrameworkCore;

namespace APIEdux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {

        private readonly CursoRepository _cursoRepository;

        public CursoController()
        {
            _cursoRepository = new CursoRepository();
        }

        /// <summary>
        /// Lista todos itens do Objeto Curso
        /// </summary>
        /// <returns>Lista Curso</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var cursos = _cursoRepository.Listar();

                if (cursos.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = cursos.Count,
                    data = cursos
                });
            }
            catch (Exception ex)
            {
                return BadRequest();
               
            }
        }

        /// <summary>
        /// Busca Objeto curso por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Busca curso por id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Curso curso = _cursoRepository.BuscarID(id);

                if (curso == null)
                    return NotFound();

                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Edita Itens do Objeto Curso
        /// </summary>
        /// <param name="id"></param>
        /// <param name="curso"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Curso curso)
        {
            try
            {
                var cursoTemp = _cursoRepository.BuscarID(id);

                if (cursoTemp == null)
                    return NotFound();

                curso.IdCurso = id;
                _cursoRepository.Editar(curso);

                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona Objeto Curso
        /// </summary>
        /// <param name="curso"></param>
        /// <returns>Adiciona Curso</returns>
        [HttpPost]
        public IActionResult Post(Curso curso)
        {
            try
            {
                _cursoRepository.Adicionar(curso);

                return Ok(curso);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui Objeto Curso
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Exclui Curso</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _cursoRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
