using APIEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Interfaces
{
    interface IObjetivo
    {
        void Adicionar(Objetivo objetivo);
        void Excluir(int id);
        void Editar(Objetivo objetivo);
        List<Objetivo> Listar();
        Objetivo BuscarID(int id);

    }
}
