/*using Microsoft.AspNetCore.Mvc;
using Albatross.Models;
using Albatross.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Albatross.Controllers;

//MED ASYNC
public class ModuleTopController : Controller
{
    private readonly ItemDbContext _DbContext;
    private readonly ILogger<ModuleTopController> _logger;

    public ModuleTopController(ItemDbContext DbContext, ILogger<ModuleTopController> logger)
    {
        _DbContext = DbContext;
        //_itemDbContext = itemDbContext;
        //_logger = logger;
    }
    public async Task<IActionResult> Table()
    {
        List<ModuleTopic> moduleTopics = await _DbContext.ModuleTopics.ToListAsync();
        var ModuleTopViewModel = new ModuleTopViewModel(moduleTopics, "Table");
        return View(ModuleTopViewModel);
    }

/*
    public async Task<IActionResult> Grid()
    {
        List<Item> items = await _itemDbContext.Items.ToListAsync();
        var ItemsViewModel = new ItemsViewModel(items, "Grid");
        return View(ItemsViewModel);
    }
*/
    /*public async Task<IActionResult> Details(int id)
    {
        //List<Item> items = _itemDbContext.Items.ToList();
        var moduleTopic = await _DbContext.ModuleTopics.FirstOrDefaultAsync(i => i.ModuleTopicId == id);
        if (moduleTopic== null)
            return NotFound();
        return View(moduleTopic);
    }

/*
    [HttpGet]
    public async Task<IActionResult> Update(int id)
    {
        var item = await _itemDbContext.Items.FindAsync(id); //await
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }
    
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
*/
   /* [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ModuleTopic moduleTopic)
    {

        if (ModelState.IsValid)
        {
            _DbContext.ModuleTopics.Add(moduleTopic);
            await _DbContext.SaveChangesAsync(); //await
            return RedirectToAction(nameof(Table));
        }

        return View(moduleTopic);
    }
/*
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
    }*/
//}