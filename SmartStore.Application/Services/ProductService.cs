using SmartStore.Application.DTOs;
using SmartStore.Application.Interfaces;
using SmartStore.Domain.Entities;

namespace SmartStore.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<ProductDto>> GetAllAsync(CancellationToken ct)
    {
        var items = await _repo.GetAllProductsAsync(ct);
        return items.Select(p => new ProductDto(p.Id, p.Name, p.Price, p.Stock, p.IsActive)).ToList();
    }

    public async Task<ProductDto?> GetByIdAsync(int id, CancellationToken ct)
    {
        var p = await _repo.GetProductByIdAsync(id, ct);
        return p is null ? null : new ProductDto(p.Id, p.Name, p.Price, p.Stock, p.IsActive);
    }

    public async Task<int> CreateAsync(string name, decimal price, int stock, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required");
        if (price <= 0) throw new ArgumentException("Price must be > 0");
        if (stock < 0) throw new ArgumentException("Stock can't be negative");

        var entity = new Product { Name = name.Trim(), Price = price, Stock = stock };
        return await _repo.AddProductAsync(entity, ct);
    }

    public async Task<bool> UpdateAsync(int id, string name, decimal price, int stock, bool isActive, CancellationToken ct)
    {
        var p = await _repo.GetProductByIdAsync(id, ct);
        if (p is null) return false;

        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name is required");
        if (price <= 0) throw new ArgumentException("Price must be > 0");
        if (stock < 0) throw new ArgumentException("Stock can't be negative");

        p.Name = name.Trim();
        p.Price = price;
        p.Stock = stock;
        p.IsActive = isActive;

        await _repo.UpdateProductAsync(p, ct);
        return true;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct)
    {
        var p = await _repo.GetProductByIdAsync(id, ct);
        if (p is null) return false;

        await _repo.DeleteProductAsync(p, ct);
        return true;
    }
}
