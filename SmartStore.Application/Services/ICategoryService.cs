using SmartStore.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Application.Services;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync(CancellationToken ct);
    Task<CategoryDto?> GetByIdAsync(int id, CancellationToken ct);
    Task<int> CreateAsync(string name, CancellationToken ct);
    Task<bool> UpdateAsync(int id, string name,bool isActive, CancellationToken ct);
    Task<bool> DeleteAsync(int id, CancellationToken ct);
}
