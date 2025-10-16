using Microsoft.AspNetCore.Mvc;
using Albatross.Models;
using Albatross.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Albatross.Controllers;
//UTEN ASYNC
public class ItemController : Controller
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
}
//MED ASYNC
/*
public class ItemController : Controller
{
    private readonly ItemDbContext _itemDbContext;
    private readonly ILogger<ItemController> _logger;

    public ItemController(ItemDbContext itemDbContext, ILogger<ItemController> logger)
    {
        _itemDbContext = itemDbContext;
        _logger = logger;
    }
    public async Task<IActionResult> Table()
    {
        List<Item> items = await _itemDbContext.Items.ToListAsync();
        var ItemsViewModel = new ItemsViewModel(items, "Table");
        return View(ItemsViewModel);
    }

    public async Task<IActionResult> Details(int id)
    {
        //List<Item> items = _itemDbContext.Items.ToList();
        var item = await _itemDbContext.Items.FirstOrDefaultAsync(i => i.ItemId == id);
        if (item == null)
            return NotFound();
        return View(item);
    }

    /*[HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        
    }*/
/*
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
            _itemDbContext.SaveChangesAsync();
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
        _itemDbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Table));
    }
}
*/