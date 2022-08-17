using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Domain.View
{
    public class ViewTaxa
    {
        public String Bandeira { get; private set; } = null!;
        public Double Credito { get; private set; }
        public Double Debito { get; private set; }
    }
}