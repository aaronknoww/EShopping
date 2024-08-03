﻿using Catalog.Core;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.Infrastructure;

public class CatalogContext : ICatalogContext
{
    public IMongoCollection<Product> Products {get;}

    public IMongoCollection<ProductBrand> Brands {get;}

    public IMongoCollection<ProductType> Types {get;}

    public CatalogContext(IConfiguration configuration)
    {
        MongoClient client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectioString"));
        IMongoDatabase database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
        Brands = database.GetCollection<ProductBrand>(configuration.GetValue<string>("DatabaseSettings:BrandsCollection"));
        Types = database.GetCollection<ProductType>(configuration.GetValue<string>("DatabaseSettings:TypesCollection"));
        Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:ProductsCollection"));
        BrandContextSeed.SeedData(Brands);
        TypeContextSeed.SeedData(Types);
        CatalogContextSeed.SeedData(Products);
    }

}
