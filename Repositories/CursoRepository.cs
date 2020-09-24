using APIEdux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Repositories
{
    public class CursoRepository : ICurso
    {
        private readonly CursoRepository _cursoRepository;

        public CursoRepository()
        {
            _cursoRepository = new CursoRepository();
        }

        
    }
}
