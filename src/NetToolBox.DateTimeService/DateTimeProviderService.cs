using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("NetToolBox.DateTimeService.Tests")]

namespace NetToolBox.DateTimeService
{
    public sealed class DateTimeProviderService : IDateTimeService
    {
        /// <summary>
        /// Returns the current system time in UTC
        /// </summary>
        public DateTime CurrentDateTimeUTC => new DateTime(DateTime.UtcNow.Ticks, DateTimeKind.Unspecified);

        public DateTimeOffset CurrentDateTimeOffset => System.DateTimeOffset.Now;
    }
}