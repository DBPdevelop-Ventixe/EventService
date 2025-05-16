using Data.Data;
using Business.Services;
using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

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
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Event API V1");
    c.RoutePrefix = string.Empty;
});
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
