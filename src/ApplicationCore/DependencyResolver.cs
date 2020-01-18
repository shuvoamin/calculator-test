using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationCore
{
    public static class DependencyResolver
    {
        public static void ResolveAll(IServiceCollection services)
        {
            services.AddScoped<IProbabilityCalculationService, ProbabilityCalculationService>();
        }
    }
}
