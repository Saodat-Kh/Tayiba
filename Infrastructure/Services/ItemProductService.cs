using System.Net;
using Application.Dtos.ItemProduct;
using Application.Dtos.ProductVariant;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.File;
using Infrastructure.Repository.ItemProductRepository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class ItemProductService(IFileService file, ApplicationDataContext context, IItemProductRepository repository) : IItemProductService
{


    public async Task<Response<string>> CreateItemProduct(CreateItemProductDto createItemProductDto)
    {try
        {

            var itemproduct = new ItemProduct()
            {
                ProductId = createItemProductDto.ProductId,
                Quantity = createItemProductDto.Quantity,
                ProductVariants = new List<ProductVariant>(),
                Photo = new List<string>()
            };
            if(createItemProductDto.Photo != null)
                foreach (var photo in  createItemProductDto.Photo )
                {
                    itemproduct.Photo.Add(await file.SaveFile(photo, "photo"));
                }
        
            var res = await repository.CreateItemProductAsync(itemproduct);
           return res > 0
               ? new Response<string>(HttpStatusCode.Created, "Product created successfully")
               : new Response<string>(HttpStatusCode.BadRequest, "Product creation failed");
        
        }
        catch 
        {
            return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error");
        }
    }

    public async Task<Response<string>> UpdateItemProduct(UpdateItemProductDto updateItemProductDto)
    {try
        {
           var rew = await repository.GetItemProductById(updateItemProductDto.Id);
           if(rew == null) return new Response<string>(HttpStatusCode.NotFound, "Product not found");
           rew.Quantity = updateItemProductDto.Quantity ?? rew.Quantity;
           foreach (var p in rew.ProductVariants)
           {
               p.Color = updateItemProductDto.Color;
               p.Size = updateItemProductDto.Size;
           }

            if (updateItemProductDto.Photo != null)
            {
                var newItem = new List<string>();
                foreach (var photo in updateItemProductDto.Photo)
                {
                    newItem.Add(await file.SaveFile(photo, "photo"));
                }

                rew.Photo = newItem;
            }

            var res = await repository.UpdateItemProductAsync(rew);
            return res > 0
                ? new Response<string>(HttpStatusCode.NoContent, "ItemProduct updated successfully")
                : new Response<string>(HttpStatusCode.BadRequest, "ItemProduct updation failed");

        }
        catch 
        {
            return new Response<string>(HttpStatusCode.InternalServerError, "Internal Server Error");
        }
    }

    public async Task<Response<string>> DeleteItemProduct(int id)
    {
        var oldItem = context.ItemProducts.FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
        if(oldItem == null) return new Response<string>(HttpStatusCode.NotFound, "ItemProduct not found");
        oldItem.IsDeleted = true;
        var res = await context.SaveChangesAsync();
        return res > 0
            ? new Response<string>(HttpStatusCode.OK, "ItemProduct deleted successfully")
            : new Response<string>(HttpStatusCode.BadRequest, "ItemProduct deletion failed");
    }


    public async Task<Response<List<GetItemProductDto>>> GetAllItemProducts()
    {
        var res = await context.ItemProducts.Include(x => x.ProductVariants).ToListAsync();
        var dto = res.Select(c => new GetItemProductDto()
        {
            Id = c.Id,
            Quantity = c.Quantity,
            Photo = c.Photo,
            CreatedAt = c.CreatedAt,
            Variants = c.ProductVariants.Select(p => new GetProductVariantDto()
            {
                Id = p.Id,
                Color = p.Color,
                Size = p.Size
            }).ToList()
        }).ToList();
        return new Response<List<GetItemProductDto>>(dto);
    }
}