using APIEdux.Contexts;
using APIEdux.Domains;
using APIEdux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Repositories
{
    public class CurtidaRepository : ICurtida
    {
        private readonly EduxContext _ctx;

        public CurtidaRepository()
        {
            _ctx = new EduxContext();
        }

        public void Adicionar(Curtida curtida)
        {
            try
            {
                _ctx.Curtida.Add(curtida);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Curtida BuscarID(int id)
        {
            try
            {
                return _ctx.Curtida.Find(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void Excluir(int id)
        {
            try
            {
                Curtida curtida = BuscarID(id);

                if (curtida == null)
                    throw new Exception("ID Curtida não encontrada.");

                _ctx.Curtida.Remove(curtida);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }

        public List<Curtida> Listar()
        {
            try
            {
                List<Curtida> curtidas = _ctx.Curtida.ToList();
                return curtidas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }
    }
    }

