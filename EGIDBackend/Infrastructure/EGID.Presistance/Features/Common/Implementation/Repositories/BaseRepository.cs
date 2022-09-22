using Microsoft.EntityFrameworkCore;
using EGID.Service.Features.Common.Interfaces;
using EGID.Service.Features.Common.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EGID.Presistance.Features.Common.Implementation.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        /*
         Please Don't return IQueryable<> result for any public method in any repository,
         Just return List<> to separate services business logic from db logic
         */

        private readonly IEGIDEntities _context;

        public BaseRepository(IEGIDEntities context)
        {
            _context = context;
        }
        protected IEGIDEntities EGIDEntities => _context;
        public async Task Create(T t)
        {
            await EGIDEntities.Set<T>().AddAsync(t);
        }
        public async Task Create(List<T> t)
        {
            await EGIDEntities.Set<T>().AddRangeAsync(t);
        }
        public async Task Remove(T t)
        {
            await Task.Run(() => EGIDEntities.Set<T>().Remove(t));
        }
        public async Task Remove(List<T> t)
        {
            await Task.Run(() => EGIDEntities.Set<T>().RemoveRange(t));
        }
        public async Task<List<T>> FindAll()
        {
            return await EGIDEntities.Set<T>().ToListAsync();
        }
        public async Task<List<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await EGIDEntities.Set<T>().Where(predicate).ToListAsync();
        }
        public async Task<T> FindOne(Expression<Func<T, bool>> predicate)
        {
            return await EGIDEntities.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public void Attach(T t) => EGIDEntities.Set<T>().Attach(t);
    }
}
