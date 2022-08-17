using System.Data.Common;
using Dapper;
using DevelopmentChallenge.Database.Contexts;
using DevelopmentChallenge.Domain.Entities;
using DevelopmentChallenge.Domain.Interfaces;
using DevelopmentChallenge.Domain.Interfaces.Repositories;
using DevelopmentChallenge.Domain.Queries;
using DevelopmentChallenge.Domain.Queries.Result;
using Microsoft.EntityFrameworkCore;

namespace DevelopmentChallenge.Database.Repositories
{
    public class DevelopmentChallengeRepository : IDevelopmentChallengeRepository
    {
        protected DevelopmentChallengeContext _context;
        protected DbConnection _connection;

        protected IUnitOfWork _uow;

        public DevelopmentChallengeRepository(DevelopmentChallengeContext context, IUnitOfWork uow)
        {
            _context = context;
            _connection = _context.Database.GetDbConnection();
            _uow = uow;
        }

        public IEnumerable<MDRQueryResult> GetAllMDR()
        {
            return _connection.Query<MDRQueryResult>(DevelopmentChallengeQueries.GetAllMDR(), null, _uow.CurrentTransaction());
        }

        public IEnumerable<Taxa> GetlAllTaxa()
        {
            return _connection.Query<Taxa>(DevelopmentChallengeQueries.GetAllTaxas(), null, _uow.CurrentTransaction());
        }

        public decimal SearchRate(string tipo, string bandeira, string adquirente)
        {
            return _connection.QueryFirstOrDefault<Decimal>(DevelopmentChallengeQueries.searchInformationCalculateValue(tipo), new { Bandeira = bandeira, Adquirente = adquirente }, _uow.CurrentTransaction());
        }
    }
}