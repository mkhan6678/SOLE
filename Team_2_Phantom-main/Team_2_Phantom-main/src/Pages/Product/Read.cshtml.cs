using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ContosoCrafts.WebSite.Pages.Product
{
    public class ReadModel : PageModel
    {
        // Data which gets the of the product from jsonFileproductservice
        public JsonFileProductService ProductService { get; }

        /// <summary>
        ///  This is Defualt Construtor 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public ReadModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // Shows the data of the particular product
        public ProductModel Product;

        /// Get the details about the particular product in read page by using Getproduct() method
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            Product = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));
        }

    }
}