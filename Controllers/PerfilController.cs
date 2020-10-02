using System;
using Microsoft.AspNetCore.Mvc;
using APIEdux.Domains;
using Microsoft.AspNetCore.Authorization;
using APIEdux.Repositories;
using APIEdux.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIEdux.Controllers
{
    [Authorize(Roles = "Professor")]
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfil _perfilRepository;

        public PerfilController()
        {
            _perfilRepository = new PerfilRepository();
        }

        /// <summary>
        /// Lista todos os perfís.
        /// </summary>
        /// <returns>Lista dos perfís cadastrados</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var perfis = _perfilRepository.Listar();

                if (perfis.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = perfis.Count,
                    data = perfis
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
        /// Procura um perfil específico por ID
        /// </summary>
        /// <param name="id">ID de pesquisa</param>
        /// <returns>Perfil pesquisado</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Perfil perfil = _perfilRepository.BuscarID(id);

                if (perfil == null)
                    return NotFound();

                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Edita um perfil
        /// </summary>
        /// <param name="id">ID para pesquisar o perfil</param>
        /// <param name="perfil">Perfil a ser editado</param>
        /// <returns>Resultado da edição</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, Perfil perfil)
        {
            try
            {
                var perfilTemp = _perfilRepository.BuscarID(id);

                if (perfilTemp == null)
                    return NotFound();

                perfil.IdPerfil = id;
                _perfilRepository.Editar(perfil);

                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um perfil
        /// </summary>
        /// <param name="perfil">Perfil a ser adicionado</param>
        /// <returns>Perfil adicionado</returns>
        [HttpPost]
        public IActionResult Post(Perfil perfil)
        {
            try
            {
                _perfilRepository.Adicionar(perfil);

                return Ok(perfil);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um perfil
        /// </summary>
        /// <param name="id">ID do perfil para ser excluido</param>
        /// <returns>Status code da ação</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _perfilRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
