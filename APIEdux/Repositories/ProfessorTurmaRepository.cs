using APIEdux.Contexts;
using APIEdux.Domains;
using APIEdux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Repositories
{
    public class ProfessorTurmaRepository : IProfessorTurma
    {
        private readonly EduxContext _ctx;
        public void Adicionar(ProfessorTurma professorTurma)
        {
            using (EduxContext _ctx = new EduxContext())
            {
                _ctx.ProfessorTurma.Add(professorTurma);
                _ctx.SaveChanges();

            }
        }

        public ProfessorTurma BuscarID(int id)
        {
            using (EduxContext _ctx = new EduxContext())
            {
                return _ctx.ProfessorTurma.FirstOrDefault(x => x.IdProfessorTurma == id);
            }
        }

        public void Editar(ProfessorTurma professorTurma)
        {
            {
                try
                {
                    ProfessorTurma professorTurmaTemp = BuscarID(professorTurma.IdProfessorTurma);

                    if (professorTurmaTemp == null)
                        throw new Exception("Aluno não encontrado.");

                    professorTurmaTemp.IdUsuario = professorTurma.IdUsuario;
                    professorTurmaTemp.IdTurma = professorTurma.IdTurma;

                    _ctx.ProfessorTurma.Update(professorTurmaTemp);
                    _ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message); ;
                }
            }
        }

        public void Excluir(int id)
        {
            try
            {
                ProfessorTurma professorTurma = BuscarID(id);

                if (professorTurma == null)
                    throw new Exception("Professor não encontrado");

                _ctx.ProfessorTurma.Remove(professorTurma);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }

        public List<ProfessorTurma> Listar()
        {
            try
            {
                List<ProfessorTurma> professorTurmas = _ctx.ProfessorTurma.ToList();
                return professorTurmas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }
    }
    }

