using System;                        // Basic C#-functionality
using System.Threading.Tasks;        // Makes it possible to use async-methodes
using Microsoft.AspNetCore.Mvc;      // MVC-foundation: Controller, IActionResult, View(), RedirectToAction()
using Albatross.Models;              // Access to our own Models
using Microsoft.AspNetCore.Identity;
using Albatross.ViewModels;


namespace Albatross.Controllers;

public class AccountController : Controller
{
    //Injecting UserManager and SignInManager
    //Handles creating, deleting, and managing users
    private readonly UserManager<User> _userManager;
    //Handles login, logout, and authentication cookies for users
    private readonly SignInManager<User> _signInManager;

    //Constructor for injecting UserManager and SignInManager
    public AccountController(
        UserManager<User> userManager,
        SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
    //Registration - New user
    public IActionResult Register()
    {
        return View();
    }
    //Handling registration data
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
        return View(model);
        }

        var user = new User
        {
            UserName = model.Username,
            Email = model.Email,
            FirstName = model.FirstName,
            LastName = model.LastName
        };

        // Identity handles password hashing, validation, uniqueness, and saving to DB
        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            //Default role as player (since most users will be)
            await _userManager.AddToRoleAsync(user, "Player");

            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Dashboard", "User");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(model);
    }

    //Login
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var result = await _signInManager.PasswordSignInAsync(
            model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
        
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }
        
        ModelState.AddModelError("", "Wrong username or password");
        return View(model);
    }

    //Logout
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
}