using Microsoft.EntityFrameworkCore;
using ProductsTable.Application;
using ProductsTable.Domain;
using ProductsTable.Infrastructure.Static;
using ProductsTable.Infrastructure.Static.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:5081")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
services.AddDbContext<Context>(option =>
{
    option.UseSqlServer(
        "Server=.;DataBase=ProductDB;Integrated Security=true;MultipleActiveResultSets=true;TrustServerCertificate=True");
    option.UseSqlServer(b => b.MigrationsAssembly("ProductsTable.API"));
});

services.AddScoped<IProductService, ProductService>();
services.AddScoped<IProductRepository, ProductRepository>();
var app = builder.Build();
app.UseCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();