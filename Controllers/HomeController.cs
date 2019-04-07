using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(int id)
        {
            return View();
        }


        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
