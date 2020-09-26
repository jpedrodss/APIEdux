using APIEdux.Contexts;
using APIEdux.Domains;
using APIEdux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Repositories
{
    public class AlunoTurmaRepository : IAlunoTurma
    { 
    
    private readonly EduxContext _ctx;

    public AlunoTurmaRepository()
    {
        _ctx = new EduxContext();
    }

        /// <summary>
        /// Adiciona um tipo alunoTurma
        /// </summary>
        /// <param name="alunoTurma">alunoTurma para ser adicionado</param>

        public void Adicionar(AlunoTurma alunoTurma)
        {
            using (EduxContext _ctx = new EduxContext())
            {
                _ctx.AlunoTurma.Add(alunoTurma);
                _ctx.SaveChanges();

            }

        }

        /// <summary>
        /// Busca um tipo alunoTurma por ID
        /// </summary>
        /// <param name="id">ID para pesquisa</param>
        /// <returns>alunoTurma pesquisado</returns>

        public AlunoTurma BuscarID(int id)
        {
            using (EduxContext _ctx = new EduxContext())
            {
                return _ctx.AlunoTurma.FirstOrDefault(x => x.IdAlunoTurma == id);
            }
        }

        /// <summary>
        /// Edita um tipo de alunoTurma
        /// </summary>
        /// <param name="alunoTurma">alunoTurma a ser editado</param>

        public void Editar(AlunoTurma alunoTurma)
        {
            {
                try
                {
                    AlunoTurma alunoTurmaTemp = BuscarID(alunoTurma.IdAlunoTurma);

                    if (alunoTurmaTemp == null)
                        throw new Exception("Aluno não encontrado.");

                    _ctx.AlunoTurma.Update(alunoTurmaTemp);
                    _ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message); ;
                }
            }
        }

        /// <summary>
        /// Exclui um alunoTurma
        /// </summary>
        /// <param name="id">ID do alunoTurma</param>
        /// 
        public void Excluir(int id)
        {
            try
            {
                AlunoTurma alunoTurma = BuscarID(id);

                if (alunoTurma == null)
                    throw new Exception("Aluno não encontrado");

                _ctx.AlunoTurma.Remove(alunoTurma);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }


        /// <summary>
        /// Lista todos os alunoTurmas
        /// </summary>
        /// <returns>Lista dos alunoTurmas</returns>
        /// 
        public List<AlunoTurma> Listar()
        {
            try
            {
                List<AlunoTurma> alunoTurmas = _ctx.AlunoTurma.ToList();
                return alunoTurmas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }
    }
}
