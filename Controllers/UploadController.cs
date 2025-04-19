using Microsoft.AspNetCore.Mvc;

namespace FastTracker.Controllers
{
    public class UploadController : Controller
    {
        [HttpPost]
        public IActionResult Data()
        {
            return View();
        }
    }
}
