using APIEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Interfaces
{
    interface IUsuario
    {
        void Adicionar(Usuario user);
        void Excluir(int id);
        void Editar(Usuario usuario);
        List<Usuario> Listar();
        Usuario BuscarID(int id);
    }
}
