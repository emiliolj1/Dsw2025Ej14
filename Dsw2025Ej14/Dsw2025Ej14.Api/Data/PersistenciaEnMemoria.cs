using Dsw2025Ej14.Api.Domain;
using System.Text.Json;
namespace Dsw2025Ej14.Api.Data
{
    public class PersistenciaEnMemoria : IPersistencia
    {
        private readonly List<Product> _products = new();

        public PersistenciaEnMemoria()
        {
            LoadProducts();
        }

        private void LoadProducts()
        {
            var json = File.ReadAllText("Data\\products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? [];
        }

        public IEnumerable<Product> GetActiveProducts()
        {
            return _products.Where(p => p.isActive);
        }

        public Product? GetBySku(string sku)
        {
            return _products.FirstOrDefault(p => p.Sku.Equals(sku, StringComparison.OrdinalIgnoreCase));
        }

    }
}
