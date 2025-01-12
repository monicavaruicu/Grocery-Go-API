﻿namespace GroceryGo_API.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int SubCategoryId { get; set; }
        public int ProviderId { get; set; }
        public string? Picture { get; set; }
        public int Stock { get; set; }
    }
}
