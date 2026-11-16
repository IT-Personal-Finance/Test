using Project.DTOs;

namespace Project.Services.Interfaces;

public interface IBudgetService
{
    Task<IEnumerable<BudgetDto>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<BudgetDto?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    Task<BudgetDto> CreateAsync(BudgetDto budget, CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(int id, BudgetDto budget, CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
