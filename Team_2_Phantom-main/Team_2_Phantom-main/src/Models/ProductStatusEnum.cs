// This file meets the code guidelines
/// Numbers are defined to categories for the easy readability



namespace ContosoCrafts.WebSite.Models
{
    // Enum for product status
    public enum ProductStatusEnum
    {
        Available = 1,
        Unavailable = 0
    }

    /// <summary>
    /// Enum class for Product status
    /// </summary>
    public static class ProductStatuEnumExtensions
    {

        /// <summary>
        /// Get the Availability Status
        /// </summary>
        /// <param name="data"></param>
        /// <returns>ProductType</returns>

        public static string DisplayName(this ProductStatusEnum data)
        {
            return data switch
            {
                ProductStatusEnum.Available => "Available",
                ProductStatusEnum.Unavailable => "Unavailable",
                // Default, Unknown
                
            };
        }
    }
}