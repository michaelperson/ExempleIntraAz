using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExempleIntraAz.Controllers
{
    public class SecureController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Policy ="Best")]
        [HttpGet("/Nous")]
        public IActionResult Nous()
        {
            return View();
        }
    }
}
