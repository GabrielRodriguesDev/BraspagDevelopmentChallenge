using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DevelopmentChallenge.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        IDbTransaction CurrentTransaction();
    }
}