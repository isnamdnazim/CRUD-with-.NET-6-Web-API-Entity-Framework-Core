using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> products = new List<Product> { 
            new Product
            {
                Id = 1,
                ProductName = "Apple",
                ProductDescription = "Good Apple",
                Price = 10
            }
        };
        //private readonly DataContext _dataContext;
        //public ProductController(DataContext dataContext)
        //{
        //    _dataContext = dataContext;
        //}

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            
            return Ok(products);
        }

    }
}
