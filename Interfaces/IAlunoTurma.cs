using APIEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Interfaces
{
    interface IAlunoTurma
    {
        void Adicionar(AlunoTurma alunoTurma);
        void Excluir(int id);
        void Editar(AlunoTurma alunoTurma);
        List<AlunoTurma> Listar();
        AlunoTurma BuscarID(int id);
    }
}
