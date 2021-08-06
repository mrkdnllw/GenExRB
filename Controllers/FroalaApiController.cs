using System;
using Microsoft.AspNetCore.Mvc;
using ImageMagick;
using System.IO;
using GenExRB.ViewModels;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Collections;
using GenExRB.Models;
using Newtonsoft.Json;
using System.Web;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace GenExRB.Controllers
{
    public class FroalaApiController : Controller
    {

        private readonly IWebHostEnvironment _hostingEnvironment;

        public FroalaApiController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;

         }

        [HttpPost]
        [Route("/froalasave")]
        public IActionResult FroalaSave(Body1 test1)
        {
          
            try
            {
               
                return Ok(test1.id+" "+test1.content);

              


            }
            catch (Exception e)
            {
                return Json(e);
            }
        }

        [HttpPost]
        [Route("/froalaimgsave")]
        public IActionResult FroalaImgSave() {
            try {

                var httpRequest = HttpContext.Request;
                foreach (var file in httpRequest.Form.Files) {
                    if (file != null)
                    {
                        string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images/sampleimg");
                        string uniqueFileName = null;


                        uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);


                        file.CopyTo(new FileStream(filePath, FileMode.Create));

                    }
                }


                var encoderSettings = new TextEncoderSettings();
                encoderSettings.AllowCharacters('\u0436', '\u0430');
                encoderSettings.AllowRange(UnicodeRanges.BasicLatin);
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(encoderSettings),
                    WriteIndented = true
                };
                var a = new Result1 { link =  "hello.com" };
                var jsonString = System.Text.Json.JsonSerializer.Serialize(a, options);

                return Json("{link = 'hello.com'}");



            } // close try
            catch (Exception e)
            {
                return Json(e);
            }
        
        }

        [HttpPost]
        [Route("/fimgload")]
        public IActionResult ImageLoad() {
            try {
                IList a = new List<Body2>();
                a.Add(new Body2()
                {
                    url = "https://localhost:44333/sampleimg/e0374017-12b8-4547-86df-48b9d35d4105_Screenshot 2021-06-24 180108.png",
                    tag ="pic1",
                    thumb = "https://localhost:44333/sampleimg/e0374017-12b8-4547-86df-48b9d35d4105_Screenshot 2021-06-24 180108.png"

                });
                Body2 temp = new Body2()
                {
                    url = "https://localhost:44333/sampleimg/e0374017-12b8-4547-86df-48b9d35d4105_Screenshot 2021-06-24 180108.png",
                    tag = "pic1",
                    thumb = "https://localhost:44333/sampleimg/e0374017-12b8-4547-86df-48b9d35d4105_Screenshot 2021-06-24 180108.png"

                };
                Body2[] b = new Body2[] { temp

                };

                return Json(a);
            }
            catch(Exception e)
            {
                return Ok(e);
            }
        }
    }
}
