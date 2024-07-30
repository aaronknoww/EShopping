namespace Catalog.Core;

public interface ITypesRepository
{
    Task<IEnumerable<ProductType>> GetAllTypes();

}
