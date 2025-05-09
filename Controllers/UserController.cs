using Microsoft.AspNetCore.Mvc;

namespace AgriConnect_St10258400_Erin_PROG7311.Controllers
{
    public class UserController : Controller
    {
        public IActionResult login()
        {
            return View();
        }

        public IActionResult register()
        {
            return View();
        }
    }
}
