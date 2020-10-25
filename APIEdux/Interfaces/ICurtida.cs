using APIEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Interfaces
{
    interface ICurtida
    {
        void Excluir(int id);
        List<Curtida> Listar();
    }
}
