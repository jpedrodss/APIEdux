using APIEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Interfaces
{
    interface IInstituicao
    {
        void Adicionar(Instituicao instituicao);
        void Excluir(int id);
        void Editar(Instituicao instituicao);
        List<Instituicao> Listar();
        Instituicao BuscarID(int id);
    }
}
