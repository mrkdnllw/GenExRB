using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GenExRB.Models.Repositories;
using GenExRB.ViewModels;
using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;

namespace GenExRB.Controllers
{
    public class FeaturesDataController : Controller
    {
        //similar ni sa froala api controller


        private readonly FeatureDataService _featureDataService;
        public FeaturesDataController(FeatureDataService featureDataService) {
            this._featureDataService = featureDataService;
        }
        public IActionResult Index()
        {
            var result = _featureDataService.GetAllFeatureData();
            return View(result);
        }



        //CRUD 
        [Route("/addfeature")]
        public IActionResult AddFeature(FormFeature form1) {

            FormFeature[] test = new FormFeature[] { form1};
            //return Json(JsonSerializer.Serialize(form1));
            return Ok(test);
        }
    }
}
