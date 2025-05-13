using AgriConnect_St10258400_Erin_PROG7311.Models;
using AgriConnect_St10258400_Erin_PROG7311.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgriConnect_St10258400_Erin_PROG7311.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet]
        public IActionResult addFarmers()
        {
            var role = HttpContext.Session.GetString("UserRole");
            if(role != "Employee")
            {
                return RedirectToAction("UnAuthorisedAccess", "Home");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addFarmers(addFarmerModel addfarmermodel)
        {

            if (ModelState.IsValid)
            {
               var farmer = new FarmerModel
               {
                    farmerFirstName = addfarmermodel.farmerFirstName,
                    farmerLastName = addfarmermodel.farmerLastName,
                    farmerEmail = addfarmermodel.farmerEmail,
                    farmerLocation = addfarmermodel.farmerLocation,
                    farmerRole = "Farmer"
               };

                var (success, passsword) = await _employeeService.addFarmersAsync(farmer);

                if (success)
                {
                    TempData["SuccessMessage"] = $"Farmer profile added successfully for {farmer.farmerEmail}! Password: {passsword}/n" +
                        $"All farmer details can be viewed on the ALl farmers page";
                    return RedirectToAction("addFarmers");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to add farmer profile. Please try again.");
                }
            }
            else
            {
                return View(addfarmermodel);
            }
            return View(addfarmermodel); // Return the view with the model to show validation errors    
        }

        public IActionResult allProducts()
        {
            return View();
        }
    }
}
