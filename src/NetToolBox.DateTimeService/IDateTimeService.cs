using System;

namespace NetToolBox.DateTimeService
{
    public interface IDateTimeService
    {
        DateTime CurrentDateTimeUTC { get; }
    }
}
