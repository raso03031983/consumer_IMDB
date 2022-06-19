using IMDB.Data.ORM.Model;
using System.Collections.Generic;

namespace IMDB.Data.Interface
{
    public interface IImdbRepository
    {
        Filme GetByID(int clienteID);
        Filme Load();
        void Save(Filme cliente);
        void SaveRange(List<Filme> cliente);
        void Update(Filme cliente);
        void Delete(Filme cliente);
    }
}
