using System.Collections.Generic;
using FoxitPdfSdk.Products;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace FoxitPdfSdk.WebApp.Pages
{
    public class CatalogModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly ILogger<CatalogModel> _logger;

        public CatalogModel(IProductService productService, ILogger<CatalogModel> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        public void OnGet()
        {
            Products = _productService.GetList();
        }

        public IReadOnlyList<Product> Products { get; private set; } = new List<Product>(0);
    }
}
