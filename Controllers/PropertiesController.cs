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
using GenExRB.Models.CustomData;
using System.Threading;

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
        

        private readonly FeatureOptionService _featureOptionsService;
        private readonly FeatureDataService _featureDataService;
        private readonly AppDbContext _context;
        private  static IConfiguration config;
        private readonly IWebHostEnvironment hostingEnvironment;

        public PropertiesController(IPropertyRepository propertyRepository, IWebHostEnvironment hostingEnvironment, PhotoService photoService, LocationService locationService, IConfiguration config, FeatureOptionService featureOptionsService,
            AppDbContext context,
            FeatureDataService featureDataService)
        {
            _featureOptionsService = featureOptionsService;
            _propertyRepository = propertyRepository;
            _photoService = photoService;
            _locationService = locationService;
            
            _context = context;
            _featureDataService = featureDataService;
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
            //ang feature options kay options ni sha
            //ang feature data kay association ni sa kada property

            //get all feature options niya ireturn sa model
            List<FeatureOption> featureOptions = _featureOptionsService.GetAllFeatureOption().ToList<FeatureOption>();

            List<FeatureData> fdList = new List<FeatureData>();

            int id = 10;
            foreach (var item in featureOptions) {
                fdList.Add(new FeatureData
                {
                    //Id = id + 1,
                    Key = item.Key,
                    Value1 = false

                });
            }


            return View(new PropertyCreateViewModel()
            {
                FeatureOptions = featureOptions,
                FeatureData0 = fdList
            }); 
        }

        [HttpPost]
        public IActionResult Create(PropertyCreateViewModel model )
        {

            /*
             display data nga pwede fillan 

            get model value para masave, pero get all value pud para mareturn sa model 
             */

            List<FeatureOption> featureOptions = _featureOptionsService.GetAllFeatureOption().ToList<FeatureOption>();

            List<FeatureData> fdList = new List<FeatureData>();

            //int id = 10;
            //foreach (var item in model.FeatureData0)//change ni to feature options? kay tanan man gud
            foreach(var item in featureOptions)
            {
                fdList.Add(new FeatureData
                {
                    //Id = id + 1,
                    Key = item.Key,
                    Value1 = item.Value1 != null? item.Value1 : false//if filled ang key, ibutang ang value, false otherwise if unfilled
                    //so nullable nga bool?


                });
            }

            if (ModelState.IsValid)
            {




                /*return View(new PropertyCreateViewModel()
                {
                    FeatureOptions = featureOptions,
                    FeatureData = fdList
                });*/


                ////////////////////////////////////////////
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
                    Category1 = model.Category1,
                    Category2 = model.Category2,
                    Category3 = model.Category3,
                    FeatureData0 = fdList,
                    Price = model.Price,
                    District = model.District,

                    Lat = model.Lat,
                    Long = model.Long
                    //FeatureData0 = new List<FeatureData>() 

                };


                _propertyRepository.Add(property);



               /* foreach (var item in model.FeatureData)
                {
                    _featureDataService.Add(new FeatureData
                    {
                        Key = item.Key,
                        Value1 = item.Value1,
                        Property = property
                    });
                }*/



                _locationService.Add(new Location()
                {
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    Zip = model.Zip,
                    Brgy = model.Brgy,
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

                        var foo1 = new FileStream(filePath, FileMode.Create);

                        file.CopyTo(foo1);
                        foo1.Close();
                        

                    }// close foreach
                }// close if model.PropertyPictures

                //return RedirectToAction("Index", "Properties");






                //return View("Index", _propertyRepository.GetAllProperties());
                //return RedirectToAction("Index");
                //return RedirectToPage("./dashboard/properties");
                //return RedirectToAction("Properties", "DashboardProperties");
                return RedirectToAction("DashboardProperties", "Properties");
            }

            return View(model);
            // close if model state isvalid



            //return View("Index", _propertyRepository.GetAllProperties());
           
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
        public IActionResult Update(int id){
        //public IActionResult Edit(int id) { 
        
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
                PropertyPictures = null,
                Category3 = property.Category3,
                Price=property.Price,
                Category1 = property.Category1,

                Category2 = property.Category2,
                FeatureData0 = property.FeatureData0,
                Lat = property.Lat,
                Long = property.Long,
                District = property.District
                




            };
            return View(propertyVM);
        }// close meth

        

        [HttpPost]
        public IActionResult Update(PropertyUpdateVM model)
        //public IActionResult Update(PropertyUpdateVM model)
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
                    Category1=model.Category1,
                    Category2 =model.Category2,
                    Category3 = model.Category3,

                    Lat = model.Lat,
                    Long = model.Long,
                    District = model.District,
                    FeatureData0 = model.FeatureData0
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

                return RedirectToAction("DashboardProperties", "Properties");
            }// end if model state is valid



            //return View("Index", _propertyRepository.GetAllProperties());
            //return RedirectToAction("DashboardProperties", "Properties");
            return View(model);


        }// close meth

        [Route("/properties/delete/{id}")]
        public IActionResult Delete(int id) {

            var property = _propertyRepository.GetProperty(id);


            try
            {


                if (property.Photos != null)//C
                {

                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images/properties");


                    int counter = 0;
                    foreach (var photo in property.Photos)// B
                    {
                        counter++;
                        if (photo.PhotoPath != null)
                        { // A

                            string fullPath = Path.Combine(uploadsFolder, photo.Title);

                            FileInfo file = new FileInfo(fullPath);
                            while (IsFileLocked(file))
                            {
                                Thread.Sleep(1000);
                                
                            }
                            file.Delete();




                            /*if (System.IO.File.Exists(fullPath))
                            {
                                System.IO.File.Delete(fullPath);
                                counter++;
                            }*/






                        }// close A

                    }// close B
                    
                    if (counter == property.Photos.Count)
                    {
                        _propertyRepository.Delete(id);


                    }

                    //_propertyRepository.Delete(id);

                    /*
                     * temporary solution kay markan as delete lang ang property niya 
                     * later on ibatch delete lang 
                     */

                }//C
            }
            catch (DirectoryNotFoundException dirNotFound)
            {

                Console.WriteLine(dirNotFound.Message);
            }// end catch





           return RedirectToAction("DashboardProperties", "Properties");









        } // close meth


        [Route("/dashboard/properties/")]
        [HttpGet()]
        public IActionResult DashboardProperties(int id)
        {
            /*
             * LLL
             * HHH
             * kuhaon ang values sa form nga basihan sa sort, get rani sha
             * unsaon pagpasa value?
             * test test
             */



            var properties = _propertyRepository.GetAllProperties();
            ViewBag.Title = "Index ni, sample page title";
            return View(properties);

            //return View("DashboardProperties");
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            //file is not locked
            return false;
        }



    }// end class
}// end ns
