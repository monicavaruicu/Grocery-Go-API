namespace GroceryGo_API.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime PlacementDate { get; set; }
        public int UserId { get; set; }
        public int OrderStatusId { get; set; }
        public int PaymentMethodId { get; set; }
        public int Total { get; set; }
    }
}