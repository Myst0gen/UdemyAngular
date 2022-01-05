using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Core.interfaces;
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
        private readonly IProductRepository _product;

        public ProductController(ILogger<ProductController> logger, IProductRepository product)
        {
            this._product = product;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var result = await _product.GetProductsListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var result = await _product.GetProductByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("brands")]
        public async Task<ActionResult> GetProductBrands()
        {
            var result = await _product.GetProductBrandsAsync();
            return Ok(result);
        }

        [HttpGet("types")]
        public async Task<ActionResult> GetProductTypes()
        {
            var result = await _product.GetProductTypesAsync();
            return Ok(result);
        }

    }
}