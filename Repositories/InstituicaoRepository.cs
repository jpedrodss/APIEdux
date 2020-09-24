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
        private readonly InstituicaoRepository _instituicaoRepository;
        public InstituicaoRepository()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        public void Adicionar(Instituicao instituicao)
        {
            throw new NotImplementedException();
        }

        public Instituicao BuscarID(int id)
        {
            throw new NotImplementedException();
        }

        public void Editar(Instituicao instituicao)
        {
            throw new NotImplementedException();
        }

        public Instituicao Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public List<Instituicao> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
