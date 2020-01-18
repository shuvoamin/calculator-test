using Infrastructure.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyResolver
    {
        public static void ResolveAll(IServiceCollection services)
        {
            services.AddScoped(typeof(IAppLogger<>), typeof(Logging.LoggerAdapter<>));
        }
    }
}
