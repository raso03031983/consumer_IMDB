using IMDB.Data.Interface;
using IMDB.Data.ORM;
using IMDB.Data.ORM.Model;
using System;
using System.Collections.Generic;

namespace IMDB.Data
{
    public class FilmeGeneroRepository : IFilmeGeneroRepository
    {
        public void Delete(FilmeGenero item)
        {
            throw new NotImplementedException();
        }

        public FilmeGenero GetByID(int itemID)
        {
            throw new NotImplementedException();
        }

        public FilmeGenero Load()
        {
            throw new NotImplementedException();
        }

        public void Save(FilmeGenero item)
        {
            throw new NotImplementedException();
        }

        public void SaveRange(List<FilmeGenero> itens)
        {
            using (var context = new DefaultContext())
            {
                context.FilmeGenero.AddRange(itens);
                context.SaveChanges();
            }
        }

        public void Update(FilmeGenero item)
        {
            throw new NotImplementedException();
        }
    }
}
