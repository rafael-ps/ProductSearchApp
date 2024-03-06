using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSearchApp.Server.Entities;
using ProductSearchApp.Server.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductSearchApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository DbContext;
        public ProductsController(IProductRepository dbContext)
        {
            DbContext = dbContext;   
        }
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<ItemProduct> Get()
        {
            return [new ItemProduct("One", 100.00), new ItemProduct("Two,", 200.00)];
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ItemProduct Get(int id)
        {
            var itemProduct = DbContext.GetProductById(id);
            return itemProduct;
        }
        

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] ItemProduct value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
