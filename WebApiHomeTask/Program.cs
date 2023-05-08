using Microsoft.EntityFrameworkCore;
using WebApiHomeTask.Data;
using WebApiHomeTask.Repositories.Abstract;
using WebApiHomeTask.Repositories.Concrete;
using WebApiHomeTask.Services.Abstract;
using WebApiHomeTask.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Database

var connection = builder.Configuration.GetConnectionString("myconn");
builder.Services.AddDbContext<CommerceDbContext>(opt =>
{
    opt.UseSqlServer(connection);
});

// Registrate Customer

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();


// Registrate Product

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();


// Registrate Order

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderService, OrderService>();

var app = builder.Build();

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
