namespace GroceryGo_API.DTOs
{
    public class OrderDTO
    {
        public string Address { get; set; }
        public int UserId { get; set; }
        public int PaymentMethodId { get; set; }
        public int Total {  get; set; }
    }
}
