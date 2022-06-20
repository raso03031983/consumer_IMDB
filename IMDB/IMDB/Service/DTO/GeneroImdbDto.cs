using System.Collections.Generic;

namespace IMDB.Service.DTO
{
    public class GeneroImdbDto
    {
        public List<Genre> genres { get; set; }
    }
    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
