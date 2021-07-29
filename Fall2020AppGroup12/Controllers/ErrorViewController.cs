using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fall2020AppGroup12.Controllers
{
    public class ErrorViewController : Controller
    {
        public IActionResult ProfileErrorView()
        {
            return View();
        }

        public IActionResult ForumAccessErrorView1()
        {
            return View();
        }

    }
}
