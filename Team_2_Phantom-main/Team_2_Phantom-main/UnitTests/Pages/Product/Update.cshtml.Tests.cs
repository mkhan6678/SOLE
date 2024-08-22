using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Models;
using System;

namespace UnitTests.Pages.Product.Update
{   /// <summary>
    /// This class holds the tests for the Update.cshtml.Tests.cs
    /// </summary>
    public class UpdateTests
    {
        #region TestSetup
        public static UpdateModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            pageModel = new UpdateModel(TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        #region OnGet
        /// <summary>
        /// Testing setup before execution of test cases
        /// </summary>
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("Product_2");

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Mac Book Air 2017 model, used very less, ver cool and fast for daily use and student related activities", pageModel.Product.Description);
        }

        /// <summary>
        /// From onget method test a valid result
        /// </summary>
        [Test]
        public void OnGet_InValid_Should_Not_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet("Mac");

            // Assert

            Assert.IsNull(pageModel.Product);
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


            pageModel.OnGet("Product_4");
            // Act
            var result = pageModel.OnPost() as RedirectToPageResult;

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, result.PageName.Contains("Index"));
        }

        /// <summary>
        /// with onpost method test an invalid result
        /// </summary>
        [Test]
        public void OnPostAsync_InValid_Model_NotValid_Return_Page()
        {
            // Arrange
            pageModel.Product = new ProductModel
            {
                Id = "bogus",
              Maker="Bogus",
                Description = "bogus",
                Url = "bogus",
                Image = "bougs"
            };

            // Force an invalid error state
            pageModel.ModelState.AddModelError("bogus", "bogus error");

            // Act
            var result = pageModel.OnPost() as ActionResult;

            // Assert
            Assert.AreEqual(false, pageModel.ModelState.IsValid);
        }
            #endregion OnPostAsync
    }
}