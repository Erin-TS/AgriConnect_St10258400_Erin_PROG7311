using AgriConnect_St10258400_Erin_PROG7311.Data;
using AgriConnect_St10258400_Erin_PROG7311.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgriConnect_St10258400_Erin_PROG7311.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> login(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                var employeeUser = await _context.Employee
                    .FirstOrDefaultAsync(e => e.employeeEmail == userLoginModel.UserEmail && e.employeePasswordHash == userLoginModel.UserPassword);

                var farmerUser = await _context.Farmer.
                    FirstOrDefaultAsync(f => f.farmerEmail == userLoginModel.UserEmail && f.farmerPasswordHash == userLoginModel.UserPassword);


                // Check if the user is an employee or a farmer
                if (employeeUser != null)
                {
                    // Employee login 
                    HttpContext.Session.SetString("UserRole", "Employee");
                    HttpContext.Session.SetString("UserfullName", employeeUser.employeeFirstName + " " + employeeUser.employeeLastName);
                    // Redirect to employee dashboard 
                    return RedirectToAction("allProducts", "Employee");
                }
                else if (farmerUser != null)
                {
                    // Farmer login 
                    HttpContext.Session.SetString("UserRole", "Farmer");
                    HttpContext.Session.SetString("UserfullName", farmerUser.farmerFirstName + " " + farmerUser.farmerLastName);
                    // Redirect to farmer dashboard
                    return RedirectToAction("productListings", "Farmer");
                }
                else
                {
                    // Invalid login
                    ModelState.AddModelError("", "Invalid email or password.");
                }
            }

            // If we got this far, something failed redisplay form
            return View(userLoginModel);
        }
    }      
}

