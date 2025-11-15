using Microsoft.AspNetCore.Mvc;

namespace GreenWorld.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
