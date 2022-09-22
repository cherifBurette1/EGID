using System;
using System.Threading.Tasks;

namespace EGID.Service.Features.Common.Interfaces
{
    public interface IDatabaseTransaction : IAsyncDisposable
    {
        Task CommitAsync();
        Task RollbackAsync();
    }
}
