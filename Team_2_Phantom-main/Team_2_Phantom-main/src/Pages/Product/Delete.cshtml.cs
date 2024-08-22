using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;

using ContosoCrafts.WebSite.Services;

using Microsoft.AspNetCore.Mvc;

namespace ContosoCrafts.WebSite.Pages.Product
{   /// <summary>
    /// Delete the data for single record.
    /// </summary>
    public class DeleteModel : PageModel
    {
        // Data middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Defualt Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public DeleteModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// REST Get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            Product = ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(id));
        }

        /// <summary>
        /// REST Post request
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Delete data from db
            ProductService.DeleteData(Product.Id);

            // After deleting return to index
            return RedirectToPage("./Index");
        }
    }
}