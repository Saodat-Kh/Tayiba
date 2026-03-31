using Domain.Entities;
using Domain.Enum;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Infrastructure.Repository.ReviewRepository;

public class ReviewRepository(ApplicationDataContext context) : IReviewRepository
{
    public async Task<int> CreateReview(Review review)
    {
        context.Reviews.Add(review);
        var res = await context.SaveChangesAsync();
        return res > 0 ? res : 0;
    }

    public async Task<List<Review>> GetAllReviewForUser(int productId)
    { 
       var res = await context.Reviews.Where(x=> x.ProductId == productId && x.Status == StatusReview.Approved).ToListAsync();
        return res;
    }

    public async Task<List<Review>> GetAllReviewForAdmin()
    {
        var res = await context.Reviews.Where(x=> x.Status == StatusReview.Expected).ToListAsync();
        return res;
    }

    public async Task<int> UpdateReview(Review review)
    {
        context.Reviews.Update(review);
        var res = await context.SaveChangesAsync();
        return res;
    }

    public async Task<Review> GetById(int id)
    {
        return await context.Reviews.FirstOrDefaultAsync(p=> p.Id == id);
    }
}