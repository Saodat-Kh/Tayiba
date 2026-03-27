using Application.Dtos.Category;
using Application.Dtos.ItemProduct;
using Application.Dtos.Order;
using Application.Dtos.OrderForAdmin;
using Application.Dtos.Product;
using Application.Dtos.ProductVariant;
using Application.Dtos.Review;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Profiles;

public class MyMapper : Profile
{
    public MyMapper()
    {
        CreateMap<Category,CreateCategoryDto>().ReverseMap();
        CreateMap<Category,UpdateCategoryDto>().ReverseMap();   
        CreateMap<Category,GetCategoryDto>().ReverseMap();
        
        
        CreateMap<Product,CreateProductDto>().ReverseMap();
        CreateMap<Product, GetProductDto>().ReverseMap();
        CreateMap<Product, UpdateProductDto>().ReverseMap();
         
        CreateMap<ItemProduct, UpdateItemProductDto>().ReverseMap();
        CreateMap<ItemProduct,  CreateItemProductDto>().ReverseMap();
        CreateMap<ItemProduct, GetItemProductDto>().ReverseMap();
        
        CreateMap<ProductVariant, CreateVariantProductDto>().ReverseMap();
        CreateMap<ProductVariant, CreatedProductVariantWithId>().ReverseMap();
        
        CreateMap<Order, CreateOrderDto>().ReverseMap();
        CreateMap<Order, UpdateOrderDto>().ReverseMap();
        CreateMap<Order, GetOrderWithProductDto>().ReverseMap();
        
        CreateMap<Review,CreateReviewDto>().ReverseMap();
        CreateMap<Review, GetReviewForUserDto>().ReverseMap();
        CreateMap<Review, UpdateReviewDto >().ReverseMap();
        CreateMap<Review, GetReviewForAdminDto>().ReverseMap();
        
    }
}