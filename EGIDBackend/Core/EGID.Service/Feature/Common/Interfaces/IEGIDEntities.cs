using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using EGID.Data.Entities;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
namespace EGID.Service.Features.Common.Interfaces
{
    public interface IEGIDEntities : IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        bool SaveChanges(bool enableAuditLog = true);
        Task<bool> SaveChangesAsync(bool enableAuditLog = true, CancellationToken cancellationToken = default);
        bool GetLazyLoadingEnabledFlag();
        Task ExecuteQuery(string queryString);
        IDbConnection GetDbContextConnection();
        DatabaseFacade Database { get; }

        #region Tables
        DbSet<Stock> Stocks { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Data.Entities.Broker> Brokers { get; set; }
        DbSet<Data.Entities.Person> Persons { get; set; }
        #endregion

    }
}
