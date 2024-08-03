using System.Text.Json;
using Catalog.Core;
using MongoDB.Driver;

namespace Catalog.Infrastructure;

public static class CatalogContextSeed
{
    public static void SeedData(IMongoCollection<Product> productCollection)
    {
        bool checkProducts = productCollection.Find(b=>true).Any();
        string path = Path.Combine("Data", "SeedData", "products.json");
        if(!checkProducts)
        {
            string productsData = File.ReadAllText(path);
            List<Product>? products = JsonSerializer.Deserialize<List<Product>>(productsData);
            if(products != null)
            {
                foreach(Product item in products)
                {
                    productCollection.InsertOneAsync(item);
                }
            }
        }
    }

}
