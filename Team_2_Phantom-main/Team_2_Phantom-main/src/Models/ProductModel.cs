using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    public class ProductModel
    {

        /// <summary>
        /// Define attributes of Products model
        /// </summary>
        /// <summary>
        /// Getter Setter for Id
        /// </summary>
        public string Id { get; set; }
        
        // Define variable Maker to get assigned and returm a value
        public string Maker { get; set; }

        [JsonPropertyName("img")]
        
        /// <summary>
        /// Getter Setter for image
        /// </summary>
        public string Image { get; set; }
        
        /// <summary>
        /// Getter Setter for Url
        /// </summary>
        public string Url { get; set; }
        
        /// <summary>
        /// Getter Setter for Title
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Getter Setter for Description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Getter Setter for Ratings
        /// </summary>
        public int[] Ratings { get; set; }
        
        /// <summary>
        /// Getter Setter for ProductType
        /// </summary>
        public string ProductType { get; set; }

        /// <summary>
        /// Getter Setter for Price
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Getter Setter for SellerName
        /// </summary>
        public string SellerName { get; set; }
        
        /// <summary>
        /// Getter Setter for SellerContact
        /// </summary>
        public string SellerContact { get; set; }

        /// <summary>
        /// Getter Setter for SellerEmail
        /// </summary>
        public string SellerEmail { get; set; }

        /// <summary>
        /// Getter Setter for AvailabilityStatus
        /// </summary>
        public string AvailabilityStatus { get; set; }

        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);

    }
}