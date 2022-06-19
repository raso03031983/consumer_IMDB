using IMDB.Data.Interface;
using IMDB.Data.ORM;
using IMDB.Data.ORM.Model;
using System;
using System.Collections.Generic;

namespace IMDB.Data
{
    public class ImdbRepository : IImdbRepository
    {
        public void Delete(Filme cliente)
        {
            throw new NotImplementedException();
        }

        public Filme GetByID(int clienteID)
        {
            throw new NotImplementedException();
        }

        public Filme Load()
        {
            throw new NotImplementedException();
        }

        public void Save(Filme cliente)
        {
            throw new NotImplementedException();
        }

        public void SaveRange(List<Filme> cliente)
        {
            using (var context = new DefaultContext())
            {
                context.Filme.AddRange(cliente);
                context.SaveChanges();
            }
        }

        public void Update(Filme cliente)
        {
            throw new NotImplementedException();
        }
    }
}
