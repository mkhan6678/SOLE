using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using ContosoCrafts.WebSite.Models;

using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
    /// <summary>
    /// Service file which does CRUDi operations for the website
    /// </summary>
    public class JsonFileProductService
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="webHostEnvironment"></param>
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// This method gets called by the runtime.
        /// </summary>
        public IWebHostEnvironment WebHostEnvironment { get; }

        /// <summary>
        /// Get the root path for products.json file
        /// </summary>
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        /// <summary>
        /// Get the list of Products for the index page
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProductModel> GetProducts()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                //Read the Products from JsonFile
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Update the details of a particular product
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public ProductModel UpdateData(ProductModel data)
        {
            // Get the current set of products
            var products = GetProducts();
            // Get the product details of the data
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));

            // Update the product details with new values
            productData.Title = data.Title;
            productData.Description = data.Description;
            productData.Url = data.Url;
            productData.Image = data.Image;
            productData.SellerName = data.SellerName;
            productData.SellerContact = data.SellerContact;
            productData.SellerEmail = data.SellerEmail;
            productData.Price = data.Price;
            // Update the avaialbility status based on the enum value 
            if (data.AvailabilityStatus == "1")
            {
                productData.AvailabilityStatus = "Available";
            }
            if (data.AvailabilityStatus == "0")
            {
                productData.AvailabilityStatus = "Unavailable";
            }

            // Save the new products list after updating the product with id
            SaveData(products);

            return productData;
        }

        /// <summary>
        /// Delete the product data from the products list
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetProducts();
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            //Get the current products list without the product that want to be deleted
            var newDataSet = GetProducts().Where(m => m.Id.Equals(id) == false);
            
            //Save the new products list after removing the product with id
            SaveData(newDataSet);

            return data;
        }

        /// <summary>
        /// Save the create/updated products list to json
        /// </summary>
        /// <param name="products"></param>
        private void SaveData(IEnumerable<ProductModel> products)
        {

            using (var outputStream = File.Create(JsonFileName))
            {
                //Write the Products data to JsonFileName
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }

        /// <summary>
        /// Create a new product from CreatePage
        /// </summary>
        /// <returns>return newly created product</returns>
        public ProductModel CreateData(ProductModel data)
        {
            data.Id = System.Guid.NewGuid().ToString();
            data.AvailabilityStatus = "Available";
            // Get the current set, and append the new record to it becuase IEnumerable does not have Add
            var dataSet = GetProducts();
            dataSet = dataSet.Append(data);

            // Update the products.json with newly created products
            SaveData(dataSet);

            //Return newly created data
            return data;
        }

        /// <summary>
        /// Add rating to the product displayed on the list
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="rating"></param>
        /// <returns></returns>
        public bool AddRating(string productId, int rating)
        {
            // If the ProductID is invalid, return
            if (string.IsNullOrEmpty(productId))
            {
                return false;
            }

            var products = GetProducts();

            // Look up the product, if it does not exist, return
            var data = products.FirstOrDefault(x => x.Id.Equals(productId));
            if (data == null)
            {
                return false;
            }

            // Check Rating for boundries, do not allow ratings below 0
            if (rating < 0)
            {
                return false;
            }

            // Check Rating for boundries, do not allow ratings above 5
            if (rating > 5)
            {
                return false;
            }

            // Check to see if the rating exist, if there are none, then create the array
            if (data.Ratings == null)
            {
                data.Ratings = new int[] { };
            }

            // Add the Rating to the Array
            var ratings = data.Ratings.ToList();
            ratings.Add(rating);
            data.Ratings = ratings.ToArray();

            // Save the data back to the data store
            SaveData(products);

            return true;
        }
    }
}