namespace Catalog.Core;

public interface IProductRepository
{
    // QUERIES
    Task<Product> GetProductById(string id);
    Task<IEnumerable<Product>> GetProducts();
    Task<IEnumerable<Product>> GetProductByName(string name);
    Task<IEnumerable<Product>> GetProductByBrand(string brandName);

    //COMMANDS
    Task<Product> CreateProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task<bool> DeleteProductId(string id);



}
