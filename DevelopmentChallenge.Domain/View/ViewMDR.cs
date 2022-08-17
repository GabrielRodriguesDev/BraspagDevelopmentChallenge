using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Domain.View
{
    public class ViewMDR
    {
        public String Adquirinte { get; set; } = null!;
        public List<ViewTaxa> Taxa { get; set; } = null!;
    }
}