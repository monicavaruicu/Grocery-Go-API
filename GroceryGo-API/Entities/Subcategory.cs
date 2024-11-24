namespace GroceryGo_API.Entities
{
    public class Subcategory
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int CategoryId { get; set; }
    }
}
