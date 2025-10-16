using Albatross.Models;

namespace Albatross.ViewModels
{
    public class ItemsViewModel
    {

        public IEnumerable<Item> Items;  //{get; set;}

        public string? CurrentViewName; //{get; set;}

        public ItemsViewModel(IEnumerable<Item> items, string? currentViewName)
        {
            Items = items;
            CurrentViewName = currentViewName;
        }
    }
}