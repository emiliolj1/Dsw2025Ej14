using Dsw2025Ej14.Api.Domain;

namespace Dsw2025Ej14.Api.Data
{
    public interface IPersistencia
    {
        IEnumerable<Product> GetProducts();
        Product? GetBySku(string sku);
    }
}
