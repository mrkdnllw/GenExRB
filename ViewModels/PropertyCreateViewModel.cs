using GenExRB.Models;
using GenExRB.Models.CustomData;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.ViewModels
{
    public class PropertyCreateViewModel
    {
        [Required]
        public string Name { get; set; }

        
        public string? Description { get; set; }
        //public Photos {get; set;} // list of photo paths ni sha 

        public IFormFileCollection? PropertyPictures { get; set; }
        public bool Featured { get; set; }

        [Required]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "must be numeric")]
        public string? FloorArea { get; set; }//for display raman so string

        [Required]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "must be numeric")]
        public string? LotArea { get; set; }//for display

        [Required]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "must be numeric")]
        public string? ReservationFee { get; set; }//for display

        [Required]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "must be numeric")]
        public string? Bedroom { get; set; }//number ni, for informational so string

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "must be numeric")]
        public bool ToiletAndBath { get; set; }//true or false lang 

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "must be numeric")]
        public bool CarPark { get; set; }//t or f lang

        [Required]
        public string? City { get;  set; }
        [Required]
        public string? Zip { get; set; }
        [Required]
        public string? StreetAddress { get;  set; }
        [Required]
        public string? Brgy { get;  set; }




        //category1, only one should be true, so iset ang uban to false when one is true; refactor ni later

        //category2

        [Required]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "must be numeric")]
        public Decimal? Price { get; set; }

        public Cat2? Category2 { get; set; }
        public Cat3? Category3 { get; set; }
        public Cat1? Category1 { get; set; }
        public List<FeatureOption> FeatureOptions { get; set; }
        //igen ni sa controller?
        public List<FeatureData> FeatureData { get; set; }

    } // close class
} // close ns
