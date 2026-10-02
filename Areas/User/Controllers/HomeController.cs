using Ecommerce.Data;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        ApplicationDBContext context= new ApplicationDBContext();
        public IActionResult Index()
        {
            var categories = context.Categories.Where(c =>c.Status == Enums.Status.Active).ToList();
            return View(categories);
        }
    }
}
