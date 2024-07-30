namespace Catalog.Core;

public interface IBrandRepository
{
    Task<IEnumerable<ProductBrand>> GetAllBrands();

}
