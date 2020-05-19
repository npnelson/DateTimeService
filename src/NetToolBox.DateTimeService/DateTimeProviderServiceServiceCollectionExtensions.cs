using Microsoft.Extensions.DependencyInjection.Extensions;
using NetToolBox.DateTimeService;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DateTimeProviderServiceServiceCollectionExtensions
    {
        /// <summary>
        /// Registers an IDateTimeService in the <see cref="IServiceCollection" />.
        /// </summary>
        /// <example>
        ///     <code>
        ///           public void ConfigureServices(IServiceCollection services)
        ///           {              
        ///               services.AddDateTimeService();
        ///           }
        ///       </code>
        /// </example>
        /// <param name="serviceCollection">The <see cref="IServiceCollection" /> to add services to.</param>
        /// <returns></returns>
        public static IServiceCollection AddDateTimeService(this IServiceCollection serviceCollection)
        {
            serviceCollection.TryAddSingleton<IDateTimeService, DateTimeProviderService>();
            return serviceCollection;
        }
    }
}
