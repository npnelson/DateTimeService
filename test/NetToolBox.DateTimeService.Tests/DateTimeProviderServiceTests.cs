using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace NetToolBox.DateTimeService.Tests
{
    public class DateTimeProviderServiceTests
    {

        [Fact]
        public void ServiceCollectionTest()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDateTimeService();
            serviceCollection.AddSingleton<TestRepository>();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var repo = serviceProvider.GetRequiredService<TestRepository>();
            var dt = repo.GetCurrentDateTime();
            dt.Should().BeCloseTo(DateTime.UtcNow);
        }

        private class TestRepository
        {
            private readonly IDateTimeService _dateTimeService;

            public TestRepository(IDateTimeService dateTimeService)
            {
                _dateTimeService = dateTimeService;
            }

            public DateTime GetCurrentDateTime()
            {
                return _dateTimeService.CurrentDateTimeUTC;
            }
        }
    }
}
