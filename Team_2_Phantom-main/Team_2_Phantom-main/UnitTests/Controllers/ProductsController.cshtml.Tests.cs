using ContosoCrafts.WebSite.Controllers;
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ContosoCrafts.WebSite.Controllers.ProductsController;

namespace UnitTests.Controllers
{

    /// <summary>
    /// Unit test cases to ProductController
    /// </summary>
    public class ProductsControllerTests
    {

        //Creating and instance TestProductController
        public static ProductsController testProductController;

        /// <summary>
        /// Test initialize
        /// </summary>
        #region TestSetup
        [SetUp]
        public void Testinitialize()
        {
            testProductController = new ProductsController(TestHelper.ProductService);
        }
        #endregion

        /// <summary>
        /// Testing if get is valid should return products
        /// </summary>
        [Test]
        public void Get_Valid_Should_Return_List_Of_Products()
        {
            //Arrange
            var data = testProductController.Get().ToList();

            //Act
            
            //Assert
            Assert.AreEqual(typeof(List<ProductModel>), data.GetType());
        }

        /// <summary>
        /// Testing get valid tostring should return string
        /// </summary>
        [Test]
        public void Get_Valid_ToString_Should_Return_String()
        {
           //Arrange
           var data = testProductController.Get().FirstOrDefault().ToString();

           //Act

           //Assert
           Assert.AreEqual(typeof(string), data.GetType());
        }

        /// <summary>
        /// Testing patch valid shouls return ok
        /// </summary>
        [Test]
        public void Patch_Valid_Should_Return_Ok()
        {
            //Arrange
            //A new variable of type RatingRequest
            var data = new RatingRequest
            {
                ProductId = "",
                Rating = 5
            };

            //Act
            //A variable to hold the request
            var result = testProductController.Patch(data);

            var okResult = result as OkResult;

            //Assert
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}