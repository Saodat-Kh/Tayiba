using Application.Dtos.Category;
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
    }
}