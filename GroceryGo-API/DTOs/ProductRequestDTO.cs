namespace GroceryGo_API.DTOs
{
    public class ProductRequestDTO
    {
        public int? CategoryId { get; set; }
        public required int SubcategoryId { get; set; }
    }
}
