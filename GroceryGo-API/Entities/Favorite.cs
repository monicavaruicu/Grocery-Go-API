namespace GroceryGo_API.Entities
{
    public class Favorite
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
    }
}
