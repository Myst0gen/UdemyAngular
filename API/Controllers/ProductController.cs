using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Helpers;
using AutoMapper;
using Core.Entities;
using Core.interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IGenericRepository<Product> _product;
        private readonly IGenericRepository<ProductBrand> _productBrand;
        private readonly IGenericRepository<ProductType> _productType;
        private readonly IMapper _mapper;

        public ProductController(ILogger<ProductController> logger,
        IGenericRepository<Product> product, IGenericRepository<ProductBrand> productBrand,
        IGenericRepository<ProductType> productType, IMapper mapper)
        {
            this._product = product;
            this._productBrand = productBrand;
            this._productType = productType;
            this._mapper = mapper;
            _logger = logger;

        }

        [HttpGet]
        public async Task<ActionResult> GetProducts([FromQuery] ProductSpecParams specParams)
        {
            var spec = new ProductsSpecifications(specParams);
            var Countspec = new ProductWithFiltersSpecification(specParams);
            var totalItems = await _product.CountAsync(Countspec);
            var result = await _product.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDTO>>(result);
            return Ok(new Pagination<ProductDTO>(specParams.pageIndex, specParams.pageSize
            , totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var spec = new ProductsSpecifications(id);
            var result = await _product.GetEntityWithSpec(spec);
            return Ok(_mapper.Map<Product, ProductDTO>(result));
        }

        [HttpGet("brands")]
        public async Task<ActionResult> GetProductBrands()
        {
            var result = await _productBrand.GetListAsync();
            return Ok(result);
        }

        [HttpGet("types")]
        public async Task<ActionResult> GetProductTypes()
        {
            var result = await _productType.GetListAsync();
            return Ok(result);
        }

    }
}