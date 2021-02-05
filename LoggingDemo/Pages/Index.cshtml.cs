using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingDemo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger _logger; //<IndexModel>

        //Default Initialization
        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}
        public IndexModel(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger("DemoCategory");
        }

        public void OnGet()
        {
            _logger.LogTrace("Trace log");
            _logger.LogDebug("Debug log");
            _logger.LogInformation(LoggingId.DemoCode, "Information log");
            _logger.LogWarning("Warning log");
            _logger.LogError("Error Log");
            _logger.LogCritical("Critical log");

            _logger.LogError("Server went down at {Time}", DateTime.UtcNow);

            try
            {
                throw new DivideByZeroException();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"Exception at {Time}", DateTime.UtcNow);
            }
        }
    }

    public class LoggingId
    {
        public const int DemoCode = 1001;
    }
}
