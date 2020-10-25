using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Books.Controllers
{
    [Route("/api")]
    public class MiningDataController
    {
        private readonly IHttpClientFactory http;
        private readonly IConfiguration config;

        public MiningDataController(IHttpClientFactory http, IConfiguration config)
        {
            this.http = http;
            this.config = config;
        }

        [HttpGet("mining")]
        public async Task mining()
        {
            string isbnLocal = "0765317508";
            var UrlBase= config["Urls:BooksThumbnailsApi"];
            
            string Url = UrlBase + isbnLocal;
            var Client = this.http.CreateClient();
            var response = await Client.GetAsync(Url);

            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(str);
                var thumbnail = (string) json.SelectToken("items[0].volumeInfo.imageLinks.thumbnail");
                //var category = json.SelectToken("items[0].volumeInfo.imageLinks.categories")
                //    .Select(s => s.ToString()).ToArray();
            }
            else
            {
            }
        }
    }
}
