using Microsoft.AspNetCore.Mvc;
using Albatross.Models;
using Albatross.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace Albatross.Controllers;

//MED ASYNC
public class NullModuleTopController : Controller
{
    private readonly ItemDbContext _DbContext;
    private readonly ILogger<NullModuleTopController> _logger;

    public NullModuleTopController(ItemDbContext DbContext, ILogger<NullModuleTopController> logger)
    {
        _DbContext = DbContext;
        //_itemDbContext = itemDbContext;
        //_logger = logger;
    }
    public async Task<IActionResult> Table()
    {
        List<NullModuleTopic> NullModuleTopics = await _DbContext.NullModuleTopics.ToListAsync();
        var NullModuleTopViewModel = new ModuleTopViewModel(NullModuleTopics, "Table");
        return View(NullModuleTopViewModel);
    }

/*
    public async Task<IActionResult> Grid()
    {
        List<Item> items = await _itemDbContext.Items.ToListAsync();
        var ItemsViewModel = new ItemsViewModel(items, "Grid");
        return View(ItemsViewModel);
    }
*/
    public async Task<IActionResult> Details(int id)
    {
        //List<Item> items = _itemDbContext.Items.ToList();
        var nullmoduleTopic = await _DbContext.NullModuleTopics.FirstOrDefaultAsync(i => i.NullModuleTopicId == id);
        if (nullmoduleTopic== null)
            return NotFound();
        return View(nullmoduleTopic);
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
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(NullModuleTopic nullmoduleTopic)
    {

        if (ModelState.IsValid)
        {
            _DbContext.NullModuleTopics.Add(nullmoduleTopic);
            await _DbContext.SaveChangesAsync(); //await
            return RedirectToAction(nameof(Table));
        }

        return View(nullmoduleTopic);
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
}