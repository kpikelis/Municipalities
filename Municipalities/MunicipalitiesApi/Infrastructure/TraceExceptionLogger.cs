using System.Web.Http.ExceptionHandling;
using Municipalities.Common.Logging;

namespace MunicipalitiesApi.Infrastructure
{
    /// <summary>
    /// Logs exception when it occurs
    /// </summary>
    public class TraceExceptionLogger : ExceptionLogger
    {
        private readonly IDatabaseLogger _logger;

        public TraceExceptionLogger(IDatabaseLogger logger)
        {
            _logger = logger;
        }

        public override void Log(ExceptionLoggerContext context)
        {
            _logger.Error(context.ExceptionContext.Exception, context.Request.RequestUri.ToString());
        }
    }
}