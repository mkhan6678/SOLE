using System.Linq;

using Microsoft.AspNetCore.Mvc.RazorPages;

using Microsoft.Extensions.Logging;


using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product.Index
{
    public class IndexTests
    {
        #region TestSetup
        public static PageContext pageContext;

        // PageModel 
        public static IndexModel pageModel;

        /// <summary>
        /// Initialize Test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new IndexModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Validate if onget is returning True or not
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true,pageModel.Products.ToList().Any());
        }
        #endregion OnGet

    }
}