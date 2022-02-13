using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
        {
            this._context = context;
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            var result = await _context.Set<T>().FindAsync(Id);
            return result;
        }



        public async Task<IReadOnlyList<T>> GetListAsync()
        {
            var result = await _context.Set<T>().ToListAsync();
            return result;
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecifications<T> spec)
        {
            var result = await ApplySpecification(spec).ToListAsync();
            return result;
        }
        public async Task<T> GetEntityWithSpec(ISpecifications<T> spec)
        {
            var result = await ApplySpecification(spec).FirstOrDefaultAsync();
            return result;
        }
        public async Task<int> CountAsync(ISpecifications<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecifications<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

    }
}