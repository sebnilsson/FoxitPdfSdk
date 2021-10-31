namespace FoxitPdfSdk.Products
{
    public record Product(long Id, string Name, string Description, double Price, string? ImageUrl = null)
    {
        public bool HasImageUrl => !string.IsNullOrWhiteSpace(ImageUrl);
    }
}
