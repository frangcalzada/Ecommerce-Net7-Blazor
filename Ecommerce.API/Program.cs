using Ecommerce.Repository.DBContext;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Repository.Contract;
using Ecommerce.Repository.Implementation;
using Ecommerce.Utilities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependecy Injection DB
builder.Services.AddDbContext<DbecommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Ecommerce-DBConnection"));
});

//This generic interface will be able to implement a generic class
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

//Sale Interface can implement Sale class
builder.Services.AddScoped<ISaleRepository, SaleRepository>();

//Utilities Injection (AutoMapper)
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
