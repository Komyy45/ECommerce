using System.Reflection;
using Basket.Application.Mappers;
using discount.grpc.protos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(cfg => cfg.AddProfile(typeof(BasketMappingProfile)));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddGrpcClient<DiscountService.DiscountServiceClient>(options =>
        {
            options.Address = new Uri(configuration.GetConnectionString("Discount")!);
        });
        
        return services;
    }
}