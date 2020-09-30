using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIEdux.Domains;
using APIEdux.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIEdux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Lista os usuarios
        /// </summary>
        /// <returns>Lista de usuários</returns>
        [HttpGet]
        [Authorize(Roles = "Professor")]
        public IActionResult Get()
        {
            try
            {
                var usuarios = _usuarioRepository.Listar();

                if (usuarios.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = usuarios.Count,
                    data = usuarios
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
        /// Busca usuário por ID
        /// </summary>
        /// <param name="id">Id do Usuário</param>
        /// <returns>Usuário buscado</returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "Professor")]
        public IActionResult Get(int id)
        {
            try
            {
                Usuario usuario = _usuarioRepository.BuscarID(id);

                if (usuario == null)
                    return NotFound();

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Adiciona um usuário a base de dados
        /// </summary>
        /// <param name="usuario">Usuario a ser adicionado</param>
        /// <returns>Usuario adicionado</returns>
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post( Usuario usuario)
        {
            try
            {
                _usuarioRepository.Adicionar(usuario);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Altera um usuário
        /// </summary>
        /// <param name="id">ID para buscar usuario</param>
        /// <param name="usuario">Objeto para pegar informações do usuário</param>
        /// <returns>Alterações feitas</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = "Aluno, Professor")]
        public IActionResult Put(int id, Usuario usuario)
        {
            try
            {
                var usuarioTemp = _usuarioRepository.BuscarID(id);

                if (usuarioTemp == null)
                    return NotFound();

                usuario.IdUsuario = id;
                _usuarioRepository.Editar(usuario);

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Exclui um usuário
        /// </summary>
        /// <param name="id">ID do usuario para ser exlcuido</param>
        /// <returns>Status code</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Professor")]
        public IActionResult Delete(int id)
        {
            try
            {
                _usuarioRepository.Excluir(id);

                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
