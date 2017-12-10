using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
    public class LogAttribute : Attribute
    {
        private readonly ILogger _logger;
        private readonly LoggerFactory logFactory = new LoggerFactory();
        public LogAttribute(string loggerName)
        {
            _logger = logFactory.CreateLogger(loggerName);
        }

        public void LogInfo(string msg)
        {
            var objectType = this.GetType();
            _logger.LogInformation(msg);
        }
    }
}
