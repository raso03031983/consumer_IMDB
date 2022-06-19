using IMDB.Data.ORM.Model;
using IMDB.Service.DTO;
using System.Collections.Generic;

namespace IMDB.Infra.Mapper
{
    public class FilmeMapper
    {
        public List<Filme> MapperImdbToFilme(IMDBDto result) {
            var lst = new List<Filme>();

            foreach (var item in result.results)
            {
                var filme = new Filme
                {
                    idIMDB = item.id,
                    title = item.title,
                    original_language = item.original_language,
                    vote_count = item.vote_count,
                    release_date = item.release_date,
                    overview = item.overview,
                    adult = item.adult,
                    backdrop_path = item.backdrop_path,
                    original_title = item.original_title,
                    popularity = item.popularity,
                    poster_path = item.poster_path,
                    video = item.video,
                    vote_average = item.vote_average
                };

                lst.Add(filme);
            }

            return lst;
        }
    }
}
