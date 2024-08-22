using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Models
{
    public class ProductStatusEnumExtensionsTests
    {
        /// <summary>
        /// Validation for DisplayName method for productStatus that is Available Type
        /// </summary>
        [Test]
        public void DisplayName_ProductStatus_Available_Should_Return_Available()
        {
            ProductStatuEnumExtensions.DisplayName(ProductStatusEnum.Available);
            Assert.AreEqual("Available", ProductStatuEnumExtensions.DisplayName(ProductStatusEnum.Available));
        }

        /// <summary>
        /// Validation for DisplayName method for productStatus that is Unavailable Type
        /// </summary>
        [Test]
        public void DisplayName_ProductStatus_Unavailable_Should_Return_UnAvailable()
        {
            ProductStatuEnumExtensions.DisplayName(ProductStatusEnum.Unavailable);
            Assert.AreEqual("Unavailable", ProductStatuEnumExtensions.DisplayName(ProductStatusEnum.Unavailable));
        }

    }
}
