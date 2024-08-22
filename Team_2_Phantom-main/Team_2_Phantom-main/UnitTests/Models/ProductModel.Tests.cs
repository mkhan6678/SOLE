using Microsoft.Extensions.DependencyInjection;
using Bunit;
using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
//using ContosoCrafts.WebSite.Components;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Models
{
    public class ProductModelTests
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }
         #endregion TestSetup
        
        /// <summary>
        /// Test Product Model Valid to String should return String
        /// </summary>
        [Test]
        public void ProductModel_Valid_ToString_Should_Return_String()
        {
            // Arrange
            var data = new ProductModel() { Title = "ExampleTitle" };
            
            // Act
            var result = data.ToString();
            
            // Assert
             Assert.AreEqual(true, result.Contains("ExampleTitle"));
        }
    }
}