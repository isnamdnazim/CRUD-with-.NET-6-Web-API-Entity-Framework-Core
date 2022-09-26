using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        //public static List<Product> products = new List<Product> { 
        //    new Product
        //    {
        //        Id = 1,
        //        ProductName = "Apple",
        //        ProductDescription = "Good Apple",
        //        Price = 10
        //    }
        //};
        private readonly DataContext _dataContext;
        public ProductController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        { 
            return Ok(await _dataContext.products.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Product>>> Get(int id)
        {
            var product = await _dataContext.products.FindAsync(id);
            if (product == null)
            {
                return BadRequest("Product Not Found");
            }
            return Ok(product);

        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> AddProduct(Product product)
        {
             _dataContext.products.Add(product);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.products.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product product)
        {
            var dbProduct = await _dataContext.products.FindAsync(product.Id);
            if(dbProduct == null)
            {
                return BadRequest("Product Not Found");
            }
            dbProduct.ProductName = product.ProductName;
            dbProduct.ProductDescription = product.ProductDescription;
            dbProduct.Price = product.Price;

            await _dataContext.SaveChangesAsync();
            return Ok( await _dataContext.products.ToListAsync()); 
            
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Product>>> Delete (int id)
        {
            var product = await _dataContext.products.FindAsync(id);
            if(product == null)
            {
                return BadRequest("Product Not Found");
            }
             _dataContext.products.Remove(product);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.products.ToListAsync());
        }
    }
}
