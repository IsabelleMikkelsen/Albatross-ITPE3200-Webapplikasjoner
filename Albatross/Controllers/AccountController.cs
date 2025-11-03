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
            return RedirectToAction("Dashboard", "User");
        }

        ModelState.AddModelError("", "Wrong username or password");
        return View(model);
    }
    //Switch between admin and player mode:
    [HttpPost]
    public async Task<IActionResult> SwitchToAdmin()
    {
        // Hent den nåværende brukeren (f.eks., JS eller TK)
        var currentUser = await _userManager.GetUserAsync(User);

        if (currentUser == null)
        {
            return NotFound("Den nåværende brukeren ble ikke funnet.");
        }

        // Lagre den nåværende bruker-ID-en i Session
        HttpContext.Session.SetString("OriginalUserId", currentUser.Id);

        // Finn admin-brukeren (f.eks. brukernavn "admin")
        var admin = await _userManager.FindByNameAsync("admin");

        if (admin == null)
        {
            return NotFound("Admin-brukeren ble ikke funnet.");
        }

        // Logg ut den nåværende brukeren
        await _signInManager.SignOutAsync();

        // Logg inn admin-brukeren uten å be om passord
        await _signInManager.SignInAsync(admin, isPersistent: false);

        // Gå til admin-dashboard
        return RedirectToAction("Dashboard", "User"); //admin

    }

[HttpPost]
public async Task<IActionResult> SwitchToUser()
{
    // Hent den opprinnelige brukerens ID fra session
    string originalUserId = HttpContext.Session.GetString("OriginalUserId");

    if (string.IsNullOrEmpty(originalUserId))
    {
        return NotFound("Opprinnelig bruker-ID ble ikke funnet i session.");
    }

    // Finn den opprinnelige brukeren
    var originalUser = await _userManager.FindByIdAsync(originalUserId);

    if (originalUser == null)
    {
        return NotFound("Den opprinnelige brukeren ble ikke funnet.");
    }

    // Logg ut admin-brukeren
    await _signInManager.SignOutAsync();

    // Logg inn som den opprinnelige brukeren
    await _signInManager.SignInAsync(originalUser, isPersistent: false);

    // Omdiriger tilbake til det generelle dashboardet
    return RedirectToAction("Dashboard", "User");
}
    //kladd: await _userManager.AddToRoleAsync(user, "Player");

    //Logout
    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }
}