using InventoryManagement.Domain.Entities;
using InventoryManagement.Domain.Repositories;
using InventoryManagement.Infrastructure.Data;
using InventoryManagement.UI;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Application.Repositories.Interfaces;
using InventoryManagement.Application.Services.Interfaces;
using InventoryManagement.Application.Services;

var builder = WebApplication.CreateBuilder(args);

//// Verificar a string de conex�o
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//Console.WriteLine($"Connection String: {connectionString}");

// Adicione servi�os ao cont�iner
builder.Services.AddDbContext<InventoryContext>(options =>
    options.UseSqlServer(
        @"Data Source=localhost\SQLEXPRESS;Initial Catalog=ControlStock;Integrated Security=True;Encrypt=False"));


// Registrar os reposit�rios
builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();
builder.Services.AddScoped<IRepository<Customer>, CustomerRepository>();
builder.Services.AddScoped<IRepository<Product>, ProductRepository>();

// Registrar os servi�os
builder.Services.AddScoped<IService<Category>, CategoryService>();
builder.Services.AddScoped<IService<Customer>, CustomerService>();
builder.Services.AddScoped<IService<Product>, ProductService>();


// Adicionar servi�os ao cont�iner
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure o pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();