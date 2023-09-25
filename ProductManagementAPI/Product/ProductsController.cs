using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagementAPI.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private List<Category> _categories = new List<Category>()
        {
            new() { Id = 1, Name = "Electronics", SubCategories = new List<SubCategory>() {  new () { Id = 1, Name = "TV"}, new (){ Id = 2, Name ="Mobile"}, new (){Id = 3, Name = "Refrigerator"} } },
            new() { Id = 2, Name = "Appreal", SubCategories = new List<SubCategory>() {  new () { Id = 4, Name = "Mens Cloths" }, new (){ Id = 5, Name = "Womens Cloths" } } },
            new() { Id = 3, Name = "Footwear", SubCategories = new List<SubCategory>() {  new () { Id =6, Name = "Mens Footwear" }, new (){ Id = 7, Name = "Kids Footwear" } } }
        };
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _repository.GetProducts();
        }

        // GET api/<ProductsController>/5
        [HttpGet("GetProductByCategoryId/{categoryId}")]
        public async Task<IEnumerable<Product>> GetProductByCategoryId(int categoryId)
        {
            return await _repository.GetProductByCategoryId(categoryId);
        }

        // GET api/<ProductsController>/5
        [HttpGet("GetProductBySubCategoryId/{subCategoryId}")]
        public async Task<IEnumerable<Product>> GetProductBySubCategoryId(int subCategoryId)
        {
            return await _repository.GetProductBySubCategoryId(subCategoryId);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task Post([FromBody] Product product)
        {
            await _repository.CreateProduct(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public async Task Put([FromBody] Product product)
        {
            await _repository.UpdateProduct(product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.DeleteProduct(id);
        }


        [HttpGet("GetProductCategories")]
        public List<Category> GetProductCategories()
        {
            return _categories;
        }

        [HttpGet("GetProductSubCategories/{categoryId}")]
        public List<SubCategory> GetProductSubCategories(int categoryId)
        {
            return _categories.Where(x => x.Id == categoryId).FirstOrDefault().SubCategories;
        }

    }
}
