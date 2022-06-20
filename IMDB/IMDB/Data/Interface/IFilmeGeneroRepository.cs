using IMDB.Data.ORM.Model;
using System.Collections.Generic;

namespace IMDB.Data.Interface
{
    public interface IFilmeGeneroRepository
    {
        FilmeGenero GetByID(int itemID);
        FilmeGenero Load();
        void Save(FilmeGenero item);
        void SaveRange(List<FilmeGenero> itens);
        void Update(FilmeGenero item);
        void Delete(FilmeGenero item);
    }
}
