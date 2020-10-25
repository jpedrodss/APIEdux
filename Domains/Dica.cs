using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIEdux.Domains
{
    public partial class Dica
    {
        public Dica()
        {
            Curtida = new HashSet<Curtida>();
        }

        public int IdDica { get; set; }
        public string Texto { get; set; }
        //[NotMapped]
        //public IFormFile Imagem { get; set; }
        public string UrlImagem { get; set; }
        public int IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Curtida> Curtida { get; set; }
    }
}
