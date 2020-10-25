using System;
using System.Collections.Generic;

namespace APIEdux.Domains
{
    public partial class Categoria
    {
        public Categoria()
        {
            Objetivo = new HashSet<Objetivo>();
        }

        public int IdCategoria { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<Objetivo> Objetivo { get; set; }
    }
}
