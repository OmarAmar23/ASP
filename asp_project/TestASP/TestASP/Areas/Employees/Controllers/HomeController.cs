using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TestASP.Areas.Employees.Controllers
{
    [Area("Employees") , Authorize]

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
