
using IMDB.Service;
using System;

namespace IMDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new IMDBService().ConsumerIMDB();
            
        }
    }
}
