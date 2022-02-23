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
        public ProductsSpecifications(ProductSpecParams specParams) : base
        (x =>
         (string.IsNullOrWhiteSpace(specParams.search) || x.Name.ToLower().Contains(specParams.search)) &&
         (!specParams.brandId.HasValue || x.ProductBrandId == specParams.brandId) &&
         (!specParams.typeId.HasValue || x.ProductTypeId == specParams.typeId)
        )
        {
            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
            ApplyPaging(specParams.pageSize * (specParams.pageIndex - 1), specParams.pageSize);

            switch (specParams.sort)
            {
                case "priceAsc":
                    AddOrderBy(p => p.Price);
                    break;
                case "priceDesc":
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(n => n.Name);
                    break;
            }
        }

        public ProductsSpecifications(int id)
        : base(x => x.Id == id)
        {
            AddIncludes(x => x.ProductBrand);
            AddIncludes(x => x.ProductType);
        }
    }
}