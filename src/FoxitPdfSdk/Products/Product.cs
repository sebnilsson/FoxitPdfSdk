namespace FoxitPdfSdk.Products
{
    public class Product
    {
        public Product(
            long id,
            string name,
            string description,
            double price,
            string? imageUrl = null)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            ImageUrl = imageUrl ?? string.Empty;
        }

        public long Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public double Price { get; private set; }

        public string ImageUrl { get; private set; }

        public bool HasImageUrl => !string.IsNullOrWhiteSpace(ImageUrl);
    }
}
