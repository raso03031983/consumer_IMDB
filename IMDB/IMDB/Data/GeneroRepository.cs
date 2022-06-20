using IMDB.Data.Interface;
using IMDB.Data.ORM;
using IMDB.Data.ORM.Model;
using System.Collections.Generic;

namespace IMDB.Data
{
    public class GeneroRepository : IGeneroRepository
    {
        public void Delete(Genero item)
        {
            throw new System.NotImplementedException();
        }

        public Genero GetByID(int itemID)
        {
            throw new System.NotImplementedException();
        }

        public Genero Load()
        {
            throw new System.NotImplementedException();
        }

        public void Save(Genero item)
        {
            using (var context = new DefaultContext())
            {
                context.Genero.Add(item);
                context.SaveChanges();
            }
        }

        public void SaveRange(List<Genero> itens)
        {
            using (var context = new DefaultContext())
            {
                context.Genero.AddRange(itens);
                context.SaveChanges();
            }
        }

        public void Update(Genero item)
        {
            throw new System.NotImplementedException();
        }
    }
}
