using System.Text.Json;
using Catalog.Core;
using MongoDB.Driver;

namespace Catalog.Infrastructure;

public static class BrandContextSeed
{
    public static void SeedData(IMongoCollection<ProductBrand> brandCollections)
    {
        bool checkBrands = brandCollections.Find(b=>true).Any();
        string path = Path.Combine("Data", "SeedData", "brands.json");
        if(!checkBrands)
        {
            string brandsData = File.ReadAllText(path);
            List<ProductBrand>? brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
            if(brands != null)
            {
                foreach(var item in brands)
                {
                    brandCollections.InsertOneAsync(item);
                }
            }
        }
    }
}
