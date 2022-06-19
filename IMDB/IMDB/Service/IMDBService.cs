using IMDB.Data;
using IMDB.Data.Interface;
using IMDB.Data.ORM.Model;
using IMDB.Infra.Mapper;
using IMDB.Service.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace IMDB.Service
{
    public class IMDBService
    {
        public void ConsumerIMDB() {
            
            string keyIMDB = "3320806a8cf82270c74a8bd026268a81&language";
            string pageIMDB = "1";
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
                    ConsumerIMDBPerPage(dadosResp);
                }
                else
                {
                    Console.WriteLine("Erro ao acessar API IMDB");
                }
            }
        }

        public void ConsumerIMDBPerPage(IMDBDto imdb)
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
                        AddRangeFilmes(dadosResp);
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

    }
}
