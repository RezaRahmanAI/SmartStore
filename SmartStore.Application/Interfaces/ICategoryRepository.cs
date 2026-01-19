using SmartStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartStore.Application.Interfaces;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken ct);
    Task<Category?> GetCategoryByIdAsync(int id, CancellationToken ct);
    Task<int> AddCategoryAsync(Category category, CancellationToken ct);
    Task UpdateCategoryAsync(Category category, CancellationToken ct);
    Task DeleteCategoryAsync(Category category, CancellationToken ct);
}
