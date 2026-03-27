using Application.Dtos.Financy;
using Application.Interfaces;
using Application.Responses;
using Infrastructure.Repository.Financy;

namespace Infrastructure.Services;

public class FinanceService(IFinancyRepository repository) : IFinancyService
{
    public async Task<Response<GetFinancyDto>> GetFinancy()
    {
        var income =await repository.GetIncome();
        var expence = await repository.GetExpense();
        var dto = new GetFinancyDto()
        {
            Income = income,
            Expenses = expence,
            Profit = income - expence
        };
        return new Response<GetFinancyDto>(dto);
    }
}