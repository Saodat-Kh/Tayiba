using Application.Dtos.Financy;
using Application.Responses;

namespace Application.Interfaces;

public interface IFinanceService
{
    Task<Response<GetFinanceDto>> GetFinancy();
}