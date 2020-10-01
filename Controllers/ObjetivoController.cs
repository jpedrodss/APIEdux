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
    public class ObjetivoController : ControllerBase
    {
        private readonly ObjetivoRepository _objetivoRepository;


        /// <summary>
        /// Lista todos os Objetivos
        /// </summary>
        /// <returns>Retorna os Objetivos cadastrados</returns>

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var objetivos = _objetivoRepository.Listar();

                if (objetivos.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = objetivos.Count,
                    data = objetivos
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
        /// Procura um Objetivo especifico por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objetivo pesquisado</returns>

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
               Objetivo objetivo = _objetivoRepository.BuscarID(id);

                if (objetivo == null)
                    return NotFound();

                return Ok(objetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Edita um Objetivo
        /// </summary>
        /// <param name="id">ID do Objetivo</param>
        /// <param name="objetivo">Objetivo para ser editado</param>
        /// <returns></returns>

        [HttpPut("{id}")]
        public IActionResult Put(int id, Objetivo objetivo)
        {
            try
            {
                var objetivoTemp = _objetivoRepository.BuscarID(id);

                if (objetivoTemp == null)
                    return NotFound();

                objetivo.IdObjetivo = id;
                _objetivoRepository.Editar(objetivo);

                return Ok(objetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um Objetivo
        /// </summary>
        /// <param name="objetivo">Objetivo a ser adicionado</param>
        /// <returns>Objetivo adicionado</returns>
        /// 
        [HttpPost]
        public IActionResult Post(Objetivo objetivo)
        {
            try
            {
                _objetivoRepository.Adicionar(objetivo);

                return Ok(objetivo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um Objetivo
        /// </summary>
        /// <param name="id">ID do Objetivo para ser excluido</param>
        /// <returns>Status code da ação</returns>

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _objetivoRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}