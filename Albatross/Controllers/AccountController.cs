using System;                        // Basic C#-functionality
using System.Threading.Tasks;        // Makes it possible to use async-methodes
using Microsoft.AspNetCore.Mvc;      // MVC-foundation: Controller, IActionResult, View(), RedirectToAction()
using Albatross.Models;              // Access to our own Models
using System.Security.Cryptography;  // Access to cryptographic algorithms
using System.Text;  
using System.Linq;
using Microsoft.AspNetCore.Identity;


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
    public async Task<IActionResult> Register(User user)
    {
        if (!ModelState.IsValid)
        {
        return View(user);
        }

        //Hashes/salts pw, saves to DB, validates pw strength, handles duplicate emails/usernames
        var result = await _userManager.CreateAsync(user, user.PasswordHash);
        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Dashboard", "User");
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError(string.Empty, error.Description);
        }

        return View(user);
    }

    //Login
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(username, password, false, false);
        
        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home");
        }
        
        ModelState.AddModelError("", "Wrong username or password");
        return View();
    }

    //Logout
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
}