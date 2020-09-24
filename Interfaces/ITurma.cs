using APIEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Interfaces
{
    interface ITurma
    {
        void Adicionar(Turma turma);
        void Excluir(int id);
        void Editar(Turma turma);
        List<Turma> Listar();
        Turma BuscarID(int id);
    }
}
