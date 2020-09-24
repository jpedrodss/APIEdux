using APIEdux.Contexts;
using APIEdux.Domains;
using APIEdux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Repositories
{
    public class InstituicaoRepository : IInstituicao
    {

        private readonly EduxContext _ctx;

        public InstituicaoRepository()
        {
            _ctx = new EduxContext();
        }

        /// <summary>
        /// Adiciona uma novo Objeto instituição
        /// </summary>
        /// <param name="instituicao"></param>
        public void Adicionar(Instituicao instituicao)
        {
            try
            {
                //Adiciona Instituição
                _ctx.Instituicao.Add(instituicao);

                //Salva mudanças
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                //Retorna mensagem de erro caso ocorra
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Localiza Objeto Instituição atraves do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Instituicao BuscarID(int id)
        {
            try
            {
                //Localiza Instituição
              return  _ctx.Instituicao.Find(id);
            }
            catch (Exception ex)
            {
                //Retorna mensagem de erro caso ocorra
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Edita Valores do Objeto Instituiçao
        /// </summary>
        /// <param name="instituicao"></param>
        public void Editar(Instituicao instituicao)
        {
            try
            {
                //Busca Instituicao
                Instituicao instituicao1 = BuscarID(instituicao.IdInstituicao);

                if (instituicao1 == null)
                    throw new Exception("Instituição não encontrada");

                instituicao1.Nome = instituicao.Nome;
                instituicao1.Logradouro = instituicao.Logradouro;
                instituicao1.Numero = instituicao.Numero;
                instituicao1.Complemento = instituicao.Complemento;
                instituicao1.Bairro = instituicao.Bairro;
                instituicao1.Cidade = instituicao.Cidade;
                instituicao1.Uf = instituicao.Uf;
                instituicao1.Cep = instituicao.Cep;
                _ctx.Instituicao.Update(instituicao1);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                //Retorna mensagem de erro caso ocorra
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Exclui valores do Objeto Instituição
        /// </summary>
        /// <param name="id"></param>
        public void Excluir(int id)
        {
            try
            {
                Instituicao instituicao = BuscarID(id);
                if(instituicao == null)
                    throw new Exception("Instituição não encontrada");

                _ctx.Instituicao.Remove(instituicao);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                //Retorna mensagem de erro caso ocorra
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Lista Objeto instituição
        /// </summary>
        /// <returns>Lista de instituições</returns>
        public List<Instituicao> Listar()
        {
            List<Instituicao> instituicaos = _ctx.Instituicao.ToList();
            return instituicaos;
        }
    }
}
