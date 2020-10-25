using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using APIEdux.Contexts;
using APIEdux.Domains;
using APIEdux.Repositories;
using System;
using Microsoft.EntityFrameworkCore;

namespace APIEdux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtidaController : ControllerBase
    {
        private readonly CurtidaRepository _curtidaRepository;

        public CurtidaController()
        {
            _curtidaRepository = new CurtidaRepository();
        }

        /// <summary>
        /// Lista todos itens do Objeto Curtida
        /// </summary>
        /// <returns>Lista Curtida</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var curtidas = _curtidaRepository.Listar();

                if (curtidas.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = curtidas.Count,
                    data = curtidas
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
        /// Busca Objeto curtida por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Busca curtida por id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Curtida curtida = _curtidaRepository.BuscarID(id);

                if (curtida == null)
                    return NotFound();

                return Ok(curtida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        /// <summary>
        /// Adiciona Objeto Curtida
        /// </summary>
        /// <param name="curtida"></param>
        /// <returns>Adiciona Curtida</returns>
        [HttpPost]
        public IActionResult Post(Curtida curtida)
        {
            try
            {
                _curtidaRepository.Adicionar(curtida);

                return Ok(curtida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui Objeto Curtida
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Exclui Curtida</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _curtidaRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
