using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevelopmentChallenge.Database;
using DevelopmentChallenge.Database.Contexts;
using DevelopmentChallenge.Database.Repositories;
using DevelopmentChallenge.Domain.Interfaces;
using DevelopmentChallenge.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DevelopmentChallenge.CrossCutting
{
    public class ConfigureRepository
    {
        public static void Config(IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("Connection_db");
            services.AddDbContext<DevelopmentChallengeContext>(options => options.UseSqlite(connectionString!));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IDevelopmentChallengeRepository, DevelopmentChallengeRepository>();
            services.AddScoped<IDevelopmentChallengeRepository, DevelopmentChallengeRepository>();
        }
    }
}