using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GenExRB.Controllers
{
    //backend ni
    public class DashboardController : Controller
    {
        [Route("/dashboard")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
