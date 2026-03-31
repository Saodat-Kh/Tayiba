using System.Net;
using Application.Dtos.Financy;
using Application.Interfaces;
using Application.Responses;
using Infrastructure.Repository.Financy;

namespace Infrastructure.Services;

public class FinanceService(IFinancyRepository repository) : IFinancyService
{
    public async Task<Response<GetFinanceDto>> GetFinancy()
    {
        var income =await repository.GetIncome();
        var expence = await repository.GetExpense();
        var dto = new GetFinanceDto()
        {
            Income = income,
            Expenses = expence,
            Profit = income - expence
        };
        return new Response<GetFinanceDto>(dto);

    }
}