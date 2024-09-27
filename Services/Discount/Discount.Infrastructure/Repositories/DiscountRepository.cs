using System;
using Dapper;
using Discount.Core.Entities;
using Discount.Core.Repositories;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Discount.Infrastructure.Repositories;

public class DiscountRepository : IDiscountRepository
{
    private readonly IConfiguration _configuration;

    public DiscountRepository(IConfiguration configuration)
    {
        this._configuration = configuration;
    }

    public async Task<bool> CreateDiscount(Coupon coupon)
    {
        await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        await connection.OpenAsync();  // Ensure the connection is open

        int affected = await connection.ExecuteAsync
                    ("INSERT INTO Coupon (ProductName, Description, Amount) VALUES(@ProductName, @Description, @Amount)",
                        new {ProductName = coupon.ProductName, Amount = coupon.Amount, Description = coupon.Description});
        return (affected == 0) ? false : true;
    }

    public async Task<bool> DeleteDiscount(string productName)
    {
        await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        await connection.OpenAsync();  // Ensure the connection is open

        int affected = await connection.ExecuteAsync
            ("DELETE * FROM Coupon WHERE ProductName=@ProductName"
                , new {ProductName = productName});
        return affected > 0;
    }

    public async Task<Coupon> GetDiscount(string productName)
    {
        await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        await connection.OpenAsync();  // Ensure the connection is open

        var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>("SELECT * FROM Coupon WHERE ProductName = @ProductName", new {ProductName = productName});
        if (coupon == null)
        {
            return new Coupon
            {
                ProductName = "No Discount",
                Amount = 0,
                Description = "No discounts available"
            };
        }
        return coupon;
    }

    public async Task<bool> UpdateDiscount(Coupon coupon)
    {
        await using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        await connection.OpenAsync();  // Ensure the connection is open

        int affected = await connection.ExecuteAsync
            ("UPDATE Coupon SET ProductName=@ProductName, Description = @Description, Amount = @Amuont WHERE Id = @Id"
                , new {ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount, Id = coupon.Id});
        return affected > 0;
    }
}
