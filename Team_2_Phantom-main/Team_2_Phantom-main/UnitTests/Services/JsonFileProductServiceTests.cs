using System.Linq;

using Microsoft.AspNetCore.Mvc;

using NUnit.Framework;

using ContosoCrafts.WebSite.Models;
using System;

namespace UnitTests.Pages.Product.AddRating
{
    public class JsonFileProductServiceTests
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region AddRating
        //[Test]
        //public void AddRating_InValid_....()
        //{
        //    // Arrange

        //    // Act
        //    //var result = TestHelper.ProductService.AddRating(null, 1);

        //    // Assert
        //    //Assert.AreEqual(false, result);
        //}

        // ....

        /// <summary>
        /// Test Invalid rating with value null and should return false
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Test Invalid rating with empty value and return false
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Empty_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Test invalid rating for product with invalid id and return false
        /// </summary>
        [Test]
        public void AddRating_Invalid_Product_Id_Should_Return_False()
        {
            // Act
            var result = TestHelper.ProductService.AddRating("test", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Test invalid rating with value below zero and return flase
        /// </summary>
        [Test]
        public void AddRating_Invalid_Rating_Below_Zero_Should_Return_False()
        {
            // Act
            var result = TestHelper.ProductService.AddRating("Product_2", -1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Test invalid rating with value above 5 and return flase
        /// </summary>
        [Test]
        public void AddRating_Invalid_Rating_Above_5_Should_Return_False()
        {
            // Act
            var result = TestHelper.ProductService.AddRating("Product_2", 6);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Test invalid rating with null value and create new ratings array
        /// </summary>
        [Test]
        public void AddRating_Invalid_Ratings_With_Null_Value_Should_Create_Ratings_Array()
        {
            // Act
            var result = TestHelper.ProductService.AddRating("Product_2", 0);

            // Get the data item of the product
            var data = TestHelper.ProductService.GetProducts().First(x => x.Id == "Product_2");
            var newRatings = data.Ratings.Length;

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(newRatings, 1);
        }

        /// <summary>
        /// Test addRating with 5 ratings and return true
        /// </summary>
        [Test]
        public void AddRating_Valid_Product_Rating_5_Should_Return_True()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetProducts().First();
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetProducts().First();

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }
        #endregion AddRating

        /// <summary>
        /// Test updating product detials with updaitng seller contact value and return the updated the value
        /// </summary>
        [Test]
        public void Update_Seller_Contact_Return_Updated_Value()
        {
            // Arrange
            var data = TestHelper.ProductService.GetProducts().FirstOrDefault(x => x.Id.Equals("Product_9"));
            data.SellerContact = "123-123-1234";

            // Act
            var result = TestHelper.ProductService.UpdateData(data);

            // Assert
            Assert.AreEqual("123-123-1234", result.SellerContact);
        }

        /// <summary>
        /// Test updating product detials with updaitng Availability Status value and return the updated the value
        /// </summary>
        [Test]
        public void Update_Availability_Status_1_Return_Updated_Value()
        {
            // Arrange
            var data = TestHelper.ProductService.GetProducts().FirstOrDefault(x => x.Id.Equals("Product_9"));
            data.AvailabilityStatus = "1";

            // Act
            var result = TestHelper.ProductService.UpdateData(data);

            // Assert
            Assert.AreEqual("Available", result.AvailabilityStatus);
        }


        /// <summary>
        /// Test updating product detials with updaitng Availability Status value and return the updated the value
        /// </summary>
        [Test]
        public void Update_Availability_Status_0_Return_Updated_Value()
        {
            // Arrange
            var data = TestHelper.ProductService.GetProducts().FirstOrDefault(x => x.Id.Equals("Product_9"));
            data.AvailabilityStatus = "0";

            // Act
            var result = TestHelper.ProductService.UpdateData(data);

            // Assert
            Assert.AreEqual("Unavailable", result.AvailabilityStatus);
        }

        /// <summary>
        /// Test deletion of product and return updated products list
        /// </summary>
        [Test]
        public void Delete_Product_Return_Updated_Products_List()
        {
            // Arrange
            var newData = new ProductModel()
            {
            };
            var data = TestHelper.ProductService.CreateData(newData);

            // Act
            var deletedProduct = TestHelper.ProductService.DeleteData(data.Id);
            var result = TestHelper.ProductService.GetProducts().FirstOrDefault(x => x.Id.Equals(data.Id));

            // Assert
            Assert.AreEqual(null, result);
        }
    }
}