using Data.Data;
using Business.Services;
using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddGrpcClient<AddressHandler.AddressHandlerClient>(x =>
{
    x.Address = new Uri(builder.Configuration.GetConnectionString("gRpcAddressServer")!);
});
builder.Services.AddGrpcClient<CategoryHandler.CategoryHandlerClient>(x =>
{
    x.Address = new Uri(builder.Configuration.GetConnectionString("gRpcCategoryServer")!);
});
builder.Services.AddScoped<AddressServices>();
builder.Services.AddScoped<CategoryService>();


builder.Services.AddScoped<EventService>();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventDatabaseConnection")));

var app = builder.Build();

app.MapOpenApi();
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
