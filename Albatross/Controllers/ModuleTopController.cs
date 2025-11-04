using Microsoft.AspNetCore.Mvc;
using Albatross.Models;
using Albatross.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Albatross.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Albatross.Controllers;

//MED ASYNC
public class ModuleTopController : Controller
{
    
    private readonly IModuleTopicRepository _moduleRepository;
    private readonly ILogger<ModuleTopController> _logger;

    
    public ModuleTopController(IModuleTopicRepository moduleTopicRepository, ILogger<ModuleTopController> logger)
    {
        
        _moduleRepository = moduleTopicRepository;
        _logger = logger;
    }

    public async Task<IActionResult> Table()
    {
        var moduleTopics = await _moduleRepository.GetAll();
        var ModuleTopViewModel = new ModuleTopViewModel(moduleTopics, "Table");
        return View(ModuleTopViewModel);
    }

    public async Task<IActionResult> Details(int id)
    {
        var moduleTopic = await _moduleRepository.GetModuleTopicById(id);
        if (moduleTopic == null)
            return NotFound();
        return View(moduleTopic);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id)
    {
        var moduleTopic = await _moduleRepository.GetModuleTopicById(id);
        if (moduleTopic == null)
        {
            return NotFound();
        }
        return View(moduleTopic);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(ModuleTopic moduleTopic)
    {
        if (!ModelState.IsValid)
        {
            return View(moduleTopic);
        }
        
        try
        {
            await _moduleRepository.Update(moduleTopic);
            return RedirectToAction(nameof(Table));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating item");
            return View(moduleTopic);
        }
        }


    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Create(int moduleId)
    {
        var moduleTopic = new ModuleTopic
        {
            ModuleId = moduleId
        };
    
        return View(moduleTopic);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(ModuleTopic moduleTopic)
    {
        if (ModelState.IsValid)
        {
        
            
            await _moduleRepository.Create(moduleTopic);
                return RedirectToAction(nameof(Table));
        }
        //}
        return View(moduleTopic);
    }



    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var moduleTopic = await _moduleRepository.GetModuleTopicById(id);
        if (moduleTopic == null)
        {
            return NotFound();
        }
        return View(moduleTopic);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _moduleRepository.Delete(id);
        return RedirectToAction(nameof(Table));
        /*try
        {
            var moduleTopic = await _DbContext.ModuleTopics.FindAsync(id);
            if (moduleTopic == null)
            {
                _logger.LogWarning("Attempted to delete non-existent ModuleTopic {ModuleTopicId}", id);
                return NotFound();
            }

            _DbContext.ModuleTopics.Remove(moduleTopic);
            await _DbContext.SaveChangesAsync();
            _logger.LogInformation("ModuleTopic {ModuleTopicId} deleted successfully", id);
            return RedirectToAction(nameof(Table));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting ModuleTopic {ModuleTopicId}", id);
            ModelState.AddModelError("", "An error occurred while deleting the module topic.");
            return RedirectToAction(nameof(Table));
        }*/
    }
    
}