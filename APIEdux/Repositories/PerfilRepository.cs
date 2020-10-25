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
