using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ContosoCrafts.WebSite.Pages.Product
{  
    
    /// <summary>
    /// Update the data for single record 
    /// </summary>
    public class UpdateModel : PageModel
    {   
        // Data middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public UpdateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show, bind to it for the post.
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// REST Get request
        /// Loads the data
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            Product = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));
        }

        /// <summary>
        /// Post the model back to the page
        /// The model is in the class variable Article
        /// Call the data to Update that data
        /// Then return to the index page
        /// </summary>
         public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           
            // Update data into database
            ProductService.UpdateData(Product);

            // After updating return to index page
            return RedirectToPage("./Index");
        }
    }
}