//this is the controller for the employee role. it includes methods for adding farmers, viewing all products, and viewing farmer details.
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
using Microsoft.AspNetCore.Mvc.Rendering;

//-------Namespace------//
namespace AgriConnect_St10258400_Erin_PROG7311.Controllers
{
    //------EmployeeController Class------//
    public class EmployeeController : Controller
    {
        //------Private Fields declaration for class------//
        private readonly IEmployeeService _employeeService;//this is a private field of type IEmployeeService which is an interface that defines the employee service methods

        //------Constructor------//
        //this constructor takes an instance of IEmployeeService as a parameter and assigns it to the private field _employeeService
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        //------addFarmers Method------//
        //this get method returns the view for adding a farmer it executes when the page is loaded
        [HttpGet]
        public IActionResult addFarmers()
        {
            //this checks if the user is an employee
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "Employee")
            {
                return RedirectToAction("UnAuthorisedAccess", "Home");
                //this redirects to the unauthorized access page if the user is not an employee
            }
            return View();//this returns the view for adding a farmer
        }

        //------addFarmers Method------//
        //this post method handles the adding of a farmer when the form is submitted
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addFarmers(addFarmerModel addfarmermodel)
        {
            //this checks if the model state is valid
            if (ModelState.IsValid)
            {
                //this adds a new farmer to the database by assigning the input information from the form to the farmerModel
                var farmer = new FarmerModel
                {
                    farmerFirstName = addfarmermodel.farmerFirstName,
                    farmerLastName = addfarmermodel.farmerLastName,
                    farmerEmail = addfarmermodel.farmerEmail,
                    farmerLocation = addfarmermodel.farmerLocation,
                    farmerRole = "Farmer"
                };

                //this checks if the email is already registered
                var (success, result) = await _employeeService.addFarmersAsync(farmer);

                //this checks if the farmer was added successfully
                if (success)
                {
                    //this sets the success message in the TempData to be displayed on the view
                    TempData["SuccessMessage"] = $"Farmer profile added successfully for {farmer.farmerEmail}! Password: {result}" +
                        Environment.NewLine +
                        $"All farmer details can be viewed on the all farmers page";
                    return RedirectToAction("addFarmers");//this redirects to the add farmers page
                }
                else if (!success)
                {
                    //if the email is already registered this adds a model error
                    ModelState.AddModelError(farmer.farmerEmail, result);
                    return View(addfarmermodel);//this returns the view with the model error
                }
                else
                {//this executes if the farmer was not added successfully
                    ModelState.AddModelError("", "Failed to add farmer profile. Please try again.");
                }
            }
            else
            {
                return View(addfarmermodel);//this returns the view with the model error
            }
            return View(addfarmermodel); // Return the view with the model to show validation errors    
        }

        //------allProducts Method------//
        //this method returns the view for all products
        public async Task<IActionResult> allProducts()
        {
            //this gets the logged in user role from the session
            var role = HttpContext.Session.GetString("UserRole");
            //this checks if the user is an employee
            if (role != "Employee")
            {
                //this redirects to the unauthorized access page if the user is not an employee
                return RedirectToAction("UnAuthorisedAccess", "Home");
            }

            //this gets the products in the database via trhe employee service
            var productsList = await _employeeService.getProductsListAsync();
            //this gets the farmers in the database via the employee service
            var farmerList = await _employeeService.getallFarmersListAsync();

            //this assins the products and farmers to the product filter model as lists
            var productFilterModel = new ProductFilterModel
            {
                Products = productsList,
                Farmers = farmerList.Select(f => new SelectListItem
                {
                    Value = f.farmerId.ToString(),
                    Text = $"{f.farmerFirstName} {f.farmerLastName}"
                }).ToList()
            };
            
            return View(productFilterModel);//this returns the view for all products with the product filter model
        }

        //------allProducts Method------//
        //this method handles the filtering of products when the form is submitted
        [HttpPost]
        public async Task<IActionResult> allProducts(ProductFilterModel filterModel)
        {
            //this gets the products in the database via the employee service
            var productsList = await _employeeService.getProductsListAsync();

            //this checks if the filter model for category is not null
            if (filterModel.Category != null)
            {
                //this filters the products list by category
                productsList = productsList.Where(p => p.productCategory == filterModel.Category).ToList();
            }

            //this checks if the filter model for start date and end is not null
            if (filterModel.StartDate != null && filterModel.EndDate != null)
            {
                //this filters the products list by start date and end date(production date must fall within this range)
                productsList = productsList.Where(p => p.productionDate >= filterModel.StartDate && p.productionDate <= filterModel.EndDate).ToList();
            }

            //this checks if the filter model for selected farmer is not null
            if (filterModel.selectedFarmerId != null)
            {
                //this filters the products list by selected farmer
                productsList = productsList.Where(p => p.farmerId == filterModel.selectedFarmerId).ToList();
            }

            //this gets the farmers in the database via the employee service
            var farmerList = await _employeeService.getallFarmersListAsync();

            //this assigns the products and farmers to the product filter model as lists
            filterModel.Farmers = farmerList.Select(f => new SelectListItem
            {
                Value = f.farmerId.ToString(),
                Text = $"{f.farmerFirstName} {f.farmerLastName}"
            }).ToList();
            filterModel.Products = productsList;


            return View("allProducts",filterModel);//this returns the view for all products with the product filter model
        }

        //------FarmerDetails Method------//
        //this method returns the view for all farmers
        public async Task<IActionResult> FarmerDetails()
        {
            //this gets the logged in user role from the session
            var role = HttpContext.Session.GetString("UserRole");
            //this checks if the user is an employee
            if (role != "Employee")
            {
                //this redirects to the unauthorized access page if the user is not an employee
                return RedirectToAction("UnAuthorisedAccess", "Home");
            }
            //this gets the farmers in the database via the employee service
            var farmerList = await _employeeService.getallFarmersListAsync();
            return View(farmerList);//this returns the view for all farmers with the farmer list
        }

    }
}
