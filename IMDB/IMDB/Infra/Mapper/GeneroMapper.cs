using IMDB.Data.ORM.Model;
using IMDB.Service.DTO;
using System.Collections.Generic;

namespace IMDB.Infra.Mapper
{
    public class GeneroMapper
    {
        public List<Genero> MapperImdbGeneroToGenero(GeneroImdbDto result)
        {
            var lst = new List<Genero>();

            foreach (var item in result.genres)
            {
                var _tem = new Genero
                {
                    idImdb = item.id,
                    nome = item.name
                };

                lst.Add(_tem);
            }

            return lst;
        }
    }
}
