using Microsoft.AspNetCore.Mvc;

namespace AgriConnect_St10258400_Erin_PROG7311.Controllers
{
    public class farmerController : Controller
    {
        public IActionResult addProducts()
        {
            return View();
        }

        public IActionResult productListings()
        {
            return View();
        }
    }
}
