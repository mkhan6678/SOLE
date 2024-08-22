namespace UnitTests.Components
{
    using System.Linq;
    using Bunit;
    using ContosoCrafts.WebSite.Components;
    using ContosoCrafts.WebSite.Services;

    using Microsoft.Extensions.DependencyInjection;

    using NUnit.Framework;


    /// <summary>
    /// Article list test set.
    /// </summary>
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup
        /// <summary>
        /// Initialize the test set.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup
        /// <summary>
        /// Test for returning list of Products.
        /// </summary>
        [Test]
        public void ProductList_Default_Should_Return_Content()
        {
            // Arrange
            _ = Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);



            // Act
            // Act
            var page = RenderComponent<ProductList>(parameters => parameters
                    .Add(p => p.Products, TestHelper.ProductService.GetProducts()));



            // Get the Cards returned
            var result = page.Markup;



            // Assert
            Assert.AreEqual(true, result.Contains("Hooded"));
        }


    }
}
