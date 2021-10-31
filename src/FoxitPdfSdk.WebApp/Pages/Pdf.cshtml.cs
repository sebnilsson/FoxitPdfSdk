using FoxitPdfSdk.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FoxitPdfSdk.WebApp.Pages
{
    public class PdfModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ILogger<PdfModel> _logger;

        public PdfModel(IProductService productService, ILogger<PdfModel> logger)
        {
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

            Product = product;

            return Page();
        }

        public Product Product { get; private set; } = null!;
    }
}
