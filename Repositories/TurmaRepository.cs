using APIEdux.Contexts;
using APIEdux.Domains;
using APIEdux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Repositories
{
    public class TurmaRepository : ITurma
    {
        private readonly EduxContext _ctx;

        public TurmaRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Adiciona uma Turma
        /// </summary>
        /// <param name="turma">Turma para ser adicionada</param>
        public void Adicionar(Turma turma)
        {
            try
            {
                _ctx.Turma.Add(turma);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca uma Turma por ID
        /// </summary>
        /// <param name="id">ID para pesquisa</param>
        /// <returns>Turma pesquisada</returns>
        public Turma BuscarID(int id)
        {
            try
            {
                return _ctx.Turma.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }

        /// <summary>
        /// Edita uma Turma
        /// </summary>
        /// <param name="turma">Turma a ser editada</param>
        public void Editar(Turma turma)
        {
            try
            {
                Turma turmaTemp = BuscarID(turma.IdTurma);

                if (turmaTemp == null)
                    throw new Exception("Turma não encontrada.");

                turmaTemp.Descricao = turma.Descricao;
                turmaTemp.IdCurso = turma.IdCurso;
                _ctx.Turma.Update(turmaTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }

        /// <summary>
        /// Exclui uma Turma
        /// </summary>
        /// <param name="id">ID da Turma</param>
        public void Excluir(int id)
        {
            try
            {
                Turma turma = BuscarID(id);

                if (turma == null)
                    throw new Exception("Tipo de Perfil não encontrado.");

                _ctx.Turma.Remove(turma);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }

        /// <summary>
        /// Lista todas as turmas
        /// </summary>
        /// <returns>Lista das turmas </returns>
        public List<Turma> Listar()
        {
            try
            {
                List<Turma> turmas = _ctx.Turma.ToList();
                return turmas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }
    }
}
