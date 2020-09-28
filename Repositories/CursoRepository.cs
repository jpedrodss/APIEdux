using APIEdux.Contexts;
using APIEdux.Domains;
using APIEdux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Repositories
{
    public class CursoRepository : ICurso
    {
        private readonly EduxContext _ctx;

        public CursoRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Adiciona Novo objeto Curso
        /// </summary>
        /// <param name="curso"></param>
        public void Adicionar(Curso curso)
        {
            try
            {
                _ctx.Curso.Add(curso);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Localiza Objeto Curso
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Curso BuscarID(int id)
        {
            try
            {
                return _ctx.Curso.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Edita Objeto Curso
        /// </summary>
        /// <param name="curso"></param>
        public void Editar(Curso curso)
        {
            try
            {
                Curso curso1 = BuscarID(curso.IdCurso);

                if (curso1 == null)
                    throw new Exception("Curso não encontrado");

                curso1.IdInstituicao = curso.IdInstituicao;
                curso1.Titulo = curso.Titulo;
                _ctx.Curso.Update(curso1);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Exclui Objeto Curso
        /// </summary>
        /// <param name="id"></param>
        public void Excluir(int id)
        {
            try
            {
                Curso curso = BuscarID(id);
                if (curso == null)
                    throw new Exception("Objeto não encontrado");

                _ctx.Curso.Remove(curso);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista todos os itens do Objeto Curso
        /// </summary>
        /// <returns></returns>
        public List<Curso> Listar()
        {
            List<Curso> cursos = _ctx.Curso.ToList();
            return cursos;
        }
    }
}
