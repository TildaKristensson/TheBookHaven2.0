

using Microsoft.EntityFrameworkCore;
using The_Book_Haven_2._0.Components;
using TheBookHaven2.ApiService;
using TheBookHaven2.Data;
using TheBookHaven2.Interface;
using TheBookHaven2.Repositories;
using TheBookHaven2.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookHavenDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();


builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerOrderService, CustomerOrderService>();


builder.Services.AddControllers();

builder.Services.AddHttpClient();
builder.Services.AddScoped<ProductApiService>();
builder.Services.AddScoped<CustomerApiService>();
builder.Services.AddScoped<OrderApiService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHttpClient<ProductApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7080");
});
builder.Services.AddHttpClient<CustomerApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7080");
});
builder.Services.AddHttpClient<OrderApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7080");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllers();

app.UseDeveloperExceptionPage();

try
{
    app.Run();

}catch(Exception ex)
{

}
