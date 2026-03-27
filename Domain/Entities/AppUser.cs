using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class AppUser : IdentityUser<int>
{
    public string? Address { get; set; }
    public DateTimeOffset RegisteredAt { get; set; } = DateTimeOffset.UtcNow;
    public string FullName { get; set; }
    
    public List<Review>? Reviews { get; set; }
    public List<Order>? Orders { get; set; }
}