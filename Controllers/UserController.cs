using AgriConnect_St10258400_Erin_PROG7311.Data;
using AgriConnect_St10258400_Erin_PROG7311.Models;
using AgriConnect_St10258400_Erin_PROG7311.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgriConnect_St10258400_Erin_PROG7311.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;

        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
               var(success, role, fullName) = await _userService.ValidateUserLogin(userLoginModel);

                if (success)
                {
                    // Store user information in session
                    HttpContext.Session.SetString("UserEmail", userLoginModel.UserEmail);
                    HttpContext.Session.SetString("UserRole", role);
                    HttpContext.Session.SetString("FullName", fullName);

                    // Redirect to the appropriate page based on the role
                    if (role == "Employee")
                    {
                        return RedirectToAction("allProducts", "Employee");
                    }
                    else if (role == "Farmer")
                    {
                        return RedirectToAction("productListings", "Farmer");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid password or email. Please try again.");
                }
            }

            // If we got this far, something failed redisplay form
            return View(userLoginModel);
        }

        public IActionResult Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();

            // Redirect to the login page
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(EmployeeModel employee)
        {
            if(ModelState.IsValid)
            {
                var (success, errorMsg) = await _userService.RegisterEmployee(employee);
                if (!success)
                {
                    ModelState.AddModelError("", errorMsg);
                    return View(employee);
                }

                // Redirect to the login page after successful registration
                TempData["SuccessMessage"] = "Registration successful. Please log in.";
                return RedirectToAction("login", "User");
            }
            return View(employee);
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
    }      
}

