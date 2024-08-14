using Catalog.Core;
using MongoDB.Driver;

namespace Catalog.Infrastructure;

public class ProductRepository : IProductRepository, IBrandRepository, ITypesRepository
{
    
    public ICatalogContext _context { get; }

    public ProductRepository(ICatalogContext context)
    {
        this._context = context;
    }


    public async Task<Product> CreateProduct(Product product)
    {
        await _context.Products.InsertOneAsync(product);
        return product;
    }

    public async Task<bool> DeleteProduct(string id)
    {
        DeleteResult deleteProduct = await _context.Products.DeleteOneAsync(p=>p.Id == id);
        return deleteProduct.IsAcknowledged && deleteProduct.DeletedCount > 0;
    }

    public async Task<IEnumerable<ProductBrand>> GetAllBrands()
    {
        return await _context.Brands.Find(brand=>true).ToListAsync();
     
    }

    public async Task<IEnumerable<ProductType>> GetAllTypes()
    {
        return await _context.Types.Find(type => true).ToListAsync();
    }

    public async Task<Product> GetProductById(string id)
    {
        return await _context.Products.Find<Product>(p => p.Id == id).FirstOrDefaultAsync();
        
    }

    public async Task<IEnumerable<Product>> GetProductByBrand(string brandName)
    {
        return await _context.Products.Find(p => p.Brands.Name.ToLower()==brandName.ToLower()).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProductByName(string name)
    {
        return await _context.Products.Find(p => p.Name.ToLower()==name.ToLower()).ToListAsync();
    }

    public async Task<IEnumerable<Product>> GetProducts()
    {
        return await _context.Products.Find(p=>true).ToListAsync();
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        ReplaceOneResult updatedProduct = await _context
                        .Products.ReplaceOneAsync(p =>p.Id == product.Id, product);
        
        return updatedProduct.IsAcknowledged && updatedProduct.ModifiedCount > 0;
    }
}
