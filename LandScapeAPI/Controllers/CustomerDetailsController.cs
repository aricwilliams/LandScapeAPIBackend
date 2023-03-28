using Microsoft.AspNetCore.Mvc;

namespace LandScapeAPI.Controllers
{
    public class CustomerDetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
