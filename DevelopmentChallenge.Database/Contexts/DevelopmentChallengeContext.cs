using System.Reflection;
using DevelopmentChallenge.Database.Mapping;
using DevelopmentChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentChallenge.Database.Contexts
{
    public class DevelopmentChallengeContext : DbContext
    {
#nullable disable

        public DbSet<MDR> MDRs { get; set; }

        public DbSet<Taxa> Taxas { get; set; }

        public DevelopmentChallengeContext(DbContextOptions<DevelopmentChallengeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
                                  where x.IsClass && typeof(IMapping).IsAssignableFrom(x)
                                  select x).ToList();
            foreach (var mapping in typesToMapping)
            {
                IMapping mappingClass = Activator.CreateInstance(mapping) as IMapping;
                if (mappingClass != null)
                    mappingClass.OnModelCreating(modelBuilder);
            }
        }
    }
}