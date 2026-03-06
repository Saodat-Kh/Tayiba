using Infrastructure.Data;
using Infrastructure.Helper;
using Infrastructure.Seed;
using WebApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDBContext(builder.Configuration);
builder.Services.AddAuth(builder.Configuration);

builder.Services.AddScoped<Seeder>();


var app = builder.Build();

// Seed database
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var dataContext = serviceProvider.GetRequiredService<ApplicationDataContext>();
    await dataContext.Database.EnsureCreatedAsync();
    
    var seeder = serviceProvider.GetRequiredService<Seeder>();
    await seeder.SeedRole();
    await seeder.SeedUser();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();