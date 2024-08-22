using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Class for IndexModel
    /// </summary>
    public class IndexModel : PageModel
    {
        // Initialize logger variable
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Constructor for IndexModel
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            // Assign logger variable
            _logger = logger;
            // Assign ProductService
            ProductService = productService;
        }

        /// <summary>
        /// Getter method for JsonFileProductService
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Getter for Iterative Products
        /// </summary>
        public IEnumerable<ProductModel> Products { get; private set; }
  //To store the search string from the search bar
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }



       /// <summary>
        /// This is used to get all of the data
        /// </summary>
        /// <param name="SearchString"></param>
        /// <returns></returns>
        public IActionResult OnGet(string SearchString)
        {
            // Search string is not null or empty then find the products in product list
            if (!string.IsNullOrEmpty(SearchString))
            {
                Products = ProductService.GetProducts().Where(m => m.Title.ToLower().StartsWith(SearchString.ToLower()));
            }

           // Search string is null or empty then return all products
            if (string.IsNullOrEmpty(SearchString))
            {
                Products = ProductService.GetProducts();
            }

           // Search string is not found in product list then return all products
            if (Products.Count() == 0)
            {
                Products = ProductService.GetProducts();
            }



           return Page();
        }
    }
}