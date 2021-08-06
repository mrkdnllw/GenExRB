using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GenExRB.Controllers
{
    public class FroalaTestController : Controller
    {
        [Route("/froala")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
