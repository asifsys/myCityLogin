using Microsoft.AspNetCore.Mvc;

namespace myCityLogin.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
