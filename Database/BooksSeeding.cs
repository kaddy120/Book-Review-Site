using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections.ObjectModel;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Books.Database
{
    public class BooksSeeding
    {
        private readonly IHttpClientFactory http;
        private readonly IConfiguration config;

        public BooksSeeding(IHttpClientFactory http, IConfiguration config)
        {
            this.http = http;
            this.config = config;
        }
        
        public async  Task<IEnumerable<Book>> ReadFromFile()
        {
            //this is wrong, is shouldn't have this here. i should pass this value from somewhere
            //probabably appsettings (Iconfigurations)
            var rootpath = "C:/Users/Marindi k/OneDrive/Documents/Books/wwwroot";
            var filePath = Path.Combine(rootpath, "books.csv");

            string[] Values;
            Collection<Book> Books_ = new Collection<Book>();

            using (var reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    Values = line.Split(',', StringSplitOptions.None);

                    var moreBookInfor = await mining(Values[0]);
                    //int num;
                    //Int32.TryParse(Values[0], out num);
                    Books_.Add(new Book()
                    {
                        Isbn = Values[0],
                        Title = Values[1],
                        Authour = Values[2],
                        Year = Values[3],
                        ThumbnailUrl = moreBookInfor.Thumbnail,
                       // Category = moreBookInfor.Categories
                    }); 
                    
                }
            }
            return Books_;
        }

        public async Task<BooksMoreInfo> mining(string isbn)
        {
            var UrlBase = config["Urls:BooksThumbnailsApi"];

            string Url = UrlBase + isbn;
            var Client = this.http.CreateClient();
            var response = await Client.GetAsync(Url);

            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(str);
                var thumbnail = (string)json.SelectToken("items[0].volumeInfo.imageLinks.thumbnail");
                //var category = json.SelectToken("items[0].volumeInfo.imageLinks.categories")
                //    .Select(s => s.ToString()).ToArray();
                var info = new BooksMoreInfo()
                {
                    Thumbnail = thumbnail,
                    //Categories = category,
                };
                return info;
            }
            else
            {
                return new BooksMoreInfo();
                
            }
        }
    }

    public class BooksMoreInfo
    {
        public string? Thumbnail { get; set; }
       // public string[]? Categories { get; set; }
    }
}
