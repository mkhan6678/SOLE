using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.WebSite
{
    public class Program
    {
        /// <summary>
        /// Main method which calls createHostBuilder for the Program
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Create method to create Host builder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
