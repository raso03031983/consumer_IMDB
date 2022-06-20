using IMDB.Data.ORM.Model;
using IMDB.Service.DTO;
using System.Collections.Generic;

namespace IMDB.Infra.Mapper
{
    public class FilmeGeneroMapper
    {
        public List<FilmeGenero> MapperImdbGeneroFilmeToGeneroFilme(IMDBDto result)
        {
            var lst = new List<FilmeGenero>();

            foreach (var item in result.results)
            {
                foreach (var genero in item.genre_ids)
                {
                    var itemModel = new FilmeGenero();

                    itemModel.idIMDB = item.id;
                    itemModel.idGenero = genero;

                    lst.Add(itemModel);
                }
            }
            return lst;
        }
    }
}
