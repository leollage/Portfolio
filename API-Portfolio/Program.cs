using API_Portfolio.Interfaces.Repositories;
using API_Portfolio.Interfaces.Services;
using API_Portfolio.Repositories;
using API_Portfolio.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
builder.Services.AddScoped<IBusinessService, BusinessService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>(x => new ProductRepository(builder.Configuration["ConnectionStrings:Portfolio"]));
builder.Services.AddScoped<IClientRepository, ClientRepository>(x => new ClientRepository(builder.Configuration["ConnectionStrings:Portfolio"]));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
