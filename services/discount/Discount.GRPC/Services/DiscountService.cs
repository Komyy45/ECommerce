using Dapper;
using Discount.GRPC.Data;
using Discount.GRPC.Models;
using discount.grpc.protos;
using Grpc.Core;

namespace Discount.GRPC.Services;

public sealed class DiscountService
    : discount.grpc.protos.DiscountService.DiscountServiceBase
{
    private readonly IDbConnectionFactory _connectionFactory;

    public DiscountService(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public override async Task<CouponModel> GetDiscount(
        GetDiscountRequest request,
        ServerCallContext context)
    {
        using var conn = _connectionFactory.CreateConnection();

        var coupon = await conn.QueryFirstOrDefaultAsync<Coupon>(
            """
            SELECT Id, ProductId, Description, Percentage
            FROM Coupons
            WHERE ProductId = @ProductId
            """,
            new { request.ProductId });

        if(coupon is null) throw new RpcException(
            new Status(StatusCode.NotFound, "Coupon not found")
        );
        
        return MapToProto(coupon);
    }

    public override async Task<CouponModel> CreateDiscount(
        CreateDiscountRequest request,
        ServerCallContext context)
    {
        var coupon = new Coupon
        {
            ProductId = request.ProductId,
            Description = request.Description,
            Percentage = request.Percentage
        };

        using var conn = _connectionFactory.CreateConnection();

        var id = await conn.ExecuteScalarAsync<int>(
            """
            INSERT INTO Coupons (ProductId, Description, Percentage)
            VALUES (@ProductId, @Description, @Percentage);
            SELECT last_insert_rowid();
            """,
            coupon);

        coupon.Id = id;

        return MapToProto(coupon);
    }

    public override async Task<CouponModel> UpdateDiscount(
        UpdateDiscountRequest request,
        ServerCallContext context)
    {
        var coupon = request.Coupon;

        using var conn = _connectionFactory.CreateConnection();

        var rows = await conn.ExecuteAsync(
            """
            UPDATE Coupons
            SET Description = @Description,
                Percentage = @Percentage
            WHERE ProductId = @ProductId
            """,
            new
            {
                coupon.ProductId,
                coupon.Description,
                coupon.Percentage
            });

        if (rows == 0)
            throw new RpcException(
                new Status(StatusCode.NotFound, "Coupon not found"));

        return coupon;
    }

    public override async Task<DeleteDiscountResponse> DeleteDiscount(
        DeleteDiscountRequest request,
        ServerCallContext context)
    {
        using var conn = _connectionFactory.CreateConnection();

        var rows = await conn.ExecuteAsync(
            """
            DELETE FROM Coupons
            WHERE ProductId = @ProductId
            """,
            new { request.ProductId });

        if (rows == 0)
            throw new RpcException(
                new Status(StatusCode.NotFound, "Coupon not found"));

        return new DeleteDiscountResponse
        {
            ProductId = request.ProductId
        };
    }

    private static CouponModel MapToProto(Coupon coupon)
        => new()
        {
            Id = coupon.Id,
            ProductId = coupon.ProductId,
            Description = coupon.Description,
            Percentage = coupon.Percentage
        };
}
