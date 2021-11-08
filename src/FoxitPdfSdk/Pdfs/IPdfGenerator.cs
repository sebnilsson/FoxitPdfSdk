using System.IO;
using FoxitPdfSdk.Products;

namespace FoxitPdfSdk.Pdfs
{
    public interface IPdfGenerator
    {
        Stream GenerateForProduct(Product product);
    }
}
