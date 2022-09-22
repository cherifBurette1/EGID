using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using EGID.Data.AuditEntites;

namespace EGID.Service.Features.Common.Interfaces
{
    public interface IEGIDAuditDbContext
    {
        DbSet<EntityAuditLog> EntityAuditLogs { get; set; }
        DbSet<ProcedureAuditLog> ProcedureAuditLogs { get; set; }


        int SaveChanges(bool acceptAllChangesOnSuccess);

        int SaveChanges();

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
