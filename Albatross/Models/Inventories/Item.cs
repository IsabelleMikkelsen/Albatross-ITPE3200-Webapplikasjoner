using System;

namespace Albatross.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty; 
        public string? ImageUrl { get; set; }

        public ICollection<Inventory> Inventories { get; set; } = new List<Inventory>();//*
    }
}