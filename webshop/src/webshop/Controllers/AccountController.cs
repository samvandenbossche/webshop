using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webshop.Models;

public class AccountController : Controller
{
    private readonly UserManager<User> userManager;
    private readonly SignInManager<User> loginManager;
    private readonly RoleManager<Role> roleManager;


    public AccountController(UserManager<User> userManager, SignInManager<User> loginManager, RoleManager<Role> roleManager)
    {
        this.userManager = userManager;
        this.loginManager = loginManager;
        this.roleManager = roleManager;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(RegisterViewModel obj)
    {
        if (ModelState.IsValid)
        {
            User user = new User();
            user.UserName = obj.UserName;
            user.Email = obj.Email;
            user.FirstName = obj.FirstName;
            user.LastName = obj.LastName;
            user.Adress = obj.Adress;
            user.City = obj.City;
            user.PostalCode = obj.Postalcode;
            user.Country = obj.Country;

            IdentityResult result = userManager.CreateAsync(user, obj.Password).Result;

            if (result.Succeeded)
            {
                if (!roleManager.RoleExistsAsync("NormalUser").Result)
                {
                    Role role = new Role();
                    role.Name = "NormalUser";
                    role.Description = "Perform normal operations.";
                    IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                    if (!roleResult.Succeeded)
                    {
                        ModelState.AddModelError("",
                         "Error while creating role!");
                        return View(obj);
                    }
                }

                userManager.AddToRoleAsync(user, "NormalUser").Wait();
                return RedirectToAction("Login", "Account");
            }
        }
        return View(obj);
    }

}