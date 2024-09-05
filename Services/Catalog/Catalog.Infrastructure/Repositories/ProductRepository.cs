using Catalog.Core;
using Catalog.Core.Specs;
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

    public async Task<bool> DeleteProductId(string id)
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

    public async Task<Pagination<Product>> GetProducts(CatalogSpecParams catalogSpecParams)
    {
        var builder = Builders<Product>.Filter;
        var filter = builder.Empty;
        if(!string.IsNullOrEmpty(catalogSpecParams.Search))
            filter = filter & builder.Where(p=>p.Name.ToLower().Contains(catalogSpecParams.Search.ToLower())); 
        if(!string.IsNullOrEmpty(catalogSpecParams.BrandId))
        {
            var brandFilter = builder.Eq(p=>p.Brands.Id, catalogSpecParams.BrandId);
            filter &= brandFilter;
        }
        if(!string.IsNullOrEmpty(catalogSpecParams.TypeId))
        {
            var typeFilter = builder.Eq(p=>p.Types.Id, catalogSpecParams.TypeId);
            filter &= typeFilter;
        }    
        var totalItems = await _context.Products.CountDocumentsAsync(filter);
        var data = await DataFilterAsync(catalogSpecParams, filter);
        // var data = await _context.Products.Find(filter)
        //                 .Skip((catalogSpecParams.PageIndex-1) * catalogSpecParams.PageSize)
        //                 .Limit(catalogSpecParams.PageSize).ToListAsync();
        
        return new Pagination<Product>(
            catalogSpecParams.PageIndex,
            catalogSpecParams.PageSize,
            (int)totalItems,data);
    }

    
    public async Task<bool> UpdateProduct(Product product)
    {
        ReplaceOneResult updatedProduct = await _context
                        .Products.ReplaceOneAsync(p =>p.Id == product.Id, product);
        
        return updatedProduct.IsAcknowledged && updatedProduct.ModifiedCount > 0;
    }

    private async Task<IReadOnlyList<Product>> DataFilterAsync(CatalogSpecParams catalogSpecParams, FilterDefinition<Product> filter)
    {
        var sortDefn = Builders<Product>.Sort.Ascending("Name"); //Default sort
        if(!string.IsNullOrEmpty(catalogSpecParams.Sort))
        {
            switch(catalogSpecParams.Sort)
            {
                case "priceAsc":
                    sortDefn = Builders<Product>.Sort.Ascending(p=>p.Price);
                    break;
                case "priceDec":
                    sortDefn = Builders<Product>.Sort.Descending(p=>p.Price);
                    break;
                default:
                    break;
           }           

        }
        return await _context.Products.Find(filter).Sort(sortDefn)
                        .Skip(catalogSpecParams.PageSize * (catalogSpecParams.PageIndex-1))
                        .Limit(catalogSpecParams.PageSize).ToListAsync();
    }

}
