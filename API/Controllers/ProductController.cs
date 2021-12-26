using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly StoreContext _context;

        public ProductController(ILogger<ProductController> logger, StoreContext context)
        {
            this._context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var result = await _context.Products.ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProduct(int id)
        {
            var result = await _context.Products.FindAsync(id);
            return Ok(result);
        }


    }
}