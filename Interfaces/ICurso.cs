using APIEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Interfaces
{
    interface ICurso
    {
        void Adicionar(Curso curso);
        Curso Excluir(int id);
        void Editar(Curso curso);
        List<Curso> Listar();
        Curso BuscarID(int id);
    }
}
