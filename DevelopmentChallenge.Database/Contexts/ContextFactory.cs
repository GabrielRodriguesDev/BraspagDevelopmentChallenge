using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DevelopmentChallenge.Database.Contexts
{
    public class ContextFactory : IDesignTimeDbContextFactory<DevelopmentChallengeContext>
    {


        public DevelopmentChallengeContext CreateDbContext(string[] args)
        {
            var connectionString = "Data Source=DevelopmentChallenge.db";
            var optionsBuilder = new DbContextOptionsBuilder<DevelopmentChallengeContext>();
            optionsBuilder.UseSqlite(connectionString);
            return new DevelopmentChallengeContext(optionsBuilder.Options);
        }
    }
}