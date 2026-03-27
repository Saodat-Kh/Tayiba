using Application.Dtos.Review;
using Application.Responses;

namespace Application.Interfaces;

public interface IReviewService
{
  Task<Response<string>> CreateReview(CreateReviewDto dto);
  Task<Response<List<GetReviewForAdminDto>>> GetAllReview();
  Task<Response<List<GetReviewForUserDto>>> GetAllReviewForUser(int productId);
  Task<Response<string>> UpdateReview(int id,UpdateReviewDto dto);
}