using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;

namespace UnitTests.Pages.Product.Delete
{  
    /// <summary>
    /// This class holds the tests for the Delete.cshtml.Tests.cs
    /// </summary>
    public class DeleteTests
    {
        #region TestSetup
        public static DeleteModel pageModel;
    
        /// <summary>
        /// SetUp test before execution
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            pageModel = new DeleteModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        
        /// <summary>
        /// Testing a valid results on OnGet method  
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_ProductToDelete()
        {
            // Arrange

            // Act
            pageModel.OnGet("Product_2");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("MAC Book Air - A Decent Macbook AIR 2017 model", pageModel.Product.Title);
        }
        #endregion OnGet

        #region OnPost
       
        /// <summary>
        /// Testing a valid results on OnPost method  
        /// </summary>
        [Test]
        public void OnPost_Valid_Should_DeleteProduct()
        {
            // Arrange

            // By calling CreateData create the product to delete
            // We will create a product that "
            var newData = new ProductModel()
            {
            };
            pageModel.Product = TestHelper.ProductService.CreateData(newData);
            pageModel.Product.Title = "MAC Book Air - A Decent Macbook AIR 2017 model";
            TestHelper.ProductService.UpdateData(pageModel.Product);

            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));

            // Confirm the item is deleted
            Assert.AreEqual(null, TestHelper.ProductService.GetProducts().FirstOrDefault(m => m.Id.Equals(pageModel.Product.Id)));
        }

        /// <summary>
        /// Testing a invalid results on OnPost method  
        /// </summary>
        [Test]
        public void OnPost_InValid_Model_NotValid_Return_Page()
        {
            // Arrange

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
        #endregion OnPost
    }
}