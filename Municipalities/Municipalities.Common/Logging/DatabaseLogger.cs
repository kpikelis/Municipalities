using System;
using System.Globalization;
using Municipalities.Common.Constants;
using NLog;

namespace Municipalities.Common.Logging
{
    public class DatabaseLogger : IDatabaseLogger
    {
        private readonly Logger _logger;

        public DatabaseLogger()
        {
            _logger = LogManager.GetLogger(LoggerType.Database);
        }

        public void Info(string additionalInfoMessage)
        {
            Log(null, additionalInfoMessage, LogLevel.Info);
        }

        public void Warn(Exception exception, string additionalInfoMessage)
        {
            Log(exception, additionalInfoMessage, LogLevel.Warn);
        }

        public void Error(Exception exception, string additionalInfoMessage)
        {
            Log(exception, additionalInfoMessage, LogLevel.Error);
        }

        private void Log(Exception exception, string additionalInfoMessage, LogLevel level)
        {
            var logEventInfo = new LogEventInfo(level, _logger.Name, CultureInfo.InvariantCulture, additionalInfoMessage, null, exception);

            GlobalDiagnosticsContext.Set("timestamp", DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK"));

            _logger.Log(typeof(DatabaseLogger), logEventInfo);
        }
    }
}
