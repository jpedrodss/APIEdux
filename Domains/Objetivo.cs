using System;
using System.Collections.Generic;

namespace APIEdux.Domains
{
    public partial class Objetivo
    {
        public Objetivo()
        {
            ObjetivoAluno = new HashSet<ObjetivoAluno>();
        }

        public int IdObjetivo { get; set; }
        public string Descricao { get; set; }
        public int IdCategoria { get; set; }

        public virtual Categoria IdCategoriaNavigation { get; set; }
        public virtual ICollection<ObjetivoAluno> ObjetivoAluno { get; set; }
    }
}
