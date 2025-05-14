/*This is the HomeController class for the AgriConnect application. It handles the home page and error handling and unauthorized access redirection.*/
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
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

//------Namespace------//
namespace AgriConnect_St10258400_Erin_PROG7311.Controllers
{
    //------HomeController Class------//
    //this class is responsible for handling the home page and error handling
    public class HomeController : Controller
    {
        //------Private Fields declaration for class------//
        private readonly ILogger<HomeController> _logger;//this is a private field of type ILogger<HomeController> which is used for logging information and errors


        //-----Constructor------//
        //this constructor takes an instance of ILogger<HomeController> as a parameter and assigns it to the private field _logger
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //------Index Method------//
        //this method returns the view for the home page
        public IActionResult Index()
        {
            return View();
        }

        //------unAuthorisedAccess Method------//
        //this method returns the view for unauthorized access
        public IActionResult unAuthorisedAccess()
        {
            return View();
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
