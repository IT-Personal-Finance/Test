using Microsoft.AspNetCore.Mvc;
using Project.DTOs;
using Project.Services.Interfaces;

namespace Project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BudgetsController : ControllerBase
{
    private readonly IBudgetService _budgetService;

    public BudgetsController(IBudgetService budgetService)
    {
        _budgetService = budgetService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BudgetDto>>> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await _budgetService.GetAllAsync(cancellationToken));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<BudgetDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var budget = await _budgetService.GetByIdAsync(id, cancellationToken);
        return budget is null ? NotFound() : Ok(budget);
    }

    [HttpPost]
    public async Task<ActionResult<BudgetDto>> Create(BudgetDto budget, CancellationToken cancellationToken)
    {
        var created = await _budgetService.CreateAsync(budget, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, BudgetDto budget, CancellationToken cancellationToken)
    {
        return await _budgetService.UpdateAsync(id, budget, cancellationToken) ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        return await _budgetService.DeleteAsync(id, cancellationToken) ? NoContent() : NotFound();
    }
}
