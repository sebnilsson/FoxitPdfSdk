using System.Collections.Generic;

namespace FoxitPdfSdk.Products
{
    public interface IProductService
    {
        IReadOnlyList<Product> GetList();
        Product? GetProduct(long productId);
    }
}