using Application.Dtos.Review;
using Application.Responses;
using Domain.Entities;

namespace Infrastructure.Repository.ReviewRepository;

public interface IReviewRepository
{
    Task<int> CreateReview(Review review);
    Task<List<Review>> GetAllReviewForUser(int productId);
    Task<List<Review>> GetAllReviewForAdmin();
    Task<int> UpdateReview(Review review);
    Task<Review> GetById(int id);
}