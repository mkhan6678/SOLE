using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

using NUnit.Framework;

namespace UnitTests.Pages.Startup
{   /// <summary>
    /// Unit test for Startup  
    /// </summary>
    public class StartupTests
    {
        #region TestSetup

        [SetUp]
        /// <summary>
        /// Initializing the tests   
        /// </summary>
        public void TestInitialize()
        {
        }

        /// <summary>
        /// Startup COntosoCrafts website
        /// </summary>
        public class Startup : ContosoCrafts.WebSite.Startup
        {
            public Startup(IConfiguration config) : base(config) { }
        }
        #endregion TestSetup

        #region ConfigureServices
        /// <summary>
        /// After startup, configure services  
        /// </summary>
        [Test]
        public void Startup_ConfigureServices_Valid_Defaut_Should_Pass()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);
        }
        #endregion ConfigureServices

        #region Configure
        /// <summary>
        /// After startup, configure  
        /// </summary>
        [Test]
        public void Startup_Configure_Valid_Defaut_Should_Pass()
        {
            var webHost = Microsoft.AspNetCore.WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            Assert.IsNotNull(webHost);
        }

        #endregion Configure
    }
}