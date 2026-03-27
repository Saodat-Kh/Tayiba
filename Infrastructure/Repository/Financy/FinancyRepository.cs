using Domain.Enum;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repository.Financy;

public class FinancyRepository(ApplicationDataContext context, IMemoryCache cache) : IFinancyRepository
{
    private readonly string income = "income";
    private readonly string expense = "expense";
    public async Task<decimal> GetIncome()
    {
        var dataTo = DateTime.UtcNow;
        var dataFrom = dataTo.AddDays(-1);
        if (!cache.TryGetValue(income, out decimal valued))
        {
            valued = await context.Orders.Where(p=> p.Status == OrderStatus.COMPLETE && p.CreatedAt >= dataFrom && p.CreatedAt <= dataTo).SumAsync(p => p.Price);
            cache.Set(income, valued, TimeSpan.FromHours(102));
        }
        return valued;
    }

    public async Task<decimal> GetExpense()
    { var dataTo = DateTime.UtcNow;
        var dataFrom = dataTo.AddDays(-1);
        if (!cache.TryGetValue(expense, out decimal va))
        {
            va = await context.Financies.Where(p=> p.CreatedAt >= dataFrom && p.CreatedAt <= dataTo).SumAsync(p => p.Amount);
            cache.Set(expense, va, TimeSpan.FromHours(2));
        }
        return va;
    }
}