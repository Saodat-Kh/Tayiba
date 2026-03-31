using Application.Dtos.Financy;
using Application.Responses;

namespace Application.Interfaces;

public interface IFinancyService
{
    Task<Response<GetFinanceDto>> GetFinancy();
}