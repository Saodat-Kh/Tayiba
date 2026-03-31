// using Application.Dtos.Financy;
// using Application.Dtos.Order;
// using Application.Interfaces;
// using Application.Responses;
// using Infrastructure.Data;
//
// namespace Infrastructure.Services;
//
// public class DashboardService(ApplicationDataContext context) : IDashboardService
// {
//     public async Task<Response<List<GetFinancyDto>>> GetFinancies()
//     {
//         var res = context.Financies.ToList();
//         var dto = res.Select(a=> new  GetFinancyDto()
//         {
//             Profit = a.Profit
//         }).ToList();
//         return new Response<List<GetFinancyDto>>(dto);
//     }
//
//     public async Task<Response<List<GetOrderWithProductDto>>> GetOrderStatus()
//     {
//         var r = context.Orders.ToList();
//         var res = r.Select(e => new GetOrderWithProductDto()
//         {
//             Status = e.Status,
//         }).ToList();
//         return new Response<List<GetOrderWithProductDto>>(res);
//     }
// }