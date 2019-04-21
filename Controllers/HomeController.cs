using System.Linq;
using CmsLocalization.DB;
using Microsoft.AspNetCore.Mvc;

namespace CmsLocalization.Controllers
{
    public class HomeController : Controller
    {
        private readonly CMS_Context _context;

        public HomeController(CMS_Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contents = _context.Contents.ToList();
            return View(contents);
        }     
    }
}