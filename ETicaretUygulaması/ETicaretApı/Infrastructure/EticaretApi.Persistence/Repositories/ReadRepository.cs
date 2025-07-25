﻿using ETicaretApi.Application.Repositories;
using ETicaretApi.Domain.Entities.Common;
using ETicaretApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretApi.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;
        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
var query =  Table.AsQueryable();
            if(!tracking) query =  query.AsNoTracking();
            return query;
        } 
         

        public async Task<T> GetByIdAsync(Guid id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if(tracking) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data =>data.Id == id);
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if(!tracking) query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if(tracking) query = query.AsNoTracking(); return query;
        }
    }
}
