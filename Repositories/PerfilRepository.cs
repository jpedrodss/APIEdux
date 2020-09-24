using APIEdux.Contexts;
using APIEdux.Domains;
using APIEdux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Repositories
{
    public class PerfilRepository : IPerfil
    {
        private readonly EduxContext _ctx;

        public PerfilRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Adiciona um tipo perfil
        /// </summary>
        /// <param name="perfil">Perfil para ser adicionado</param>
        public void Adicionar(Perfil perfil)
        {
            try
            {
                _ctx.Perfil.Add(perfil);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um tipo perfil por ID
        /// </summary>
        /// <param name="id">ID para pesquisa</param>
        /// <returns>Perfil pesquisado</returns>
        public Perfil BuscarID(int id)
        {
            try
            {
                return _ctx.Perfil.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }

        /// <summary>
        /// Edita um tipo de perfil
        /// </summary>
        /// <param name="perfil">Perfil a ser editado</param>
        public void Editar(Perfil perfil)
        {
            try
            {
                Perfil perfilTemp = BuscarID(perfil.IdPerfil);

                if (perfilTemp == null)
                    throw new Exception("Tipo de Perfil não encontrado.");

                perfilTemp.Permissao = perfil.Permissao;
                _ctx.Perfil.Update(perfilTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }

        /// <summary>
        /// Exclui um perfil
        /// </summary>
        /// <param name="id">ID do perfil</param>
        public void Excluir(int id)
        {
            try
            {
                Perfil perfil = BuscarID(id);

                if (perfil == null)
                    throw new Exception("Tipo de Perfil não encontrado.");

                _ctx.Perfil.Remove(perfil);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }

        /// <summary>
        /// Lista todos os perfís
        /// </summary>
        /// <returns>Lista dos perfís</returns>
        public List<Perfil> Listar()
        {
            try
            {
                List<Perfil> perfis = _ctx.Perfil.ToList();
                return perfis;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }
    }
}
