using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5kaPP.Models
{
    class PricesReader
    {
        private IEnumerable<Api5kaPage> promoPrices { get; set; }
        private ApiReader apiReader { get; set; }

        public PricesReader()
        {
            promoPrices = new List<Api5kaPage>();
            apiReader = new ApiReader();
        }


        private IEnumerable<Api5kaPage> PromoPages(string shopId)
        {
            Api5kaPage api5kaPage = new Api5kaPage();
            List<Api5kaPage> tempList = new List<Api5kaPage>();

            string pricePromoUri = @"https://5ka.ru/api/v2/special_offers/?categories=&ordering=&page=1&price_promo__gte=&price_promo__lte=&records_per_page=50&search=&store=";
            string pricePromoUriWithShopId = pricePromoUri + shopId;

            api5kaPage = JsonConvert.DeserializeObject<Api5kaPage>(apiReader.ReadUrl(pricePromoUriWithShopId).Result);
            tempList.Add(api5kaPage);

            while (api5kaPage.next != null)
            {
                string nextUri = api5kaPage.next.ToString();
                api5kaPage = JsonConvert.DeserializeObject<Api5kaPage>(apiReader.ReadUrl(nextUri).Result);
                tempList.Add(api5kaPage);
            }

            return tempList;
        }

        public IEnumerable<Result> PromoItems(string shopId)
        {
            var promoPages = PromoPages(shopId);

            var items = new List<Result>();
            promoPages.ToList().ForEach(v =>
            {
                v.results.ForEach(i =>
                {
                    items.Add(i);
                });
            });

            return items;
        }
 
    }
}
