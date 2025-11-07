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
public class NewQuizController : Controller
{
    
    private readonly INewQuizRepository _newQuizRepository;
    private readonly ILogger<NewQuizController> _logger;

    
    public NewQuizController(INewQuizRepository newQuizRepository, ILogger<NewQuizController> logger)
    {
        
        _newQuizRepository = newQuizRepository;
        _logger = logger;
    }

    public async Task<IActionResult> Table()
    {
        var newQuizzes = await  _newQuizRepository.GetAll();
        var NewQuizViewModel = new NewQuizViewModel(newQuizzes, "Table");
        return View(NewQuizViewModel);
    }

    public async Task<IActionResult> Details(int id)
    {
        var newQuiz = await _newQuizRepository.GetNewQuizById(id);
        if (newQuiz == null)
            return NotFound();
        return View(newQuiz);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(int id)
    {
        var newQuiz = await _newQuizRepository.GetNewQuizById(id);
        if (newQuiz == null)
        {
            return NotFound();
        }
        return View(newQuiz);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Update(NewQuiz newQuiz)
    {
        if (!ModelState.IsValid)
        {
            return View(newQuiz);
        }
        
        try
        {
            await _newQuizRepository.Update(newQuiz);
            return RedirectToAction(nameof(Table));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating item");
            return View(newQuiz);
        }
        }


    [HttpGet]
    [Authorize(Roles = "Admin")]
    public IActionResult Create(int NewQuizId)
    {
        var newQuiz = new NewQuiz
        {
            NewQuizId = NewQuizId
        };
    
        return View(newQuiz);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Create(NewQuiz newQuiz)
    {
        if (ModelState.IsValid)
        {
        
            
            await _newQuizRepository.Create(newQuiz);
                return RedirectToAction(nameof(Table));
        }
        //}
        return View(newQuiz);
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {

        var newQuiz = await _newQuizRepository.GetNewQuizById(id);
        if (newQuiz == null)
        {
            return NotFound();
        }

        if (id == 114 || id == 115)
        {
            return BadRequest("Cannot delete demo modules.");
        }
    
        return View(newQuiz);
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _newQuizRepository.Delete(id);
        return RedirectToAction(nameof(Table));
        
    }
    
}