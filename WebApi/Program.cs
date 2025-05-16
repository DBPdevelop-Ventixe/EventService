using Data.Data;
using Business.Services;
using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Services;
using Data.Interfaces;
using Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEventRepository, EventRepository>();

builder.Services.AddScoped<AddressServices>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<EventService>();

builder.Services.AddGrpcClient<AddressHandler.AddressHandlerClient>(x =>
{
    // Get the gRPC server URL from the appsttings. Its in ACS:GrpcAddressServer
    x.Address = new Uri(builder.Configuration["ACS:GrpcAddressServer"]!);
});

builder.Services.AddGrpcClient<CategoryHandler.CategoryHandlerClient>(x =>
{
    x.Address = new Uri(builder.Configuration["ACS:GrpcCategoryServer"]!);
});

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EventDatabaseConnection")));
builder.Configuration.AddEnvironmentVariables();

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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
