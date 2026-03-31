using System.Net;
using Application.Dtos.ItemProduct;
using Application.Dtos.Order;
using Application.Dtos.OrderForAdmin;
using Application.Dtos.Product;
using Application.Dtos.Products;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repository.OrderRepository;

namespace Infrastructure.Services;

public class OrderService(IOrderRepository repository) : IOrderService
{
    public async Task<Response<string>> CreateOrder(CreateOrderDto dto)
    {
        var order = new Order()
        {
            CustomerName = dto.CustomerName,
            CustomerPhone = dto.CustomerPhone,
            ProductVariantId = dto.ProductVariantId
            
        };
        var res = await repository.AddOrder(order);
         return res > 0
             ? new Response<string>(HttpStatusCode.Created, "Order Created successfully")
             : new Response<string>(HttpStatusCode.BadRequest, " Order Creation Failed");
        
    }

    public async Task<Response<List<GetOrderWithProductDto>>> GetAllOrders()
    {
        var res = await repository.GetOrders();
       if(res == null)  return new Response<List<GetOrderWithProductDto>>(HttpStatusCode.NotFound, "Order Not Found");
       var rew = res.Select(p=> new GetOrderWithProductDto()
       {
           Id = p.Id,
           Quantity = p.Quantity,
           CustomerName = p.CustomerName,
           CustomerPhone = p.CustomerPhone,
           CreatedAt = p.CreatedAt,
           Status = p.Status,
           Product = p.ProductVariant.Product!= null ? new  SimpleGetProductDto()
           {
               Id  = p.ProductVariant.ProductId ?? 0,
               Name = p.ProductVariant.Product.Name,
               Price = p.ProductVariant.Product.Price
           }: null
       }).ToList();
       return new Response<List<GetOrderWithProductDto>>(rew) ;
    }

    public async Task<Response<string>> UpdateOrder(UpdateOrderDto dto)
    {
        var res = await repository.GetOrderById(dto.Id);
        if(res ==  null) return new Response<string>(HttpStatusCode.NotFound, "Order Not Found ");
        res.Status = dto.Status;
        var rew = await repository.UpdateOrder(res);
        return rew > 0
            ? new Response<string>(HttpStatusCode.OK, "Order Updated successfully")
            : new Response<string>(HttpStatusCode.BadRequest, "Order Update Failed");
    }
}