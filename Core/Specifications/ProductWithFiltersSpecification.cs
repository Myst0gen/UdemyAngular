using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductWithFiltersSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersSpecification(ProductSpecParams specParams) : base
        (x =>
        (string.IsNullOrWhiteSpace(specParams.search) || x.Name.ToLower().Contains(specParams.search)) &&
         (!specParams.brandId.HasValue || x.ProductBrandId == specParams.brandId) &&
         (!specParams.typeId.HasValue || x.ProductTypeId == specParams.typeId)
        )
        {
        }
    }
}