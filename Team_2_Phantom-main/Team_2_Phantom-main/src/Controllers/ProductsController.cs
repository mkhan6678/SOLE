using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    /// <summary>
    /// Get the root path for productcontroller file
    /// </summary>
    public class ProductsController : ControllerBase
    {
        /// <summary>
        /// Get the root path for Productsservice.json file
        /// </summary>
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        /// <summary>
        /// Get Products request
        /// </summary>
        public IEnumerable<ProductModel> Get()
        {
            return ProductService.GetProducts();
        }

        [HttpPatch]
        /// <summary>
        /// Add rating to specific product selected
        /// </summary>
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            // Adding rating 
            ProductService.AddRating(request.ProductId, request.Rating);
            
            return Ok();
        }
        /// <summary>
        /// Get Rating request by product Id
        /// </summary>
        public class RatingRequest
        {
            /// <summary>
            /// Getter Setter for ProductId
            /// </summary>
            public string ProductId { get; set; }
            /// <summary>
            /// Getter Setter for Rating
            /// </summary>
            public int Rating { get; set; }
        }
    }
}