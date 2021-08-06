#nullable enable
using GenExRB.Models;
using GenExRB.Models.Repositories;
using GenExRB.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace GenExRB.Controllers
{
    public class PropertiesController : Controller
    {
        /*
         * LLL
         * 
         * HHH
         */

        private readonly IPropertyRepository _propertyRepository;
        private readonly PhotoService _photoService;
        private readonly LocationService _locationService;
        private readonly AmenitiesPreferenceService _amenitiesPreferenceService;
        private readonly FeaturesPreferenceService _featuresPreferenceService;
        private  static IConfiguration config;
        private readonly IWebHostEnvironment hostingEnvironment;

        public PropertiesController(IPropertyRepository propertyRepository, IWebHostEnvironment hostingEnvironment, PhotoService photoService, LocationService locationService, AmenitiesPreferenceService amenitiesPreferenceService,
            FeaturesPreferenceService featuresPreferenceService, IConfiguration config)
        {

            _propertyRepository = propertyRepository;
            _photoService = photoService;
            _locationService = locationService;
            _amenitiesPreferenceService = amenitiesPreferenceService;
            _featuresPreferenceService = featuresPreferenceService;
            PropertiesController.config = config;
            this.hostingEnvironment = hostingEnvironment;
        }

        public static string GetTableSpaceUsed(string tableName)
        {
            string strCount;
            SqlConnection Conn = new SqlConnection
               (PropertiesController.config.GetConnectionString("PropertyDBConnection"));
            SqlCommand testCMD = new SqlCommand
               ("sp_spaceused", Conn);

            testCMD.CommandType = CommandType.StoredProcedure;

            Conn.Open();

            SqlDataReader reader = testCMD.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Console.WriteLine("Name: " + reader["database_name"]);
                    Console.WriteLine("Size: " + reader["database_size"]);
                    return "Size: " + reader["database_size"];
                }
            }
            return "default result";
            Console.ReadLine();
        } //close static method

        [Route("/properties")]
        public  ViewResult Index()
        {


            var properties = _propertyRepository.GetAllProperties();
            ViewBag.Title = "Index ni, sample page title";
            return View(properties);
            

        }

        public ViewResult Index2()
        {


            var properties = _propertyRepository.GetAllProperties();
            ViewBag.Title = "Index ni, sample page title";
            return View(properties);


        }

        public ViewResult SellProperties()
        {

            return View();


        }

        public ViewResult InteriorDesign()
        {

            return View();


        }

        public ViewResult Contractors()
        {

            return View();


        }



        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PropertyCreateViewModel model )
        {

            if (ModelState.IsValid)
            {
                /*
                 * LLL
                 * HHH
                 */

                Property property = new Property()
                {

                    Name = model.Name,
                    Description = model.Description,

                    Featured = model.Featured,

                    FloorArea = model.FloorArea,

                    LotArea = model.LotArea,
                    ReservationFee = model.ReservationFee,
                    Bedroom = model.Bedroom,
                    CarPark = model.CarPark,
                    ToiletAndBath = model.ToiletAndBath,
                    Category1 = model.Category1

                };

                
                _propertyRepository.Add(property);

                

                _locationService.Add(new Location()
                {
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    Zip = model.Zip,
                    Brgy = model.Brgy,
                    Property = property

                });

                _amenitiesPreferenceService.Add(new AmenitiesPreference() { 
                    Amenity1 = model.Amenity1,
                    Amenity2 = model.Amenity2,
                    Amenity3 = model.Amenity3,
                    Amenity4 = model.Amenity4,
                    Amenity5 = model.Amenity5,
                    Property = property
                 
                });

                _featuresPreferenceService.Add(new FeaturesPreference()
                {
                    Feature1 = model.Feature1,
                    Feature2 = model.Feature2,
                    Feature3 = model.Feature3,
                    Feature4 = model.Feature4,
                    Feature5 = model.Feature5,
                    Property = property

                });



                if (model.PropertyPictures != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images/properties");
                    string uniqueFileName = null;

                    foreach (var file in model.PropertyPictures)
                    {

                        uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        //photos.Add(filePath); //ad ni after mabuhat ang object

                        //context.Photos.Add);
                    _photoService.Add(new Photo()
                    { //or PhotoService.Add.. same parameter
                        Title = uniqueFileName,
                        PhotoPath = filePath,
                        Property = property
                        });

                    file.CopyTo(new FileStream(filePath, FileMode.Create));

                }// close foreach
            }// close if model.PropertyPictures

                //return RedirectToAction("Index", "Properties");
            }// close if model state isvalid



            return View("Index", _propertyRepository.GetAllProperties());
        }// close http create


       

        [HttpGet]
        public IActionResult Search2(string keyword)
        {
            /*
             * LL
             * 
             * HH
             */
            var model = new SampleVM()
            {
                Property = new Property(),
                Message = "db space used is" + PropertiesController.GetTableSpaceUsed("FeaturesPreference")
            };
            
            return View(model);
        }// close meth



        private HomeVM GetProperties(int currentPage, Form1? form1) {
            var propertiesplusothers = _propertyRepository.GetAllPropertiesByKeyword(form1.keyword);
            //var propertiesplusothers = _propertyRepository.GetAllProperties();

            var list = new List<PropertyVM2>();

            foreach (var item in propertiesplusothers)
            {
                list.Add(new PropertyVM2()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Photos = item.Photos,
                    Price = item.Price,
                    Featured = item.Featured,
                    Category3 = item.Category3, //buy/rent ni nga category
                    District = item.District

                });
            }
            int maxRows = 1;
            HomeVM model = new HomeVM()
            {
                Properties = list
                        .OrderBy(property => property.Id)
                        .Skip((currentPage - 1) * maxRows)
                        .Take(maxRows),
                PageTitle = "sample ni",
                Message = form1 != null ? form1.min : "",
                Section = "section1"
            };


            double pageCount = (double)((decimal)propertiesplusothers.Count() / Convert.ToDecimal(maxRows));
            model.PageCount = (int)Math.Ceiling(pageCount);

            model.CurrentPageIndex = currentPage;
            model.keyword = form1.keyword;
            return model;
        }


        private HomeVM GetProperties(int currentPage, string keyword)
        {
            var propertiesplusothers = _propertyRepository.GetAllPropertiesByKeyword(keyword);
            //var propertiesplusothers = _propertyRepository.GetAllProperties();

            var list = new List<PropertyVM2>();

            foreach (var item in propertiesplusothers)
            {
                list.Add(new PropertyVM2()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Photos = item.Photos,
                    Price = item.Price,
                    Featured = item.Featured,
                    Category3 = item.Category3,
                    District = item.District

                });
            }
            int maxRows = 1;
            HomeVM model = new HomeVM()
            {
                Properties = list
                        .OrderBy(property => property.Id)
                        .Skip((currentPage - 1) * maxRows)
                        .Take(maxRows),
                PageTitle = "sample ni",
                Section="section1"
                
            };


            double pageCount = (double)((decimal)propertiesplusothers.Count() / Convert.ToDecimal(maxRows));
            model.PageCount = (int)Math.Ceiling(pageCount);

            model.CurrentPageIndex = currentPage;
            model.keyword = keyword;
            return model;
            
        }


        [HttpGet]
        public IActionResult Search([FromQuery] Form1 form1) {
            
            return View(this.GetProperties(1, form1));
        }

        [HttpPost]
        public IActionResult Search(int currentPageIndex, string keyword)
        {

            return View(this.GetProperties(currentPageIndex, keyword));
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            /*
             * LL
             * 
             * HH
             * 
             */
            //ViewData["message"] = id;
            var property = _propertyRepository.GetProperty(id);

            PropertyUpdateVM propertyVM = new PropertyUpdateVM()
            {
                Id = property.Id,
                Name = property.Name,
                Description = property.Description,
                Photos = property.Photos,
                Featured = property.Featured,
                FloorArea = property.FloorArea,
                LotArea = property.LotArea,
                ReservationFee = property.ReservationFee,
                Bedroom = property.Bedroom,
                ToiletAndBath = property.ToiletAndBath,
                CarPark = property.CarPark,
                LocationId=property.Location.Id,
                City = property.Location.City,
                Zip = property.Location.Zip,
                StreetAddress = property.Location.StreetAddress, //aka street name
                Brgy = property.Location.Brgy,
                AmenPrefId= property.Amenities.Id,
                Amenity1 = property.Amenities.Amenity1,//was with [0]
                Amenity2 = property.Amenities.Amenity2,
                Amenity3 = property.Amenities.Amenity3,
                Amenity4 = property.Amenities.Amenity4,
                Amenity5 = property.Amenities.Amenity5,

                FeaturesPrefId = property.Features.Id,
                Feature1 = property.Features.Feature1,
                Feature2 = property.Features.Feature2,
                Feature3 = property.Features.Feature3,
                Feature4 = property.Features.Feature4,
                Feature5 = property.Features.Feature5,
                PropertyPictures = null,
                Category3 = property.Category3,
                Price=property.Price,
                Category1 = property.Category1




            };
            return View(propertyVM);
        }// close meth

        

        [HttpPost]
        public IActionResult Update(PropertyUpdateVM model)
        {
            /*
             * LL
             * 
             * HH
             * 
             */


            if (ModelState.IsValid)
            {
                var property = new Property()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,

                    Featured = model.Featured,

                    FloorArea = model.FloorArea,

                    LotArea = model.LotArea,
                    ReservationFee = model.ReservationFee,
                    Bedroom = model.Bedroom,
                    CarPark = model.CarPark,
                    ToiletAndBath = model.ToiletAndBath,
                    
                    Price=model.Price,
                    Category1=model.Category1
                };

                _propertyRepository.Update(property);

                _locationService.Update(new Location()
                {

                    Id = model.LocationId,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    Zip = model.Zip,
                    Brgy = model.Brgy,
                    Property = property
                });// end location

                _amenitiesPreferenceService.Update(new AmenitiesPreference()
                {
                    Id = model.AmenPrefId,
                    Amenity1 = model.Amenity1,
                    Amenity2 = model.Amenity2,
                    Amenity3 = model.Amenity3,
                    Amenity4 = model.Amenity4,
                    Amenity5 = model.Amenity5,
                    Property = property

                });

                _featuresPreferenceService.Update(new FeaturesPreference()
                {
                    Id = model.FeaturesPrefId,
                    Feature1 = model.Feature1,
                    Feature2 = model.Feature2,
                    Feature3 = model.Feature3,
                    Feature4 = model.Feature4,
                    Feature5 = model.Feature5,
                    Property = property

                });

                if (model.PropertyPictures != null)
                {
                    /**
                     * LL
                     * HHH
                     * delete all child sa model.Id
                     */
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images/properties");
                    string uniqueFileName = null;

                    //delete existing photo

                    //var photos = _photoService.GetAllPhotosOfProperty(model.Id);

                    //foreach (var photo in photos) {
                    //    uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                    //    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    //    new FileStream(filePath, FileMode.D)
                    //}
                    _propertyRepository.DeleteAllPropertyPhotos(model.Id);
                   

                    

                    foreach (var file in model.PropertyPictures)
                    {

                        uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        //photos.Add(filePath); //ad ni after mabuhat ang object

                        //context.Photos.Add);
                        
                        _photoService.Add(new Photo()
                        { //or PhotoService.Add.. same parameter
                            //Id = model.
                            Title = uniqueFileName,
                            PhotoPath = filePath,
                            Property = property
                        });

                        file.CopyTo(new FileStream(filePath, FileMode.Create));

                    }// close foreach
                }// close if model.PropertyPictures



                //RedirectToAction("Index", "Properties");
            }// end if model state is valid



            return View("Index", _propertyRepository.GetAllProperties());




        }// close meth

        [Route("/properties/delete/{id}")]
        public IActionResult Delete(int id) {

            _propertyRepository.Delete(id);

            return View("Index", _propertyRepository.GetAllProperties());
        } // close meth


    }// end class
}// end ns
