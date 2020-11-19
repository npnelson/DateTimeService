using System;

namespace NetToolBox.DateTimeService.TestHelper
{
    public sealed class TestDateTimeServiceProvider : IDateTimeService
    {
        private DateTimeOffset? _currentDateTimeOffset;

        /// <summary>
        /// Sets the CurrentDateTime for the IDateTimeProvider for testing purposes
        /// </summary>
        /// <param name="dateTime"></param>
        public void SetCurrentDateTimeUTC(DateTime dateTime)
        {
            _currentDateTimeOffset = new DateTimeOffset(dateTime);
        }

        public void SetCurrentDateTimeOffSet(DateTimeOffset dateTimeOffSet)
        {
            _currentDateTimeOffset = dateTimeOffSet;
        }

        /// <summary>
        /// Gets the CurrentDateTime.  Initializes upon first call to then current datetime or can be set explicitly through SetCurrentDateTime
        /// Once CurrentDateTime is set, you must call SetCurrentDateTime to change it, it will not automatically update on its own.
        /// </summary>
        /// <returns></returns>
        public DateTime CurrentDateTimeUTC
        {
            get
            {
                CheckAndSetCurrentDateTime();

#pragma warning disable CS8629 // Nullable value type may be null.
                return new DateTime(_currentDateTimeOffset.Value.UtcDateTime.Ticks, DateTimeKind.Unspecified);
#pragma warning restore CS8629 // Nullable value type may be null.
            }
        }

        public DateTimeOffset CurrentDateTimeOffset
        {
            get
            {
                CheckAndSetCurrentDateTime();
#pragma warning disable CS8629 // Nullable value type may be null.
                return _currentDateTimeOffset.Value;
#pragma warning restore CS8629 // Nullable value type may be null.
            }
        }

        private void CheckAndSetCurrentDateTime()
        {
            if (_currentDateTimeOffset == null)
            {
                //to eliminate some precision problems when using datetime vs datetime2 in SQL, we will take the current time and chop the milliseconds off
                var currentDate = DateTime.UtcNow;
                currentDate = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, currentDate.Hour,
                currentDate.Minute, currentDate.Second);
                _currentDateTimeOffset = new DateTimeOffset(currentDate);
            }
        }

        /// <summary>
        /// Adds seconds to the current DateTime value.
        /// If CurrentDateTime is null it sets it to the DateTime.Now and then adds the seconds
        /// </summary>
        /// <param name="seconds"></param>
        public void AdvanceSeconds(int seconds)
        {
            CheckAndSetCurrentDateTime();
#pragma warning disable CS8629 // Nullable value type may be null.
            _currentDateTimeOffset = _currentDateTimeOffset.Value.AddSeconds(seconds);
#pragma warning restore CS8629 // Nullable value type may be null.
        }

        /// <summary>
        /// Adds seconds to the current DateTime value.
        /// If CurrentDateTime is null it sets it to the DateTime.Now and then adds the minutes
        /// </summary>
        /// <param name="minutes"></param>
        public void AdvanceMinutes(int minutes)
        {
            CheckAndSetCurrentDateTime();
#pragma warning disable CS8629 // Nullable value type may be null.
            _currentDateTimeOffset = _currentDateTimeOffset.Value.AddMinutes(minutes);
#pragma warning restore CS8629 // Nullable value type may be null.
        }

        /// <summary>
        /// Adds seconds to the current DateTime value.
        /// If CurrentDateTime is null it sets it to the DateTime.Now and then adds the days
        /// </summary>
        /// <param name="days"></param>
        public void AdvanceDays(int days)
        {
            CheckAndSetCurrentDateTime();
#pragma warning disable CS8629 // Nullable value type may be null.
            _currentDateTimeOffset = _currentDateTimeOffset.Value.AddDays(days);
#pragma warning restore CS8629 // Nullable value type may be null.
        }
    }
}