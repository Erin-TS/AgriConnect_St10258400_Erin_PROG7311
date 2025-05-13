using AgriConnect_St10258400_Erin_PROG7311.Models;
using AgriConnect_St10258400_Erin_PROG7311.Services;
using Microsoft.AspNetCore.Mvc;

namespace AgriConnect_St10258400_Erin_PROG7311.Controllers
{
    public class farmerController : Controller
    {
        private readonly IFarmerService _farmerService;

        public IActionResult addProducts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult addProduct()
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
        public async Task<IActionResult> addProduct(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var (success, productName) = await _farmerService.addProductAsync(product);
                if (success)
                {
                    TempData["SuccessMessage"] = $"Product({productName}) added successfully!";
                    return RedirectToAction("addProducts");
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

        public IActionResult productListings()
        {
            return View();
        }
    }
}
