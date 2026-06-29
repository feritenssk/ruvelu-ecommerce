using Microsoft.EntityFrameworkCore;
using Ruvelu.Core.Interfaces;
using Ruvelu.Data;
using Ruvelu.Data.Repositories;

var builder = webApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<RuveluDbContext>(options =>
 options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

 builder.Services.AddScoped<IProductRepository, ProductRepository>();

 var app = builder.Build();

 if (app.Environment.IsDevelopment())
 {
     app.MapOpenApi();
 }

 app.UseHttpsRedirection();
 app.UseAuthorization();
 app.MapControllers();

 app.Run();