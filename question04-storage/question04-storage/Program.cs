using Azure.Storage.Blobs;
using Azure.Identity;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Configuration
var configuration = builder.Configuration;

// Add DbContext (SQLite)
builder.Services.AddDbContext<question04_storage.Data.FileDbContext>(options =>
    options.UseSqlite(configuration.GetConnectionString("Sqlite") ?? "Data Source=filestore.db"));

// Configure Key Vault (optionally) so secrets stored there become available in configuration
// Provide the Key Vault URI via configuration or an environment variable `KEYVAULT_URI`.
//var keyVaultUri = configuration.GetValue<string>("KeyVault:VaultUri") ?? Environment.GetEnvironmentVariable("KEYVAULT_URI");
//if (!string.IsNullOrEmpty(keyVaultUri))
//{
//    configuration.AddAzureKeyVault(new Uri(keyVaultUri), new DefaultAzureCredential());
//}

// Configure Azure Blob Service Client
var storageConnection = configuration.GetValue<string>("AzureStorage:ConnectionString") ?? "UseDevelopmentStorage=true";
builder.Services.AddSingleton(new Azure.Storage.Blobs.BlobServiceClient(storageConnection));

var app = builder.Build();

// Ensure database is created
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<question04_storage.Data.FileDbContext>();
    db.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
