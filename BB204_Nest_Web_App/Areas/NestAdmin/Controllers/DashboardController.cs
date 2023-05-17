using Microsoft.AspNetCore.Mvc;

namespace BB204_Nest_Web_App.Areas.NestAdmin.Controllers
{
    [Area("NestAdmin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
