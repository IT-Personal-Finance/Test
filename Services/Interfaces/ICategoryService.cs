using Project.DTOs;

namespace Project.Services.Interfaces;

public interface ICategoryService
{
    Task<IEnumerable<CategoryDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<CategoryDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<CategoryDto> CreateAsync(CategoryDto category, CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(int id, CategoryDto category, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
