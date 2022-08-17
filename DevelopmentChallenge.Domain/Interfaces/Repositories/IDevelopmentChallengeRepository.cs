using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevelopmentChallenge.Domain.Entities;
using DevelopmentChallenge.Domain.Queries.Result;

namespace DevelopmentChallenge.Domain.Interfaces.Repositories
{
    public interface IDevelopmentChallengeRepository
    {
        IEnumerable<MDRQueryResult> GetAllMDR();

        IEnumerable<Taxa> GetlAllTaxa();

        Decimal SearchRate(string tipo, string bandeira, string adquirente);
    }
}