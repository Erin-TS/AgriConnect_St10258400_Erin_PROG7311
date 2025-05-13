using AgriConnect_St10258400_Erin_PROG7311.Models;
using AgriConnect_St10258400_Erin_PROG7311.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgriConnect_St10258400_Erin_PROG7311.Controllers
{
    public class farmerController : Controller
    {
        private readonly IFarmerService _farmerService;

        public farmerController(IFarmerService farmerService)
        {
            _farmerService = farmerService;
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(ProductModel product)
        {
            var farmerEmail = HttpContext.Session.GetString("UserEmail");

            var farmer = await _farmerService.GetFarmerByEmailAsync(farmerEmail);
            if ( farmer== null)
            {
                ModelState.AddModelError("", "Farmer not found. Please try again.");
                return View(product);
            }

            product.farmerId = farmer.farmerId;

            if (ModelState.IsValid)
            {
                var (success, productName) = await _farmerService.addProductAsync(product);
                if (success)
                {
                    TempData["SuccessMessage"] = $"Product({productName}) added successfully!";
                    return RedirectToAction("AddProduct");
                }
                else if (!success)
                {
                    ModelState.AddModelError(product.productName, productName);
                    return View(product);
                }
               
            }
            else
            {
                ModelState.AddModelError("", "Failed to add product. Please try again.");
            }
            return View(product);
        }

     public async Task<IActionResult> productListings()
        {
            var role = HttpContext.Session.GetString("UserRole");
            if (role != "Farmer")
            {
                return RedirectToAction("UnAuthorisedAccess", "Home");
            }
            var farmerEmail = HttpContext.Session.GetString("UserEmail");
            var farmer = await _farmerService.GetFarmerByEmailAsync(farmerEmail);
            if (farmer == null)
            {
                ModelState.AddModelError("", "Farmer not found. Please try again.");
                return View();
            }

            var products = await _farmerService.GetAllProductsByFarmerAsync(farmer.farmerId);
            if (products == null || products.Count == 0)
            {
                ModelState.AddModelError("", "No products found for this farmer.");
                return View();
            }
            return View(products);
        }
    }
}
