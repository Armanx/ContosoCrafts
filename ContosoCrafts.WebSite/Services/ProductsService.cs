using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ContosoCrafts.WebSite.Services
{
    public class ProductsService
    {
        public IHostingEnvironment WebHost { get; }

        public ProductsService(IHostingEnvironment webHost)
        {
            WebHost = webHost;
        }

        // get json file name root path
        private string JsonFileName => Path.Combine(WebHost.WebRootPath, "data", "products.json");

        /// <summary>
        /// IEnumerable which is stuff you can foreach over.
        /// Things that you can foreach over, you can enumerate. 
        /// Which means you are not limited to using an array, a list, or a collection.
        /// </summary>
        /// <returns>A list of Products</returns>
        public IEnumerable<Product> GetProducts()
        {
            // open up the text file
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                // return a list of products, read the entire json file.
                return JsonConvert.DeserializeObject<Product[]>(jsonFileReader.ReadToEnd());
            }
        }
    }
}
