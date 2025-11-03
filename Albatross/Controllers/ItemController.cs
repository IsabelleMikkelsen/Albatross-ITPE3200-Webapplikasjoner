using Microsoft.AspNetCore.Mvc;
using Albatross.Models;
using Albatross.ViewModels;
using Microsoft.EntityFrameworkCore;
using Albatross.DAL;
using Microsoft.AspNetCore.Authorization;

namespace Albatross.Controllers;

//MED ASYNC
public class ItemController : Controller
{
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
        var items = await _repository.GetAll();
        var ItemsViewModel = new ItemsViewModel(items.ToList(), "Table");
        return View(ItemsViewModel);
    }

    public async Task <IActionResult> Grid()
    {
        var items = await _repository.GetAll();
        var ItemsViewModel = new ItemsViewModel(items.ToList(), "Grid");
        return View(ItemsViewModel);
        
    }

    public async Task<IActionResult> Details(int id)
    {
        var item = await _repository.GetItemById(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }


    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id)
    {
        var item = await _repository.GetItemById(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(Item item)
    {
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
    [Authorize(Roles = "Admin")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(Item item)
    {
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

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _repository.GetItemById(id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
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

}
