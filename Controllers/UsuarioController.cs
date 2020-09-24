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
using APIEdux.Utils;

namespace APIEdux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly EduxContext _context = new EduxContext();

        /// <summary>
        /// Lista todos os usuarios.
        /// </summary>
        /// <returns>Lista dos usuarios cadastrados</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuario.ToListAsync();
        }

        /// <summary>
        /// Procura um Usuario específico por ID
        /// </summary>
        /// <param name="id">ID de pesquisa</param>
        /// <returns>Usuario pesquisado</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        /// <summary>
        /// Edita um Usuario
        /// </summary>
        /// <param name="id">ID para pesquisar o Usuario</param>
        /// <param name="usuario">Usuario a ser editado</param>
        /// <returns>Resultado da edição</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            usuario.Senha = Crypto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 4));

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Adiciona um Usuario
        /// </summary>
        /// <param name="usuario">Usuario a ser adicionado</param>
        /// <returns>Usuario adicionado</returns>
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            usuario.Senha = Crypto.Criptografar(usuario.Senha, usuario.Email.Substring(0, 4));

            _context.Usuario.Add(usuario);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.IdUsuario }, usuario);
        }

        /// <summary>
        /// Exclui um Usuario
        /// </summary>
        /// <param name="id">ID do Usuario para ser excluido</param>
        /// <returns>Status code da ação</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.IdUsuario == id);
        }
    }
}
