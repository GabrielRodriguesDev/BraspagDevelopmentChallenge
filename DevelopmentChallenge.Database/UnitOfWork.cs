using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DevelopmentChallenge.Database.Contexts;
using DevelopmentChallenge.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace DevelopmentChallenge.Database
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
#nullable disable


        private DevelopmentChallengeContext _context;

        private IDbContextTransaction _dbContextTransaction;

        public UnitOfWork(DevelopmentChallengeContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _dbContextTransaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_dbContextTransaction == null)
                throw new Exception("Transação não iniciada");

            _context.SaveChangesAsync().Wait();
            _dbContextTransaction.CommitAsync().Wait();
            _context.ChangeTracker.Clear();
            _dbContextTransaction = null;
        }

        public IDbTransaction CurrentTransaction()
        {
            IDbTransaction result = null;
            if (_dbContextTransaction != null)
                result = _dbContextTransaction.GetDbTransaction();
            return result;
        }

        public void Dispose()
        {
            if (_dbContextTransaction != null)
                _dbContextTransaction.DisposeAsync();
        }

        public void Rollback()
        {
            if (_dbContextTransaction != null)
                _dbContextTransaction.RollbackAsync().Wait();
        }
    }
}