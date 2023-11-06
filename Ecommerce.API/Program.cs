using Ecommerce.Repository.DBContext;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Repository.Contract;
using Ecommerce.Repository.Implementation;
using Ecommerce.Utilities;
using Ecommerce.Service.Contract;
using Ecommerce.Service.Implementation;

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

//Repository Injection
//This generic interface will be able to implement a generic class
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

//Repository Injection
//Sale Interface can implement Sale class
builder.Services.AddScoped<ISaleRepository, SaleRepository>();

//Utilities Injection (AutoMapper)
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//Service Injection
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS Policy 
app.UseCors("NewPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
