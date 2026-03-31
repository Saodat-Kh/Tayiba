using Infrastructure.Data;
using Infrastructure.File;
using Infrastructure.Profiles;
using Infrastructure.Seed;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using Serilog;
using WebApp.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Month, fileSizeLimitBytes: 10240)
    .Enrich.FromLogContext()
    .MinimumLevel.Debug());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//db⬇️
builder.Services.AddDBContext(builder.Configuration);
//Auth⬇️
builder.Services.AddAuth(builder.Configuration);
//memoryCache
builder.Services.AddMemoryCache();
//autoMapper
builder.Services.AddAutoMapper(typeof(MyMapper));
//File
builder.Services.AddScoped<IFileService>(op =>
    new FileService(builder.Environment.ContentRootPath));
//service
builder.Services.AddRegisterService();

//seed⬇️
builder.Services.AddScoped<Seeder>();

builder.Services.AddSwaggerGen(c =>
{


    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Введите JWT токен в формате: Bearer {your_token}"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
            },
            new List<string>()
        }
    });
});


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
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();


