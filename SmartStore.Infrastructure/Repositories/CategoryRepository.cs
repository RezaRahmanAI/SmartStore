using Microsoft.EntityFrameworkCore;
using SmartStore.Application.Interfaces;
using SmartStore.Domain.Entities;
using SmartStore.Infrastructure.Persistence;


namespace SmartStore.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _dbContext;
    public CategoryRepository(AppDbContext dbContext) => _dbContext = dbContext;
    public async Task<int> AddCategoryAsync(Category category, CancellationToken ct)
    {
        _dbContext.Categories.Add(category);
        await _dbContext.SaveChangesAsync(ct);
        return category.Id;
    }

    public async Task DeleteCategoryAsync(Category category, CancellationToken ct)
    {
        _dbContext.Categories.Remove(category);
        await _dbContext.SaveChangesAsync(ct);
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken ct)
    {
        return await _dbContext.Categories.AsNoTracking().OrderByDescending(x => x.Id).ToListAsync(ct);
    }

    public Task<Category?> GetCategoryByIdAsync(int id, CancellationToken ct)
    {
        return _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id, ct);
    }

    public async Task UpdateCategoryAsync(Category category, CancellationToken ct)
    {
        _dbContext.Categories.Update(category);
        await _dbContext.SaveChangesAsync(ct);
    }
}
