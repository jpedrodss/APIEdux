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
    public class InstituicaoController : ControllerBase
    {
        private readonly InstituicaoRepository _instituicaoRepository;

        public InstituicaoController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Lista intens do Objeto Instituição 
        /// </summary>
        /// <returns>Lista Instituições</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var Instituicoes = _instituicaoRepository.Listar();

                if (Instituicoes.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = Instituicoes.Count,
                    data = Instituicoes
                });
            }
            catch (Exception ex)
            {
                return BadRequest();

            }
        }

        /// <summary>
        /// Busca Objeto Instituição por id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Instituição</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Instituicao instituicao = _instituicaoRepository.BuscarID(id);

                if (instituicao == null)
                    return NotFound();

                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edita itens do objeto instituição
        /// </summary>
        /// <param name="id"></param>
        /// <param name="instituicao"></param>
        /// <returns>Edição Instituição</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Instituicao instituicao)
        {
            try
            {
                var instituicao1 = _instituicaoRepository.BuscarID(id);

                if (instituicao1 == null)
                    return NotFound();

                instituicao.IdInstituicao = id;
                _instituicaoRepository.Editar(instituicao);

                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona Itens no objeto Instituição
        /// </summary>
        /// <param name="instituicao"></param>
        /// <returns>Adicionarintens no objeto instituição</returns>
        [HttpPost]
        public IActionResult Post(Instituicao instituicao)
        {
            try
            {
                _instituicaoRepository.Adicionar(instituicao);

                return Ok(instituicao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Remove Objeto Curso
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Remove Objeto Curso</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _instituicaoRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
