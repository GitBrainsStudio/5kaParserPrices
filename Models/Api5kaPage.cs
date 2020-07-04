using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5kaPP.Models
{
    //класс для десерилизации json'а в объект
    public class Api5kaPage
    {
        public object next { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }

    }
    public class Promo
    {
        public int id { get; set; }
        public string date_begin { get; set; }
        public string date_end { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string kind { get; set; }
        public int expired_at { get; set; }

    }

    public class CurrentPrices
    {
        public double price_reg__min { get; set; }
        public double price_promo__min { get; set; }

    }

    public class Result
    {
        public int id { get; set; }
        public string name { get; set; }
        public object mech { get; set; }
        public string img_link { get; set; }
        public int plu { get; set; }
        public Promo promo { get; set; }
        public CurrentPrices current_prices { get; set; }
        public object store_name { get; set; }

    }


}
