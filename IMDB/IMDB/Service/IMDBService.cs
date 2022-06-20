using IMDB.Data;
using IMDB.Data.Interface;
using IMDB.Infra.Mapper;
using IMDB.Service.DTO;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace IMDB.Service
{
    public class IMDBService
    {
        private string keyIMDB = "3320806a8cf82270c74a8bd026268a81&language";
        private string pathBaseIMDB = "https://api.themoviedb.org/3/";
        public void ConsumerIMDB() {
            string pageIMDB = "1";
            string pathIMDB = $"movie/popular?api_key={keyIMDB}&language=pt-BR&page={pageIMDB}";

            IMDBDto dadosResp = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(pathBaseIMDB);
                var responseTask = client.GetAsync(pathIMDB);

                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IMDBDto>();
                    readTask.Wait();
                    dadosResp = readTask.Result;
                    ConsumerIMDBPerPage(dadosResp);
                }
                else
                {
                    Console.WriteLine("Erro ao acessar API IMDB");
                }
            }
        }

        private void AddRangeFilmeGenero(IMDBDto imdb) { 

            try
            {
                IFilmeGeneroRepository rep = new FilmeGeneroRepository();
                var itens = new FilmeGeneroMapper().MapperImdbGeneroFilmeToGeneroFilme(imdb);
                rep.SaveRange(itens);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro metodo AddRangeFilmes ", ex.ToString());
            }
        }

        private void ConsumerIMDBPerPage(IMDBDto imdb)
        {
            int countPage = 1;

            for (int i = 0; i < imdb.total_pages; i++)
            {
                string keyIMDB = "3320806a8cf82270c74a8bd026268a81&language";
                int pageIMDB = countPage ++;
                string pathBaseIMDB = "https://api.themoviedb.org/3/movie/";
                string pathIMDB = $"popular?api_key={keyIMDB}&language=pt-BR&page={pageIMDB}";

                IMDBDto dadosResp = null;

                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.BaseAddress = new Uri(pathBaseIMDB);
                    var responseTask = client.GetAsync(pathIMDB);

                    responseTask.Wait();
                    var result = responseTask.Result;

                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadAsAsync<IMDBDto>();
                        readTask.Wait();
                        dadosResp = readTask.Result;
                        //AddRangeFilmes(dadosResp);
                        AddRangeFilmeGenero(dadosResp);
                    }
                    else
                    {
                        Console.WriteLine("Erro ao acessar API IMDB");
                        throw new Exception();
                    }
                }
            }
        }
        private void AddRangeFilmes(IMDBDto result) {
            try
            {
                IImdbRepository rep = new ImdbRepository();
                var filmeMapper = new FilmeMapper().MapperImdbToFilme(result);
                rep.SaveRange(filmeMapper);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro metodo AddRangeFilmes ", ex.ToString());
            }

        }
        public void ConsumerIMDBGenero()
        {
            string pathIMDB = $"genre/movie/list?api_key={keyIMDB}&language=pt-BR";

            GeneroImdbDto dadosResp = null;

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new Uri(pathBaseIMDB);
                var responseTask = client.GetAsync(pathIMDB);

                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<GeneroImdbDto>();
                    readTask.Wait();
                    dadosResp = readTask.Result;
                    AddRangeGenero(dadosResp);
                }
                else
                {
                    Console.WriteLine("Erro ao acessar API IMDB");
                }
            }
        }
        private void AddRangeGenero(GeneroImdbDto result)
        {
            try
            {
                IGeneroRepository rep = new GeneroRepository();
                var itemRange = new GeneroMapper().MapperImdbGeneroToGenero(result);
                rep.SaveRange(itemRange);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro metodo AddRangeFilmes ", ex.ToString());
            }

        }
    }
}
