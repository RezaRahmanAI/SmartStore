using SmartStore.Application.DTOs;
using SmartStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Application.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync(CancellationToken ct);
    Task<Product?> GetProductByIdAsync(int id, CancellationToken ct);
    Task<int> AddProductAsync(Product product, CancellationToken ct);
    Task UpdateProductAsync(Product product, CancellationToken ct);
    Task DeleteProductAsync(Product product, CancellationToken ct);
}
