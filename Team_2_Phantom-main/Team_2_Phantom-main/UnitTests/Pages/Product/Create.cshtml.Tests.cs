using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Models;


namespace UnitTests.Pages.Product.Create
{ 
    /// <summary>
    /// This class holds the tests for Create.cshtml.Tests.cs 
    /// </summary>
    public class CreateTests
    {
        #region TestSetup
        public static CreateModel pageModel;

        /// <summary>
        /// SetUp test before execution
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new CreateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Testing a valid results on OnGet method  
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange
            var oldCount = TestHelper.ProductService.GetProducts().Count();

            // Act
            pageModel.OnGet(); // This will actually create a page of dummy data

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(oldCount, TestHelper.ProductService.GetProducts().Count());
        }
        #endregion OnGet


        #region OnPostAsync
        /// <summary>
        /// From onpost method test valid result 
        /// </summary>
        [Test]
        public void OnPostAsync_Valid_Should_Return_Products()
        {
            // Arrange

            pageModel.OnGet();
            var newData = new ProductModel()
            {
            };
            pageModel.Product = newData;
            pageModel.Product.SellerName = "name";
            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            //Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }
        #endregion OnPost
    }
}