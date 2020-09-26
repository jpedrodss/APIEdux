using APIEdux.Contexts;
using APIEdux.Domains;
using APIEdux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Repositories
{
    public class ObjetivoAlunoRepository : IObjetivoAluno
    {
        private readonly EduxContext _ctx;

        public ObjetivoAlunoRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Adiciona um tipo de ObjetivoAluno
        /// </summary>
        /// <param name="objetivoAluno">ObjetivoAluno para ser adicionado</param>
        
        public void Adicionar(ObjetivoAluno objetivoAluno)
        {
            _ctx.ObjetivoAluno.Add(objetivoAluno);
            _ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tipo de ObjetivoAluno por ID
        /// </summary>
        /// <param name="id">ID para pesquisa</param>
        /// <returns>ObjetivoAluno pesquisado</returns>
        
        public ObjetivoAluno BuscarID(int id)
        {
            using (EduxContext _ctx = new EduxContext())
            {
                return _ctx.ObjetivoAluno.FirstOrDefault(x => x.IdObjetivoAluno == id);
            }
        }

        /// <summary>
        /// Edita um ObjetivoAluno
        /// </summary>
        /// <param name="objetivoAluno">ObjetivoAluno a ser editado</param>
        public void Editar(ObjetivoAluno objetivoAluno)
        {
            {
                try
                {
                    ObjetivoAluno objetivoAlunoTemp = BuscarID(objetivoAluno.IdObjetivoAluno);

                    if (objetivoAlunoTemp == null)
                        throw new Exception("ObjetivoAluno não encontrado.");

                    _ctx.ObjetivoAluno.Update(objetivoAlunoTemp);
                    _ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message); ;
                }
            }
        }

        /// <summary>
        /// Exclui um ObjetivoAluno
        /// </summary>
        /// <param name="id">ID do ObjetivoAluno</param>
        public void Excluir(int id)
        {
            try
            {
                ObjetivoAluno objetivoAluno = BuscarID(id);

                if (objetivoAluno == null)
                    throw new Exception("ObjetivoAluno não encontrado");

                _ctx.ObjetivoAluno.Remove(objetivoAluno);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }

        /// <summary>
        /// Lista dos objetivoAlunos
        /// </summary>
        /// <returns>Lista dos ObjetivoAlunos </returns>
        public List<ObjetivoAluno> Listar()
        {
            try
            {
                List<ObjetivoAluno> ObjetivoAlunos = _ctx.ObjetivoAluno.ToList();
                return ObjetivoAlunos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); 
            }
        }
    }
   }

