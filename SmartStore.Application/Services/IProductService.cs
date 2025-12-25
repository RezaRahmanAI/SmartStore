using SmartStore.Application.DTOs;

namespace SmartStore.Application.Services;

public interface IProductService
{
    Task<List<ProductDto>> GetAllAsync(CancellationToken ct);
    Task<ProductDto?> GetByIdAsync(int id, CancellationToken ct);
    Task<int> CreateAsync(string name, decimal price, int stock, CancellationToken ct);
    Task<bool> UpdateAsync(int id, string name, decimal price, int stock, bool isActive, CancellationToken ct);
    Task<bool> DeleteAsync(int id, CancellationToken ct);
}
