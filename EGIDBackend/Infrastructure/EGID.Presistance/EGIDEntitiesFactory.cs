using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using EGID.Presistance.Infrastructure;
using EGID.Service.Features.Common.Interfaces.Repositories;

namespace EGID.Presistance
{
    public class EGIDEntitiesFactory : DesignTimeDbContextFactoryBase<EGIDEntities>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuditRepository _auditRepository;

        public EGIDEntitiesFactory(IHttpContextAccessor httpContextAccessor,
            IAuditRepository auditRepository)
        {
            _httpContextAccessor = httpContextAccessor;
            _auditRepository = auditRepository;
        }
        public EGIDEntitiesFactory()
        {

        }
        protected override EGIDEntities CreateNewInstance(DbContextOptions<EGIDEntities> options)
        {
            return new EGIDEntities(options, _auditRepository);
        }
    }
}