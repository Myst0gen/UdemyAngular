using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsSpecifications : BaseSpecification<Product>
    {
        public ProductsSpecifications()
        {
            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
        }

        public ProductsSpecifications(int id)
        : base(x => x.Id == id)
        {
            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
        }
    }
}