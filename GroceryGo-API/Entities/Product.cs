namespace GroceryGo_API.Entities
{
    public class Product
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required int Price { get; set; }
        public required bool IsAvailable { get; set; }
        public required int SubCategoryId { get; set; }
        public required int ProviderId { get; set; }
        public string? Picture { get; set; }
    }
}
