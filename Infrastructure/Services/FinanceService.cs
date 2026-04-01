
using Application.Dtos.Financy;
using Application.Interfaces;
using Application.Responses;

using Infrastructure.Repository.Finance;

namespace Infrastructure.Services;

public class FinanceService(IFinanceRepository repository) : IFinanceService
{
    public async Task<Response<GetFinanceDto>> GetFinancy()
    {
        var income =await repository.GetIncome();
        var expense = await repository.GetExpense();
        var dto = new GetFinanceDto()
        {
            Income = income,
            Expenses = expense,
            Profit = income - expense
        };
        return new Response<GetFinanceDto>(dto);

    }
}