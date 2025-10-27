using Microsoft.AspNetCore.Mvc;
using Albatross.Models;
using Albatross.ViewModels;
using Microsoft.EntityFrameworkCore;
using Albatross.DAL;

namespace Albatross.Controllers;

//MED ASYNC
public class ItemController : Controller
{
    /*private readonly ItemDbContext _itemDbContext;
    private readonly ILogger<ItemController> _logger;

    public ItemController(ItemDbContext itemDbContext, ILogger<ItemController> logger)
    {
        _itemDbContext = itemDbContext;
        _logger = logger;
    } */
    //Using Repository Pattern
    private readonly IItemRepository _repository;
    private readonly ILogger<ItemController> _logger;

    public ItemController(IItemRepository repository, ILogger<ItemController> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<IActionResult> Table()
    {
        //List<Item> items = await _itemDbContext.Items.ToListAsync();
        //var ItemsViewModel = new ItemsViewModel(items, "Table");
        //return View(ItemsViewModel);
        //Method usiing repository
         var items = await _repository.GetAll();
        var ItemsViewModel = new ItemsViewModel(items.ToList(), "Table");
        return View(ItemsViewModel);
    }

    public async Task <IActionResult> Grid()
    {
        //List<Item> items = await _itemDbContext.Items.ToListAsync();
        //var ItemsViewModel = new ItemsViewModel(items, "Grid");
        //return View(ItemsViewModel);
        var items = await _repository.GetAll();
        var ItemsViewModel = new ItemsViewModel(items.ToList(), "Grid");
        return View(ItemsViewModel);
        
    }

    public async Task<IActionResult> Details(int id)
    {
        //List<Item> items = _itemDbContext.Items.ToList();
        //var item = await _itemDbContext.Items.FirstOrDefaultAsync(i => i.ItemId == id);
        //if (item == null)
            //return NotFound();
        //return View(item);
        var item = await _repository.GetItemById(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }


    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        //var item = await _itemDbContext.Items.FindAsync(id); //await
        //if (item == null)
        //{
            //return NotFound();
        //}
        //return View(item);
        var item = await _repository.GetItemById(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Item item)
    {
       /* if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid model state for item update");
            return View(item);
        }

        try
        {
            _itemDbContext.Items.Update(item);
            await _itemDbContext.SaveChangesAsync();
            _logger.LogInformation("Item {ItemId} updated successfully", item.ItemId);
            return RedirectToAction(nameof(Table));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating item {ItemId}", item.ItemId);
            ModelState.AddModelError("", "An error occurred while updating the item.");
            return View(item);
        } */
        if (!ModelState.IsValid)
        {
            return View(item);
        }

        try
        {
            await _repository.Update(item);
            return RedirectToAction(nameof(Table));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating item");
            return View(item);
        }
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Item item)
    {
        /*if (!ModelState.IsValid)
        {
            _logger.LogWarning("Invalid model state for item creation");
            return View(item);
        }

        try
        {
            _itemDbContext.Items.Add(item);
            await _itemDbContext.SaveChangesAsync();
            _logger.LogInformation("Item {ItemName} created successfully", item.Name);
            return RedirectToAction(nameof(Table));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating item");
            ModelState.AddModelError("", "An error occurred while creating the item.");
            return View(item);
        }*/
        if (!ModelState.IsValid)
        {
            return View(item);
        }

        try
        {
            await _repository.Create(item);
            return RedirectToAction(nameof(Table));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating item");
            return View(item);
        }
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        /*try
        {
            var item = await _itemDbContext.Items.FindAsync(id);
            if (item == null)
            {
                _logger.LogWarning("Attempted to delete non-existent item {ItemId}", id);
                return NotFound();
            }
            
            _itemDbContext.Items.Remove(item);
            await _itemDbContext.SaveChangesAsync();
            _logger.LogInformation("Item {ItemId} deleted successfully", id);
            return RedirectToAction(nameof(Table));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting item {ItemId}", id);
            ModelState.AddModelError("", "An error occurred while deleting the item.");
            return RedirectToAction(nameof(Table));
        }*/
        try
        {
            var result = await _repository.Delete(id);
            if (!result)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Table));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting item");
            return RedirectToAction(nameof(Table));
        }
    }

    /*
    [HttpPost]
    public async Task<IActionResult> Update(Item item)
    {

        if (ModelState.IsValid)
        {
            _itemDbContext.Items.Update(item);
            await _itemDbContext.SaveChangesAsync(); //await
            return RedirectToAction(nameof(Table));
        }

        return View(item);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Item item)
    {

        if (ModelState.IsValid)
        {
            _itemDbContext.Items.Add(item);
            await _itemDbContext.SaveChangesAsync(); //await
            return RedirectToAction(nameof(Table));
        }

        return View(item);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _itemDbContext.Items.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var item = await _itemDbContext.Items.FindAsync(id);
        if (item == null)
        {
            return NotFound();
        }
        _itemDbContext.Items.Remove(item);
        await _itemDbContext.SaveChangesAsync(); //await
        return RedirectToAction(nameof(Table));
    } */
}

//UTEN ASYNC
/*public class ItemController : Controller
{
    private readonly ItemDbContext _itemDbContext;

    public ItemController(ItemDbContext itemDbContext)
    {

        _itemDbContext = itemDbContext;
    }
    public IActionResult Table()
    {
        List<Item> items = _itemDbContext.Items.ToList();
        var ItemsViewModel = new ItemsViewModel(items, "Table");
        return View(ItemsViewModel);
    }

    public IActionResult Details(int id)
    {
        List<Item> items = _itemDbContext.Items.ToList();
        var item = items.FirstOrDefault(i => i.ItemId == id);
        if (item == null)
            return NotFound();
        return View(item);
    }

   [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Item item)
    {
        if (ModelState.IsValid)
        {
            _itemDbContext.Items.Add(item);
            _itemDbContext.SaveChanges();
             Console.WriteLine($"Item created: {item.Name}, {item.Type}, {item.ImageUrl}"); //*
            return RedirectToAction(nameof(Table));
        }
        return View(item);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var item = _itemDbContext.Items.Find(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }
    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var item = _itemDbContext.Items.Find(id);
        if (item == null)
        {
            return NotFound();
        }
        _itemDbContext.Items.Remove(item);
        _itemDbContext.SaveChanges();
        return RedirectToAction(nameof(Table));
    }
}*/
