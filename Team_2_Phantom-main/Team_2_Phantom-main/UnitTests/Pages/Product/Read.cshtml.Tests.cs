using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Read
{   /// <summary>
    /// This class holds the tests for Read.cshtml.Tests.cs 
    /// </summary>
    public class ReadTests
    {
        #region TestSetup
        public static ReadModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new ReadModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Validate if onget is returning products
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            // Act
            pageModel.OnGet("Product_2");
            // Assert
            Assert.AreEqual("Mac Book Air 2017 model, used very less, ver cool and fast for daily use and student related activities", pageModel.Product.Description);
        }

        /// <summary>
        /// Validate if onget is returning string
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products_ToString()
        {
            // Arrange
            pageModel.OnGet("Product_2");
            // Act
            string dogString = pageModel.Product.ToString();
            // Assert
            Assert.IsNotNull(dogString);
        }

        #endregion OnGet
    }
}