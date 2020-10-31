using APIEdux.Contexts;
using APIEdux.Domains;
using APIEdux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly EduxContext _ctx;

        public UsuarioRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Adiciona um Usuario
        /// </summary>
        /// <param name="usuario">Usuario para ser adicionado</param>
        public void Adicionar(Usuario usuario)
        {
            try
            {
                _ctx.Usuario.Add(usuario);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um Usuario por ID
        /// </summary>
        /// <param name="id">ID para pesquisa</param>
        /// <returns>Usuario pesquisado</returns>
        public Usuario BuscarID(int id)
        {
            try
            {
                return _ctx.Usuario.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }

        /// <summary>
        /// Edita um Usuario
        /// </summary>
        /// <param name="usuario">Usuario a ser editado</param>
        public void Editar(Usuario usuario)
        {
            try
            {
                Usuario usuarioTemp = BuscarID(usuario.IdUsuario);

                if (usuarioTemp == null)
                    throw new Exception("Usuario não encontrado.");

                usuarioTemp.Nome = usuario.Nome;
                usuarioTemp.Email = usuario.Email;
                usuarioTemp.Senha = usuario.Senha;
                _ctx.Usuario.Update(usuarioTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }

        /// <summary>
        /// Exclui um Usuario
        /// </summary>
        /// <param name="id">ID do Usuario</param>
        public void Excluir(int id)
        {
            try
            {
                Usuario usuario = BuscarID(id);

                if (usuario == null)
                    throw new Exception("Usuario não encontrado.");

                _ctx.Usuario.Remove(usuario);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Lista dos usuarios</returns>
        public List<Usuario> Listar()
        {
            try
            {
                List<Usuario> usuarios = _ctx.Usuario.ToList();
                return usuarios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }
    }
}
