using System.Net;
using Application.Dtos.Review;
using Application.Interfaces;
using Application.Responses;
using AutoMapper;
using Domain.Entities;
using Domain.Enum;
using Infrastructure.Repository.ReviewRepository;

namespace Infrastructure.Services;

public class ReviewService(IReviewRepository repository, IMapper mapper) : IReviewService
{
    public async Task<Response<string>> CreateReview(CreateReviewDto dto)
    {
        var map = mapper.Map<Review>(dto);
        map.Status = StatusReview.Expected;
        map.CreatedAt = DateTime.Now;
        var res = await repository.CreateReview(map);
        if (res > 0)
        {
            return new Response<string>(HttpStatusCode.Created, "Created Successfully");
        }
        else
        {
            return new Response<string>(HttpStatusCode.BadRequest, "Failed to create review");
        }        
    }

    public async Task<Response<List<GetReviewForAdminDto>>> GetAllReview()
    {
        var res = await repository.GetAllReviewForAdmin();
        var map = mapper.Map<List<GetReviewForAdminDto>>(res);
        return new Response<List<GetReviewForAdminDto>>(map);
    }

    public async Task<Response<List<GetReviewForUserDto>>> GetAllReviewForUser(int productId)
    {
        var res = await repository.GetAllReviewForUser(productId);
        var map = mapper.Map<List<GetReviewForUserDto>>(res);
        return new Response<List<GetReviewForUserDto>>(map);
    }

    public async Task<Response<string>> UpdateReview(int id, UpdateReviewDto dto)
    {
        var res = await repository.GetById(id);
        if (res == null) return new Response<string>(HttpStatusCode.NotFound, "Review not found");
        res.Status = dto.Status;
        var rew = await  repository.UpdateReview(res);
        return rew > 0
            ? new Response<string>(HttpStatusCode.OK, "Updated Successfully")
            : new Response<string>(HttpStatusCode.BadRequest, "Failed to update review");
    }
}