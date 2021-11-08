using FoxitPdfSdk.Pdfs;
using FoxitPdfSdk.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FoxitPdfSdk.WebApp.Pages
{
    public class PdfModel : PageModel
    {
        private readonly IPdfGenerator _pdfGenerator;
        private readonly IProductService _productService;
        private readonly ILogger<PdfModel> _logger;

        public PdfModel(IProductService productService, IPdfGenerator pdfGenerator, ILogger<PdfModel> logger)
        {
            _pdfGenerator = pdfGenerator;
            _productService = productService;
            _logger = logger;
        }

        public IActionResult OnGet(long id)
        {
            var product = _productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }

            var pdfStream = _pdfGenerator.GenerateForProduct(product);

            return new FileStreamResult(pdfStream, "application/pdf");
        }
    }
}
