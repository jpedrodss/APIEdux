using APIEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Interfaces
{
    interface IProfessorTurma
    {
        
            void Adicionar(ProfessorTurma professorTurma);
            void Excluir(int id);
            void Editar(ProfessorTurma professorTurma);
            List<ProfessorTurma> Listar();
            ProfessorTurma BuscarID(int id);
        }
    
}

