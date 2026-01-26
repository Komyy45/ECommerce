using Discount.GRPC.Data;
using Discount.GRPC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddSingleton<IDbConnectionFactory>(
    _ => new SqliteConnectionFactory(
        builder.Configuration.GetConnectionString("DefaultConnection")!
    ));

builder.Services.AddSingleton<DbInitializer>();

var app = builder.Build();

using var scope = app.Services.CreateScope();

var initializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();

initializer.Initialize();

// Configure the HTTP request pipeline.
app.MapGet("/",
    () =>
        "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.MapGrpcService<DiscountService>();

app.Run();