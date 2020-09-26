using APIEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Interfaces
{
    interface ICurtida
    {
        void Adicionar(Curtida curtida);
        void Excluir(int id);
        List<Curtida> Listar();
        Curtida BuscarID(int id);
    }
}
