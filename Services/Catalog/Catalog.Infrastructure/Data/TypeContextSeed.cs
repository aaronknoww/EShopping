using System.Text.Json;
using Catalog.Core;
using MongoDB.Driver;

namespace Catalog.Infrastructure;

public class TypeContextSeed
{
    public static void SeedData(IMongoCollection<ProductType> typeCollections)
    {
        bool checkTypes = typeCollections.Find(b=>true).Any();
        string path = Path.Combine("Data", "SeedData", "types.json");
        if(!checkTypes)
        {
            string typesData = File.ReadAllText(path);
            List<ProductType>? types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
            if(types != null)
            {
                foreach(ProductType item in types)
                {
                    typeCollections.InsertOneAsync(item);
                }
            }
        }
    }

}
