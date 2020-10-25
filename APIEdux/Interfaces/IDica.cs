using APIEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Interfaces
{
    interface IDica
    {
        void Adicionar(Dica dica);
        void Excluir(int id);
        void Editar(Dica dica);
        List<Dica> Listar();
        Dica BuscarID(int id);
    }

}
