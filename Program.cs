using _5kaPP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _5kaPP
{
    class Program
    {
        public static string appRoot { get; set; }

        public static Logger logger { get; set; }

        public static PricesReader priceReader { get; set; }


        static void Main(string[] args)
        {
            //получаем директорию приложения
            appRoot = AppDomain.CurrentDomain.BaseDirectory;

            logger = new Logger();

            logger.Event("Парсер запущен");

            priceReader = new PricesReader();

            var result = priceReader.PromoItems("O158");

            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
