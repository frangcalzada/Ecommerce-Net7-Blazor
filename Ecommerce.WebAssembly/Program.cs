using Ecommerce.WebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Blazored.Toast;
using Ecommerce.WebAssembly.Services.Contract;
using Ecommerce.WebAssembly.Services.Implementation;
using CurrieTechnologies.Razor.SweetAlert2;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//API consumption
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5104/api/") });

//Blazored Storage
builder.Services.AddBlazoredLocalStorage();

//Blazored Toast
builder.Services.AddBlazoredToast();

//Services Injection
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddScoped<ISaleService, SaleService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();

//SweetAlert 2
builder.Services.AddSweetAlert2();


await builder.Build().RunAsync();
