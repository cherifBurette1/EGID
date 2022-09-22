using EGID.Service.Features.Common.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace EGID.Presistance.Features.Common.Implementation
{
    public class DatabaseTransaction : IDatabaseTransaction
    {
        private IDbContextTransaction _transaction;
        public DatabaseTransaction(IEGIDEntities context)
        {
            _transaction = context.Database.BeginTransaction();
        }

        public async Task CommitAsync()
        {
            await _transaction.CommitAsync();
        }
        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
        }
        public async ValueTask DisposeAsync()
        {
            await _transaction.DisposeAsync();
        }

    }
}
