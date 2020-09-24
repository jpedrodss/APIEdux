using APIEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Interfaces
{
    interface IPerfil
    {
        void Adicionar(Perfil perfil);
        void Excluir(int id);
        void Editar(Perfil perfil);
        List<Perfil> Listar();
        Perfil BuscarID(int id);
    }
}
