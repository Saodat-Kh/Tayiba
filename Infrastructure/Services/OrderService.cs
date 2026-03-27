using System.Net;
using Application.Dtos.Order;
using Application.Dtos.OrderForAdmin;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repository.OrderRepository;

namespace Infrastructure.Services;

public class OrderService(IOrderRepository repository, IMapper mapper) : IOrderService
{
    public async Task<Response<string>> CreateOrder(CreateOrderDto dto)
    {
        var map = mapper.Map<Order>(dto);
        var res = await repository.AddOrder(map);
        return res > 0
            ? new Response<string>(HttpStatusCode.Created, "Order Created successfully")
            : new Response<string>(HttpStatusCode.BadRequest, " Order Creation Failed");
        
    }

    public async Task<Response<List<GetOrderWithProductDto>>> GetAllOrders()
    {
        var res = await repository.GetOrders();
        var map =  mapper.Map<List<GetOrderWithProductDto>>(res);
        return new Response<List<GetOrderWithProductDto>>(map);
    }

    public async Task<Response<string>> UpdateOrder(UpdateOrderDto dto)
    {
        var map = mapper.Map<Order>(dto);
        var res = await repository.UpdateOrder(map);
        return res > 0
            ? new Response<string>(HttpStatusCode.OK, "Order Updated successfully")
            : new Response<string>(HttpStatusCode.BadRequest, "Order Updation Failed");
    }
}