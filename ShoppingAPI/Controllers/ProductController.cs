using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using ShoppingAPI.Model;
using ShoppingClient.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        private ILogger<ProductController> _logger;
        private readonly ProductContext _productContext;

        public ProductController(ProductContext productContext,ILogger<ProductController> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _productContext = productContext ?? throw new ArgumentNullException(nameof(productContext));
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productContext.Products.Find(p => true).ToListAsync();
        }
        
    }
}
