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
        public async Task<IActionResult> addFarmers(FarmerModel farmer)
        {

            if (ModelState.IsValid)
            {
                var (success, farmerPass) = await _employeeService.addFarmersAsync(farmer);
                if (success)
                {
                    TempData["SuccessMessage"] = $"Farmer profile added successfully! Password: {farmerPass}";
                    return RedirectToAction("addFarmers");
                }
                else
                {
                    ModelState.AddModelError("", "Failed to add farmer profile. Please try again.");
                }
            }
            else
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    ModelState.AddModelError("", error.ErrorMessage);

                }
            }
                // If we reach this point, something went wrong, redisplay the form
                return View(farmer);
        }

        public IActionResult allProducts()
        {
            return View();
        }
    }
}
