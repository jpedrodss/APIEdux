using APIEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Interfaces
{
    interface IPerfil
    {
        List<Perfil> Listar();
        Perfil BuscarID(int id);
    }
}
