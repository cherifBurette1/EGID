using Microsoft.EntityFrameworkCore;
using EGID.Data.AuditEntites;
using EGID.Service.Features.Common.Interfaces;

namespace EGID.Presistance
{
    public class EGIDAuditDbContext : DbContext, IEGIDAuditDbContext
    {
        public EGIDAuditDbContext(DbContextOptions<EGIDAuditDbContext> options) : base(options)
        {

        }
        public DbSet<EntityAuditLog> EntityAuditLogs { get; set; }
        public DbSet<ProcedureAuditLog> ProcedureAuditLogs { get; set; }
    }
}
