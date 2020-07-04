using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _5kaPP.Models
{
    //класс ApiReader возвращает ответ от Api 
    class ApiReader
    {
        public async Task<string> ReadUrl(string _apiUrl)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(_apiUrl);
            var responseBody = await response.Content.ReadAsStringAsync();
            client.Dispose();
            return responseBody;
        }
    }
}
