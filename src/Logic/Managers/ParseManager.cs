using Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Managers
{
    public class ParseManager
    {
        private HttpClient _httpClient = new HttpClient();
        public async Task<Root> GetRootAsync(string search)
        {
            var response = await _httpClient.GetAsync($"https://search.wb.ru/exactmatch/ru/common/v4/search?appType=1&couponsGeo=12,3,18,15,21&curr=rub&dest=-1029256,-102269,-2162196,-1257786&emp=0&lang=ru&locale=ru&pricemarginCoeff=1.0&query={search}&reg=0&regions=68,64,83,4,38,80,33,70,82,86,75,30,69,22,66,31,40,1,48,71&resultset=catalog&sort=popular&spp=0&suppressSpellcheck=false");
            return JsonConvert.DeserializeObject<Root>(
               await response.Content.ReadAsStringAsync());
        }
    }
}
