using Microsoft.AspNetCore.Mvc;

namespace Arpi.Robo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoboController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
