using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GenExRB.Models.Repositories;
using GenExRB.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GenExRB.Controllers
{
    public class FeatureOptionController : Controller
    {
        private readonly FeatureOptionService _featureOptionService;
        public FeatureOptionController(FeatureOptionService featureOptionService)
        {
            this._featureOptionService = featureOptionService;
        }
        public IActionResult Index()
        {
            var result = _featureOptionService.GetAllFeatureOption();
            return View(result);
        }



        //CRUD 
        [Route("/addfeatureoption")]
        public IActionResult AddFeatureOption(FormFeature form1)
        {

            //FormFeature[] test = new FormFeature[] { form1 };
            //return Json(JsonSerializer.Serialize(form1));
            var featureOption =_featureOptionService.Add(new Models.CustomData.FeatureOption()
            {
                Key=form1.feature
            });
            form1.featureId = featureOption.Id.ToString();
            
           return Ok(form1);
        }


       
        [Route("/deletefeatureoption")]
        public IActionResult DeleteFeatureOption(FormFeature2 form1)
        {

            //FormFeature[] test = new FormFeature[] { form1 };
            //return Json(JsonSerializer.Serialize(form1));
            _featureOptionService.DeleteFeature(Int32.Parse(form1.featureId));

            //form1.featureId = featureOption.Id.ToString();

            return Ok(form1);
        }

        [Route("updatefeatureoption")]
        public IActionResult UpdateFeatureOption(FormFeature form1)
        {

            //FormFeature[] test = new FormFeature[] { form1 };
            //return Json(JsonSerializer.Serialize(form1));
            //_featureOptionService.DeleteFeature(Int32.Parse(form1.featureId));
            _featureOptionService.Update(new Models.CustomData.FeatureOption() { 
                Id= Int32.Parse(form1.featureId),
                Key=form1.feature
            });
            //form1.featureId = featureOption.Id.ToString();

            return Ok(form1);
        }
    }
}
