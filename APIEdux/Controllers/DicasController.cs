using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIEdux.Domains;
using APIEdux.Repositories;
using APIEdux.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIEdux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DicasController : ControllerBase
    {
        private readonly DicaRepository _dicaRepository;

        public DicasController()
        {
            _dicaRepository = new DicaRepository();
        }

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
        public IActionResult Post([FromForm] Dica dica)
        {
            try
            {
                if (dica.Imagem != null)
                {
                    var urlImagem = Upload.Local(dica.Imagem);
                    dica.UrlImagem = urlImagem;
                }
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
