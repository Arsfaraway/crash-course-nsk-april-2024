using Market.DAL;
using Market.DAL.InterfacesRepository.Carts;
using Market.DAL.InterfacesRepository.Orders;
using Market.DAL.InterfacesRepository.Products;
using Market.DAL.InterfacesRepository.Users;
using Market.DAL.Repositories.Carts;
using Market.DAL.Repositories.Orders;
using Market.DAL.Repositories.Products;
using Market.DAL.Repositories.Users;
using Market.Filters;
using Market.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(c =>
{
    c.Filters.Add<ExceptionFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDbContext<RepositoryContext>()
    .AddScoped<IUsersRepository, UserRepository>()
    .AddScoped<IUserAuthenticator, UserAuthenticator>()
    .AddScoped<ICartsRepository, CartsRepository>()
    .AddScoped<IOrdersRepository, OrdersRepository>()
    .AddScoped<IProductsRepository, ProductsRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();