using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenExRB.Models;
using GenExRB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GenExRB.Controllers
{
    public class TestController : Controller
    {
        //[Route("/pikachu2")]
        //[ValidateAntiForgeryToken]
        [HttpGet]
        public IActionResult Index(string sample)
        {
           //ang modelstate validation kay sa kuan ra mahitabo, sa post nga version
           //murag needed jud ang string sample para naay overloading mahitabo
            return View();
        }

        //[Route("/pikachu2")]
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Index(Monster monster)
        {
            if (ModelState.IsValid)
            {

            }
            return View( monster);
        }
    }
}
