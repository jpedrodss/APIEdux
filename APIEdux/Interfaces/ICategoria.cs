using APIEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Interfaces
{
    interface ICategoria
    {
        void Adicionar(Categoria categoria);
        void Excluir(int id);
        void Editar(Categoria categoria);
        List<Categoria> Listar();
        Categoria BuscarID(int id);
    }
}
