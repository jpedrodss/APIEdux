using APIEdux.Contexts;
using APIEdux.Domains;
using APIEdux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Repositories
{
    public class ObjetivoRepository : IObjetivo
    {
        private readonly EduxContext _ctx;

        public ObjetivoRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Adiciona um tipo de Objetivo
        /// </summary>
        /// <param name="objetivo">Objetivo para ser adicionado</param>

        public void Adicionar(Objetivo objetivo)
        {
            _ctx.Objetivo.Add(objetivo);
            _ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tipo de Objetivo por ID
        /// </summary>
        /// <param name="id">ID para pesquisa</param>
        /// <returns>Objetivo pesquisado</returns>

        public Objetivo BuscarID(int id)
        {
            using (EduxContext _ctx = new EduxContext())
            {
                return _ctx.Objetivo.FirstOrDefault(x => x.IdObjetivo == id);
            }
        }

        /// <summary>
        /// Edita um Objetivo
        /// </summary>
        /// <param name="objetivo">Objetivo a ser editado</param>
        public void Editar(Objetivo objetivo)
        {
            {
                try
                {
                    Objetivo objetivoTemp = BuscarID(objetivo.IdObjetivo);

                    if (objetivoTemp == null)
                        throw new Exception("Objetivo não encontrado.");

                    objetivoTemp.Descricao   = objetivo.Descricao;
                    objetivoTemp.IdCategoria = objetivo.IdCategoria; 

                    _ctx.Objetivo.Update(objetivoTemp);
                    _ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message); ;
                }
            }
        }

        /// <summary>
        /// Exclui um Objetivo
        /// </summary>
        /// <param name="id">ID do Objetivo</param>
        public void Excluir(int id)
        {
            try
            {
                Objetivo objetivo = BuscarID(id);

                if (objetivo == null)
                    throw new Exception("Objetivo não encontrado");

                _ctx.Objetivo.Remove(objetivo);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }

        /// <summary>
        /// Lista dos objetivos
        /// </summary>
        /// <returns>Lista dos Objetivos </returns>
        public List<Objetivo> Listar()
        {
            try
            {
                List<Objetivo> Objetivos = _ctx.Objetivo.ToList();
                return Objetivos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
