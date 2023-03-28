using Microsoft.AspNetCore.Mvc;

namespace LandScapeAPI.Controllers
{
    public class LabelsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
