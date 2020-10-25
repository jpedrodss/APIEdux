using APIEdux.Contexts;
using APIEdux.Domains;
using APIEdux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Repositories
{
    public class CategoriaRepository : ICategoria
    {
        private readonly EduxContext _ctx;

        public CategoriaRepository()
        {
            _ctx = new EduxContext();
        }


        /// <summary>
        /// Adiciona Um novo Objeto Categoria
        /// </summary>
        /// <param name="categoria"></param>
        public void Adicionar(Categoria categoria)
        {
            try
            {
                _ctx.Categoria.Add(categoria);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Busca um item do objeto categoria
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Categoria BuscarID(int id)
        {
            try
            {
                return _ctx.Categoria.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca um objeto categoria
        /// </summary>
        /// <param name="categoria"></param>
        public void Editar(Categoria categoria)
        {
            try
            {
                Categoria categoria1 = BuscarID(categoria.IdCategoria);

                if (categoria1 == null)
                    throw new Exception("Categoria não encontrada");

                categoria1.Descricao = categoria.Descricao;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Exclui o objeto categoria
        /// </summary>
        /// <param name="id"></param>
        public void Excluir(int id)
        {
            try
            {
                Categoria categoria = BuscarID(id);

                if (categoria == null)
                    throw new Exception("Categoria não encontrada");

                _ctx.Categoria.Remove(categoria);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Lista todos items do objeto Categoria
        /// </summary>
        /// <returns></returns>
        public List<Categoria> Listar()
        {

                List<Categoria> categorias = _ctx.Categoria.ToList();
                return categorias;
            
        }
    }
}
