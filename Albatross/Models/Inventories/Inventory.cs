using System;
namespace Albatross.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        
        public int ItemId { get; set; } //2.nøkkel:
        
         public Item Item { get; set; } //*
    }
}