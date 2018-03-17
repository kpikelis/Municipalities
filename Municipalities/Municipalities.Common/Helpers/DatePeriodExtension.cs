using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog.Targets;
using Municipalities.Data.Entities.Enums;

namespace Municipalities.Common.Helpers
{
    public static class DatePeriodExtension
    {
        public static DateTime AddPeriod(this DateTime date, Period period)
        {
            switch (period)
            {
                case Period.Day:
                    return date.AddDays(1).Date;
                case Period.Week:
                    return date.AddDays(7).Date;
                case Period.Month:
                    return date.AddMonths(1).Date;
                case Period.Year:
                    return date.AddYears(1).Date;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
