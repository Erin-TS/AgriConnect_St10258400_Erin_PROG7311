﻿using AgriConnect_St10258400_Erin_PROG7311.Data;
using AgriConnect_St10258400_Erin_PROG7311.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//remove logic from controller
namespace AgriConnect_St10258400_Erin_PROG7311.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly PasswordHasher<object> _passwordHasher;
        public UserController(AppDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<object>();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                var employeeUser = await _context.Employee
                    .FirstOrDefaultAsync(e => e.employeeEmail == userLoginModel.UserEmail);

                var farmerUser = await _context.Farmer.
                    FirstOrDefaultAsync(f => f.farmerEmail == userLoginModel.UserEmail);


                // Check if the user is an employee or a farmer
                if (employeeUser != null)
                {
                    Console.WriteLine($"Employee email found: {employeeUser?.employeeEmail}");
                    var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(employeeUser, employeeUser.employeePasswordHash, userLoginModel.UserPassword);
                    Console.WriteLine($"Password verification result: {passwordVerificationResult}"); // Debugging line
                    Console.WriteLine($"Hashed password: {employeeUser.employeePasswordHash}"); // Debugging line
                    Console.WriteLine($"User password: {userLoginModel.UserPassword}"); // Debugging line
                    if (passwordVerificationResult == PasswordVerificationResult.Success)
                    {
                        // Employee login 
                        HttpContext.Session.SetString("UserRole", "Employee");
                        HttpContext.Session.SetString("UserFullName", employeeUser.employeeFirstName + " " + employeeUser.employeeLastName);
                        TempData["SuccessMessage"] = "Registration successful. Please log in.";
                        // Redirect to employee dashboard 
                        return RedirectToAction("allProducts", "Employee");

                      
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid email or password.");
                        return View(userLoginModel);
                    }
                }
                else if (farmerUser != null)
                {
                    Console.WriteLine($"Farmer email found: {farmerUser?.farmerEmail}");
                    var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(farmerUser, farmerUser.farmerPasswordHash, userLoginModel.UserPassword);
                    if (passwordVerificationResult == PasswordVerificationResult.Failed)
                    {
                        ModelState.AddModelError("", "Invalid email or password.");
                        return View(userLoginModel);
                    }
                    else { 
                        // Farmer login 
                        HttpContext.Session.SetString("UserRole", "Farmer");
                        HttpContext.Session.SetString("UserFullName", farmerUser.farmerFirstName + " " + farmerUser.farmerLastName);
                       
                        TempData["SuccessMessage"] = "Login successful.";
                        // Redirect to the product listings page
                        return RedirectToAction("productListings", "Farmer");
                    }
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

        public IActionResult Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();

            // Redirect to the login page
            return RedirectToAction("login", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(EmployeeModel employee)
        {
            if(ModelState.IsValid)
            {
                // Registration logic for employees
                //check if the email already exists
                var existingEmployee = await _context.Employee
                    .FirstOrDefaultAsync(e => e.employeeEmail == employee.employeeEmail);

                if (existingEmployee != null)
                {
                    ModelState.AddModelError("employeeEmail", "Email already exists.");
                    return View(employee);
                }
                // Hash the password
                employee.employeePasswordHash = _passwordHasher.HashPassword(employee, employee.employeePasswordHash);

                // Save the employee to the database
                _context.Employee.Add(employee);
                await _context.SaveChangesAsync();

                // Redirect to the login page after successful registration
                TempData["SuccessMessage"] = "Registration successful. Please log in.";
                return RedirectToAction("login", "User");
            }
            return View();
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

