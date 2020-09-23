using System;
using System.Collections.Generic;

namespace APIEdux.Domains
{
    public partial class Instituicao
    {
        public Instituicao()
        {
            Curso = new HashSet<Curso>();
        }

        public int IdInstituicao { get; set; }
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }

        public virtual ICollection<Curso> Curso { get; set; }
    }
}
