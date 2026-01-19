using Microsoft.EntityFrameworkCore;
using SmartStore.Application.Interfaces;
using SmartStore.Domain.Entities;
using SmartStore.Infrastructure.Persistence;
namespace SmartStore.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context) => _context = context;


    public async Task<int> AddProductAsync(Product product, CancellationToken ct)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync(ct);
        return product.Id;
    }

    public async Task DeleteProductAsync(Product product, CancellationToken ct)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken ct)
        => await _context.Products.AsNoTracking().OrderByDescending(x => x.Id).ToListAsync(ct);

    public async Task<Product?> GetProductByIdAsync(int id, CancellationToken ct) 
        => await _context.Products.FirstOrDefaultAsync(x => x.Id == id, ct);

    public async Task UpdateProductAsync(Product product, CancellationToken ct)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync(ct);
    }
}
