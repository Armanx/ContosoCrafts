using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages
{
    public class IndexModel : PageModel
    {
        public ProductsService ProductService;
        public IEnumerable<Product> Products { get; set; }

        public IndexModel(ProductsService productsService)
        {
            ProductService = productsService;
        }

        public void OnGet()
        {
            Products = ProductService.GetProducts();
        }
    }
}
