using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ProductManagementAPI.Product;

public interface IProductRepository
{
    Task<List<Product>> GetProducts();
    Task<List<Product>> GetProductByCategoryId(int categoryId);
    Task<List<Product>> GetProductBySubCategoryId(int subCategoryId);
    Task CreateProduct(Product product);
    Task UpdateProduct(Product product);
    Task DeleteProduct(int productId);
}
public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ProductRepository(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CreateProduct(Product product)
    {
        var entity = _mapper.Map<ProductEntity>(product);
        _context.Products.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProduct(int productId)
    {
        var entity = await _context.Products.FirstOrDefaultAsync(x => x.Id == productId);
        if (entity == null)
            return;

        _context.Products.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Product>> GetProductByCategoryId(int categoryId)
    {
        var entities = await _context.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
        return _mapper.Map<List<Product>>(entities);
    }

    public async Task<List<Product>> GetProductBySubCategoryId(int subCategoryId)
    {
        var entities = await _context.Products.Where(x => x.SubCategoryId == subCategoryId).ToListAsync();
        return _mapper.Map<List<Product>>(entities);
    }

    public async Task<List<Product>> GetProducts()
    {
        var entities = await _context.Products.ToListAsync();
        return _mapper.Map<List<Product>>(entities);
    }

    public async Task UpdateProduct(Product product)
    {
        var entity = _mapper.Map<ProductEntity>(product);
        if (entity.Id <= 0)
            return;

        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}