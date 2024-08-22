using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using System;

using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Pages.Product
{  
    /// <summary>
    /// Create data for single record 
    /// </summary>
    public class CreateModel : PageModel
    {
        // Data middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public CreateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// REST Get request to create a record
        /// </summary> 
        public void OnGet()
        {
        }

        /// <summary>
        /// Update the database with the new record
        /// </summary>
        public IActionResult OnPost()
        {
            // Update data into database
            ProductService.CreateData(Product);

            // After updating return to index page
            return RedirectToPage("./Index");
        }

    }
    }
