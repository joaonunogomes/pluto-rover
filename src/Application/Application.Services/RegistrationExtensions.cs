namespace PlutoRover.Application.Services
{
    using Data.Repository;
    using Microsoft.Extensions.DependencyInjection;
    using System.Collections.Generic;

    public static class RegistrationExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services.AddScoped<IRoversService, RoversService>(p => 
                new RoversService(
                    p.GetRequiredService<IRoverRepository>(),
                    new Dictionary<int, int> { { 1, 12 }, { 56, 13 }, { 36, 1 }, { 22, 100 } }));
        }
    }
}