using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Domain.Entities
{
    public class BaseEntity
    {
        public String Id { get; private set; }


        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}