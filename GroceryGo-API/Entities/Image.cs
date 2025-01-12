namespace GroceryGo_API.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int ImageTypeId { get; set; }
        public string FileName { get; set; }
    }
}
