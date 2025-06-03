using Data.Data;
using Business.Services;
using Microsoft.EntityFrameworkCore;
using WebApi;
using WebApi.Services;
using Data.Interfaces;
using Data.Repositories;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

// KeyVault configuration
var keyVaultUri = new Uri($"https://{builder.Configuration["KeyVaultName"]}.vault.azure.net/");
if (builder.Environment.IsProduction())
{
    builder.Configuration.AddAzureKeyVault(
        keyVaultUri,
        new DefaultAzureCredential(),
        //new CustomSecretManager("Ventixe")
        new AzureKeyVaultConfigurationOptions()
        {
            Manager = new CustomSecretManager("Ventixe"),
            ReloadInterval = TimeSpan.FromMinutes(5)
        }
    );
}

builder.Services.AddControllers();
builder.Services.AddOpenApi();
//builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();

builder.Services.AddScoped<AddressServices>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<EventService>();
builder.Services.AddScoped<PackageService>();
builder.Services.AddGrpc();

builder.Services.AddGrpcClient<AddressHandler.AddressHandlerClient>(x =>
{
    x.Address = new Uri(builder.Configuration["Proto:GrpcAddressServer"]!);
});

builder.Services.AddGrpcClient<CategoryHandler.CategoryHandlerClient>(x =>
{
    x.Address = new Uri(builder.Configuration["Proto:GrpcCategoryServer"]!);
});

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlDbConnection")));
builder.Configuration.AddEnvironmentVariables();

var app = builder.Build();


app.MapOpenApi();
//app.UseSwagger();
//app.UseSwaggerUI(c =>
//{
//    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Event API V1");
//    c.RoutePrefix = string.Empty;
//});
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapGrpcService<EventProtoServices>();
app.MapGet("/", () => "gRPC Event API is up and running");
app.Run();
