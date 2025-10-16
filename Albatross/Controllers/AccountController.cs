using System;                        // Basic C#-functionality
using System.Threading.Tasks;        // Makes it possible to use async-methodes
using Microsoft.AspNetCore.Mvc;      // MVC-foundation: Controller, IActionResult, View(), RedirectToAction()
using Albatross.Models;              // Access to our own Models
using System.Security.Cryptography;  // Access to cryptographic algorithms
using System.Text;  
using System.Linq;


namespace Albatross.Controllers;

public class AccountController : Controller
{
    //Registration - New user
    public IActionResult Register()
    {
        return View();
    }
    //Handling registrationdata
    [HttpPost]
    public IActionResult Register(User user)
    {
        if (!ModelState.IsValid)
        {
        return View(user);   //Errormessage?
        }

        //Password hashing
        user.PasswordHashed = HashPassword(user.Password);

        //TO DO: Save user in database
        //db.Users.Add(user);
        //db.SaveChanges();

        return RedirectToAction("Login");
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }

    //Login
    public IActionResult Login()
    {
        return View();
    }
/*
    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        //TO DO: Get user from DB based on username
       /* var user = db.Users.FirstOrDefault(u => u.Username == username);

        if (user != null && user.PasswordHashed == HashPassword(password))
        {
            //TO DO: Session/cookie setup

            return RedirectToAction("Index", "Home");
        }

        ModelState.AddModelError("", "Wrong username or password");
        return View();
    }

    //Log out
    public IActionResult Logout()
    {
        //TO DO: Clear session/cookie
        return RedirectToAction("Login");
    } */
}