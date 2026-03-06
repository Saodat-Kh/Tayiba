using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : IdentityDbContext<User,IdentityRole<int>,int>(options){}