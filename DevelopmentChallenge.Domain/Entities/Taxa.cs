using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Domain.Entities
{
    public class Taxa : BaseEntity
    {
        public String Bandeira { get; private set; } = null!;
        public Double Credito { get; private set; }
        public Double Debito { get; private set; }
        public String MDRId { get; private set; } = null!;
        public MDR MDR { get; private set; } = null!;
    }
}