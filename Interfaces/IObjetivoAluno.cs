using APIEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Interfaces
{
    interface IObjetivoAluno
    {
        void Adicionar(ObjetivoAluno objetivoAluno);
        void Excluir(int id);
        void Editar(ObjetivoAluno objetivoAluno);
        List<ObjetivoAluno> Listar();
        ObjetivoAluno BuscarID(int id);
    }
}
