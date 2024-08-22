using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Class for Privacy Model
    /// </summary>
    public class PrivacyModel : PageModel
    {
        // Initializing Logger 
        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// Constructor for PrivacyModel
        /// </summary>
        /// <param name="logger"></param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            // Associating logger for Privacy model
            _logger = logger;
        }

        /// <summary>
        /// OnGet Method for PrivacyModel
        /// </summary>
        public void OnGet()
        {
        }
    }
}
