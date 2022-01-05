using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            this._context = context;
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            var result = await _context.ProductBrands.ToListAsync();
            return result;
        }

        public async Task<Product> GetProductByIdAsync(int Id)
        {
            var result = await this._context.Products
                        .Include(p => p.ProductType)
                        .Include(p => p.ProductBrand)
                        .FirstOrDefaultAsync();
            return result;
        }

        public async Task<IReadOnlyList<Product>> GetProductsListAsync()
        {
            var result = await this._context.Products
                        .Include(p => p.ProductType)
                        .Include(p => p.ProductBrand)
                        .ToListAsync();
            return result;
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            var result = await _context.ProductTypes.ToListAsync();
            return result;
        }
    }
}