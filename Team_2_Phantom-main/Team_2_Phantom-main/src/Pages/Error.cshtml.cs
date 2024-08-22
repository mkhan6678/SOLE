using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Class for ErrorModel
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        /// <summary>
        /// Getter Setter for RequestId
        /// </summary>
        public string RequestId { get; set; }

        // Return RequestId if not equal to null
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // Initialize the logger
        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// Constructor for ErrorModel
        /// </summary>
        /// <param name="logger"></param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            // Assign the logger
            _logger = logger;
        }

        /// <summary>
        /// OnGet Method
        /// </summary>
        public void OnGet()
        {
            // Retreive requestId based on traceIdentifier
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}