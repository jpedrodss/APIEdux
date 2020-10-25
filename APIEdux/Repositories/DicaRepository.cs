using APIEdux.Contexts;
using APIEdux.Domains;
using APIEdux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIEdux.Repositories
{
    public class DicaRepository : IDica
    {
        private readonly EduxContext _ctx = new EduxContext();
        public void Adicionar(Dica dica)
        {
            try
            {
                _ctx.Dica.Add(dica);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Dica BuscarID(int id)
        {

            try
            {
                return _ctx.Dica.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }

        }

        public void Editar(Dica dica)
        {
            {
                try
                {
                    Dica dicaTemp = BuscarID(dica.IdDica);

                    if (dicaTemp == null)
                        throw new Exception("Dica não encontrada.");

                    _ctx.Dica.Update(dicaTemp);
                    _ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message); ;
                }
            }
        }

        public void Excluir(int id)
        {
            try
            {
                Dica dica = BuscarID(id);

                if (dica == null)
                    throw new Exception("Dica não encontrada");

                _ctx.Dica.Remove(dica);

                _ctx.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); ;
            }
        }

        public List<Dica> Listar()
        {
            try
            {
                List<Dica> Dica = _ctx.Dica.ToList();
                return Dica;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}