using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIEdux.Contexts;
using APIEdux.Domains;
using APIEdux.Repositories;

namespace APIEdux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicaController : ControllerBase
    {
        private readonly DicaRepository _dicaRepository;

        /// <summary>
        /// Lista todos itens do Objeto Dicas
        /// </summary>
        /// <returns>Dica Categoria</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var dicas = _dicaRepository.Listar();

                if (dicas.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = dicas.Count,
                    data = dicas
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
        /// Busca Objeto Dica por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Dica Buscada</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Dica dica = _dicaRepository.BuscarID(id);

                if (dica == null)
                    return NotFound();

                return Ok(dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edita Objeto dica
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dica"></param>
        /// <returns>Itens dica a serem editados</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Dica dica)
        {
            try
            {
                var dicaTemp = _dicaRepository.BuscarID(id);

                if (dicaTemp == null)
                    return NotFound();

                dica.IdDica = id;
                _dicaRepository.Editar(dica);

                return Ok(dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona Objeto Dica
        /// </summary>
        /// <param name="dica"></param>
        /// <returns>Objeto dica a ser adicionado</returns>
        [HttpPost]
        public IActionResult Post(Dica dica)
        {
            try
            {
                _dicaRepository.Adicionar(dica);

                return Ok(dica);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Exclui Objeto Dica
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto dica a ser Excluido</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _dicaRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
