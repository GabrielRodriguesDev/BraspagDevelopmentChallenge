using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentChallenge.Database.Mapping
{
    public interface IMapping
    {
        void OnModelCreating(ModelBuilder modelBuilder);
    }
}