using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevelopmentChallenge.Domain.Entities;

namespace DevelopmentChallenge.Domain.Queries.Result
{
    public class MDRQueryResult
    {
        public String Id { get; set; } = null!;
        public String Adquirente { get; set; } = null!;
        public List<Taxa> Taxas { get; set; } = null!;

    }
}