using System;

namespace Municipalities.Common.Logging
{
    public interface IDatabaseLogger
    {
        void Info(string message);
        void Warn(Exception exception, string additionalInfoMessage);
        void Error(Exception exception, string additionalInfoMessage);
    }
}
