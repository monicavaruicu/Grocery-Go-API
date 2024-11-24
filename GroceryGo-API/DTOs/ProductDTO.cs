namespace GroceryGo_API.DTOs
{
    public class ProductDTO
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required int Price { get; set; }
        public required bool IsAvailable { get; set; }
        public required int SubcategoryId { get; set; }
        public required int ProviderId { get; set; }
        public string? Picture { get; set; }
    }
}
