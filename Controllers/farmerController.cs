//this is a controller for managing farmer actions. It includes methods for adding products and viewing product listings.
/*RefrenceLinks:
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

//-------Imports------//
using AgriConnect_St10258400_Erin_PROG7311.Models;
using AgriConnect_St10258400_Erin_PROG7311.Services;
using Microsoft.AspNetCore.Mvc;

//-------Namespace------//
namespace AgriConnect_St10258400_Erin_PROG7311.Controllers
{
    //------farmerController Class------//
    public class farmerController : Controller
    {
        //------Private Fields declaration for class------//
        private readonly IFarmerService _farmerService;//this is a private field of type IFarmerService which is an interface that defines the farmer service methods

        //------Constructor------//
        //this constructor takes an instance of IFarmerService as a parameter and assigns it to the private field _farmerService
        public farmerController(IFarmerService farmerService)
        {
            _farmerService = farmerService;
        }

        //------AddProduct Method------//
        //this get method returns the view for adding a product it executes when the page is loaded
        [HttpGet]
        public IActionResult AddProduct()
        {
           var role = HttpContext.Session.GetString("UserRole");
            if (role != "Farmer")
            {
                return RedirectToAction("UnAuthorisedAccess", "Home");
            }
            return View();
        }

        //------AddProduct Method------//
        //this post method handles the adding of a product when the form is submitted
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(ProductModel product)
        {
            //this gets the logged in farmer's email from the session
            var farmerEmail = HttpContext.Session.GetString("UserEmail");

            //this checks if the user is a farmer
            var farmer = await _farmerService.GetFarmerByEmailAsync(farmerEmail);
            //this checks if the farmer is null
            if ( farmer== null)
            {
                //this adds a model error if the farmer is not found
                ModelState.AddModelError("", "Farmer not found. Please try again.");
                return View(product);//this returns the view with the model error
            }

            //this sets the farmerId of the product to the logged in farmer's id
            product.farmerId = farmer.farmerId;

            //this checks if the model state is valid
            if (ModelState.IsValid)
            {
                //this ands the product to the database using the farmer service
                var (success, productName) = await _farmerService.addProductAsync(product);
                //this checks if the product was added successfully
                if (success)
                {
                    //this sets a success message in the TempData to be displayed on  page
                    TempData["SuccessMessage"] = $"Product({productName}) added successfully!";
                    return RedirectToAction("AddProduct");//this redirects to the add product page
                }
                else if (!success)
                {
                    //this adds a model error if the product name already exists
                    ModelState.AddModelError(product.productName, productName);
                    return View(product);//this returns the view with the model error
                }
               
            }
            else
            {
                //this adds a model error if the model state is not valid
                ModelState.AddModelError("", "Failed to add product. Please try again.");
            }
            return View(product);//this returns the view with the model error
        }

        //------ProductListings Method------//
        //this method returns the view for product listings
        public async Task<IActionResult> productListings()
        {
            //this gets the logged in user role from the session
            var role = HttpContext.Session.GetString("UserRole");
            //this checks if the user is a farmer
            if (role != "Farmer")
            {
                return RedirectToAction("UnAuthorisedAccess", "Home");//this redirects to the unauthorized access page if a user is not a farmer
            }

            //this gets the logged in user email from the session
            var farmerEmail = HttpContext.Session.GetString("UserEmail");
            //this gets the logged in user from the session by the email
            var farmer = await _farmerService.GetFarmerByEmailAsync(farmerEmail);
            //this checks if the farmer is null
            if (farmer == null)
            {
                //this adds a model error if the farmer is not found
                ModelState.AddModelError("", "Farmer not found. Please try again.");
                return View();
            }

            //this gets all the products for the logged in farmer by the farmer id
            var products = await _farmerService.GetAllProductsByFarmerAsync(farmer.farmerId);
            //this checks if the products are null or empty
            if (products == null || products.Count == 0)
            {
                //this adds a model error if no products are found
                ModelState.AddModelError("", "No products found for this farmer.");
                return View();
            }
            return View(products);//this returns the view with the products
        }
    }
}
