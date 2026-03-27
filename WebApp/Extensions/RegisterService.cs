using Application.Interfaces;
using AutoMapper;
using Infrastructure.Data;
using Infrastructure.File;
using Infrastructure.Repository;
using Infrastructure.Repository.Category;
using Infrastructure.Repository.Financy;
using Infrastructure.Repository.ItemProductRepository;
using Infrastructure.Repository.OrderRepository;
using Infrastructure.Repository.Product;
using Infrastructure.Repository.ProductVariant;
using Infrastructure.Repository.ReviewRepository;
using Infrastructure.Services;
using Microsoft.Extensions.Caching.Memory;

namespace WebApp.Extensions;

public static class RegisterService
{
    public static void AddRegisterService(this IServiceCollection services)
    {
        
        //categoryRepository
        services.AddScoped<ICategoryRepository>(op => new CategoryRepository(
            op.GetRequiredService<ApplicationDataContext>(),
            op.GetRequiredService<IMemoryCache>()));
        //CategoryService
        services.AddScoped<ICategoryService>(op=> new CategoryService(
            op.GetRequiredService<ICategoryRepository>(),
            op.GetRequiredService<IMapper>()));

        //productRepository
        services.AddScoped<IProductRepository>(op => new ProductRepository(
            op.GetRequiredService<ApplicationDataContext>(),
            op.GetRequiredService<IMemoryCache>()));
        //ProductService
        services.AddScoped<IProductService>(op => new ProductService(
            op.GetRequiredService<IProductRepository>()));
        
        //ItemProductRepository
        services.AddScoped<IItemProductRepository>(op => new ItemProductRepository(
            op.GetRequiredService<ApplicationDataContext>()));
        //ItemProductService
        services.AddScoped<IItemProductService>(op => new ItemProductService(
            op.GetRequiredService<IFileService>(),
            op.GetRequiredService<ApplicationDataContext>(),
            op.GetRequiredService<IItemProductRepository>()));
        //ProductVariantRepository
        services.AddScoped<IProductVariantRepository>(op=> new ProductVariantRepository(
            op.GetRequiredService<ApplicationDataContext>(),
            op.GetRequiredService<IMemoryCache>()));
        //ProductVariantService
        services.AddScoped<IProductVariantService>(op=> new ProductVariantService(
            op.GetRequiredService<IProductVariantRepository>(),
            op.GetRequiredService<IMapper>()));
        //OrderRepository
        services.AddScoped<IOrderRepository>(op=> new OrderRepository(
            op.GetRequiredService<ApplicationDataContext>(),
            op.GetRequiredService<IMemoryCache>()));
        //OrderService
        services.AddScoped<IOrderService>(op=> new OrderService(
            op.GetRequiredService<IOrderRepository>(),
            op.GetRequiredService<IMapper>()));
        
        //ReviewRepository
        services.AddScoped<IReviewRepository>(op => new ReviewRepository(
            op.GetRequiredService<ApplicationDataContext>()));
        //ReviewService
        services.AddScoped<IReviewService>(op=> new ReviewService(
            op.GetRequiredService<IReviewRepository>(),
            op.GetRequiredService<IMapper>()));
        
        //financy
        services.AddScoped<IFinancyRepository>(op=> new FinancyRepository(
            op.GetRequiredService<ApplicationDataContext>(),
            op.GetRequiredService<IMemoryCache>()));

        services.AddScoped<IFinancyService>(op => new FinanceService(
            op.GetRequiredService<IFinancyRepository>()));
    }
}