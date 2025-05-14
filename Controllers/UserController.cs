/*this file is the user controller. It is responsible for handling user login, registration, and logout functionality.
It uses the IUserService interface to validate user credentials and register new employees.*/
/*Refrences links:
 *https://www.completecsharptutorial.com/asp-net-mvc5/asp-net-mvc-5-httpget-and-httppost-method-with-example.php#:~:text=HTTP%20is%20a%20HyperText%20Transfer,web%20pages%20to%20the%20server.
 *https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-9.0&tabs=visual-studio
 *https://www.youtube.com/watch?v=8fFBWmbUaIg
 *https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/models-data/validating-with-a-service-layer-cs
 *https://tom-collings.medium.com/controller-service-repository-16e29a4684e5
 *https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions-1/controllers-and-routing/aspnet-mvc-controllers-overview-cs
 *https://www.youtube.com/watch?v=-LAeEQSfOQk
 *https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-9.0
 *https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-9.0
 *https://www.c-sharpcorner.com/article/session-in-asp-net-core-mvc-net-8/
*/



//------Imports------//
using AgriConnect_St10258400_Erin_PROG7311.Models;
using AgriConnect_St10258400_Erin_PROG7311.Services;
using Microsoft.AspNetCore.Mvc;

//------Namespace------//
namespace AgriConnect_St10258400_Erin_PROG7311.Controllers
{
    //------UserController Class------//
    public class UserController : Controller
    {
        //------Private Fields declaration for class------//
        private readonly IUserService _userService; //this is a private field of type IUserService which is an interface that defines the user service methods

        //------Constructor------//
        //this constructor takes an instance of IUserService as a parameter and assigns it to the private field _userService
        public UserController(IUserService userService)
        {
            _userService = userService;

        }


        //------Login Method------//
        //this method handles the login functionality for users once the login form is submitted
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel userLoginModel)
        {
            //this method checks if the model state is valid
            if (ModelState.IsValid)
            {
                // Call the user service to validate the user credentials
                var (success, role, fullName) = await _userService.ValidateUserLogin(userLoginModel);

                // Check if the user is valid
                if (success)
                {
                    // Store user information in session
                    HttpContext.Session.SetString("UserEmail", userLoginModel.UserEmail);
                    HttpContext.Session.SetString("UserRole", role);
                    HttpContext.Session.SetString("FullName", fullName);

                    // Redirect to the appropriate page based on the role
                    if (role == "Employee")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (role == "Farmer")
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                { //this executes if the user credentials are invalid
                    ModelState.AddModelError("", "Invalid password or email. Please try again.");
                }
            }

            //something failed redisplay form
            return View(userLoginModel);
        }

        //------Logout Method------//
        //this method handles the logout functionality for users
        public IActionResult Logout()
        {
            // Clear the session
            HttpContext.Session.Clear();

            // Redirect to the login page
            return RedirectToAction("Index", "Home");
        }


        //------Register Method------//
        //this method handles the registration functionality for new employees
        [HttpPost]
        public async Task<IActionResult> Register(EmployeeModel employee)
        {
            //this method checks if the model state is valid
            if (ModelState.IsValid)
            {
                // Call the user service to register the employee
                var (success, errorMsg) = await _userService.RegisterEmployee(employee);
                // Check if the registration was successful
                if (!success)
                {
                    //if the registration was unsuccessful
                    ModelState.AddModelError("", errorMsg);
                    return View(employee);
                }

                // Redirect to the login page after successful registration
                TempData["SuccessMessage"] = "Registration successful. Please log in.";
                return RedirectToAction("login", "User");
            }
            // something failed redisplay form
            return View(employee);
        }

        //------Login View Method------//
        //this method returns the login view
        public IActionResult Login()
        {
            return View();
        }

        //------Register View Method------//
        //this method returns the register view
        public IActionResult Register()
        {
            return View();
        }
    }      
}

