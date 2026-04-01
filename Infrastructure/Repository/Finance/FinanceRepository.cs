using Domain.Enum;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository.Finance;

public class FinanceRepository(ApplicationDataContext context) : IFinanceRepository
{

    public async Task<decimal> GetIncome()
    {
        var dataTo = DateTime.UtcNow;
        var dataFrom = dataTo.AddDays(-1);


        return await context.Orders
            .Where(p => p.Status == OrderStatus.COMPLETE && p.CreatedAt >= dataFrom && p.CreatedAt <= dataTo)
            .SumAsync(p => p.Price) ;

    }




    public async Task<decimal> GetExpense()
    {
        var dataTo = DateTime.UtcNow;
        var dataFrom = dataTo.AddDays(-1);
        return await context.Financies.Where(o => o.CreatedAt >= dataFrom && o.CreatedAt <= dataTo)
            .SumAsync(p => p.Amount);

    }
}