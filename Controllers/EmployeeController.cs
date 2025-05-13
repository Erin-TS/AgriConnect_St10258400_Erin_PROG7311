using AgriConnect_St10258400_Erin_PROG7311.Models;
using AgriConnect_St10258400_Erin_PROG7311.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            if (role != "Employee")
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

                var (success, result) = await _employeeService.addFarmersAsync(farmer);

                if (success)
                {
                    TempData["SuccessMessage"] = $"Farmer profile added successfully for {farmer.farmerEmail}! Password: {result}" +
                        Environment.NewLine +
                        $"All farmer details can be viewed on the all farmers page";
                    return RedirectToAction("addFarmers");
                }
                else if (!success)
                {
                    ModelState.AddModelError(farmer.farmerEmail, result);
                    return View(addfarmermodel);
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

        public async Task<IActionResult> allProducts()
        {
            var productsList = await _employeeService.getProductsListAsync();
            var farmerList = await _employeeService.getallFarmersListAsync();

            var productFilterModel = new ProductFilterModel
            {
                Products = productsList,
                Farmers = farmerList.Select(f => new SelectListItem
                {
                    Value = f.farmerId.ToString(),
                    Text = $"{f.farmerFirstName} {f.farmerLastName}"
                }).ToList()
            };
            return View(productFilterModel);
        }

        [HttpPost]
        public async Task<IActionResult> allProducts(ProductFilterModel filterModel)
        {
            var productsList = await _employeeService.getProductsListAsync();
           

            if (filterModel.Category != null)
            {
                productsList = productsList.Where(p => p.productCategory == filterModel.Category).ToList();
            }

            if (filterModel.StartDate != null && filterModel.EndDate != null)
            {
                productsList = productsList.Where(p => p.productionDate >= filterModel.StartDate && p.productionDate <= filterModel.EndDate).ToList();
            }

            if (filterModel.selectedFarmerId != null)
            {
                productsList = productsList.Where(p => p.farmerId == filterModel.selectedFarmerId).ToList();
            }

            var farmerList = await _employeeService.getallFarmersListAsync();
            filterModel.Farmers = farmerList.Select(f => new SelectListItem
            {
                Value = f.farmerId.ToString(),
                Text = $"{f.farmerFirstName} {f.farmerLastName}"
            }).ToList();
            filterModel.Products = productsList;

            return View("allProducts",filterModel);
        }

        public async Task<IActionResult> FarmerDetails()
        {
            var farmerList = await _employeeService.getallFarmersListAsync();
            return View(farmerList);
        }

    }
}
