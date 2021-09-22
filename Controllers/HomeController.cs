using GenExRB.Models;
using GenExRB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

//real estate site software ni
namespace GenExRB.Controllers
{
    public class HomeController : Controller
    {
        /*
        LLL
        x iimprove ang search nga naay autocomplete

        HHH
        x review sa relationships
        x designan gamay ang dashboard
        x butangan og search nga basic
        x butangan og google maps nga pin pointer
        x himoong enum ang barangay?
        x iadd nalang ang barangay when it doesn't exist?
        x identify unsa nga font gamiton sa whole site//duha to tulo lang ta sa font para dili samok
        x bootstrap nga search field
        x identify menus bi
        NNN
        x
        L
         */
        

        private readonly IPropertyRepository _propertyRepository;

        public HomeController(IPropertyRepository propertyRepository)
        {

            _propertyRepository = propertyRepository;
        }

        
        public ViewResult Index()
        {

            //return _propertyRepository.GetProperty(3).Name;
            //ang repo mao ni shang service
            var propertiesplusothers = _propertyRepository.GetAllProperties();
            var list = new List<PropertyVM2>();
            
            foreach (var item  in propertiesplusothers) {
                list.Add(new PropertyVM2()
                {
                    Name = item.Name,
                    Description = item.Description,
                    Photos = item.Photos,
                    Price = item.Price,
                    Featured=item.Featured,
                    Category2=item.Category2,
                    
                    District = item.District
                    
                });
            }

            HomeVM model = new HomeVM()
            {
                Properties = list,
                PageTitle = "sample ni"
            };
            //ViewBag.Title = "Index ni, sample page title";
            return View("Index", model);

        }

        public ViewResult Blog()
        {

            return View();

        }

        public ViewResult Careers()
        {

            return View();

        }

        public ViewResult ContactUs()
        {

            return View();

        }

        [HttpGet]
        [Route("/{SearchString}")]
        public ViewResult Index(string SearchString)
        {

            //return _propertyRepository.GetProperty(3).Name;
            //ang repo mao ni shang service
            var model = _propertyRepository.GetAllProperties();
            ViewBag.Title = "Index ni, sample page title";
           // ViewBag.Sample = SearchString;
            Debug.WriteLine(SearchString);
            return View(model);

        }

        public ViewResult Details(int id)
        {
            //Property model = _propertyRepository.GetProperty(3);
            //return Json(model);
            //return View(model);
            //ViewBag.Property = model;
            //ViewBag.PageTitle = "Employee Details";
            //return View(model);


            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Property = _propertyRepository.GetProperty(id),
                PageTitle = "Property Details"
            };

            return View(homeDetailsViewModel);
        }

        [Route("/home/demo1")]
        public ContentResult Demo1()
        {
            return Content("Hello", "text/plain");
        }// close meth

        [HttpGet]
        [Route("/home/district_show/{district}")]
        public ViewResult District_Show(string district)
        {

            /*
            LLL
            HHH
            query ang tanan property nga under sa district nga enum_value

            */
            PropertyDistrictShowViewModel test = new PropertyDistrictShowViewModel();
            //test.N
            test.Message = "default";
            if (district == "1") {
                test.Message = "cebu city ni sha";
            }
            if (district == "2")
            {

                test.Message = "cebu north ni";

            }

            if (district == "3")
            {

                test.Message = "cebu south ni";

            }

            return View("District_Show", test);
        }// close meth 


        [HttpGet]
        [Route("/home/property_type_filter/{indicator}")]
        public ViewResult Property_Type_Filter(int indicator)
        {

            HomePropertyTypesViewModel test = new HomePropertyTypesViewModel();
            //test.N
            test.Message = "default";
            if (indicator == 1)
            {
                test.Message = "houses ni sha";
            }

            if (indicator == 2)
            {
                test.Message = "lot ni sha";
            }

            if (indicator == 3)
            {
                test.Message = "condo ni sha";
            }

            return View("ByPropertyType", test);
        }//close meth

    }// close class
}// close namespace
