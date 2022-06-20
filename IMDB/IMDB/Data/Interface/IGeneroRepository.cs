using IMDB.Data.ORM.Model;
using System.Collections.Generic;

namespace IMDB.Data.Interface
{
    public interface IGeneroRepository
    {
        Genero GetByID(int itemID);
        Genero Load();
        void Save(Genero item);
        void SaveRange(List<Genero> itens);
        void Update(Genero item);
        void Delete(Genero item);
    }
}
