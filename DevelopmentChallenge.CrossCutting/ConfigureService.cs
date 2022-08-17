using DevelopmentChallenge.Domain.Interfaces.Services;
using DevelopmentChallenge.Domain.Servicesss;
using Microsoft.Extensions.DependencyInjection;

namespace DevelopmentChallenge.CrossCutting
{
    public class ConfigureService
    {
        public static void Config(IServiceCollection services)
        {
            services.AddScoped<IDevelopmentChallengeService, DevelopmentChallengeService>();
        }
    }
}