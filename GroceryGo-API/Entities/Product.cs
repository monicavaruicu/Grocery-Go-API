namespace GroceryGo_API.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public bool IsAvailable { get; set; }
        public int SubcategoryId { get; set; }
        public int ProviderId { get; set; }
        public string? Picture { get; set; }
    }
}
