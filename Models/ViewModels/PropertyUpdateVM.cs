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
    public class PropertyUpdateVM{
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

       
        public string? Description { get; set; }
        //public Photos {get; set;} // list of photo paths ni sha 

        public IFormFileCollection? PropertyPictures { get; set; }
        public List<Photo>? Photos { get; set; }
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

        //public string Amenities { get; set; }// list ni, ang value ani depende sa ui, hard coded nalang ni sha sa ui, lessen stress sa db
        //public string Features { get; set; }//checklist ni, hard coded sa ui, json string nalang ni sha


        [Required]
        [MinLength(1)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "must be numeric")]
        public string? Bedroom { get; set; }//number ni, for informational so string

        [Required]
        public bool ToiletAndBath { get; set; }//true or false lang 

        [Required]
        public bool CarPark { get; set; }//t or f lang
        public int LocationId { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Zip { get; set; }
        [Required]
        public string? StreetAddress { get; set; }
        [Required]
        public string? Brgy { get; set; }

        public List<FeatureData>? FeatureData0 { get; set; }


        public string Category3 { get; set; }
        public string Category1 { get; set; }
        public string Category2 { get; set; }


        public string District { get; set; }

        public List<FeatureOption> FeatureOptions { get; set; }
        //igen ni sa controller?
        //public List<FeatureData> FeatureData { get; set; }


        public string? Long { get; set; }
        public string? Lat { get; set; }

        [Required]
        //[MinLength(1)]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "must be numeric")]

        [RegularExpression(@"[0-9]*\.[0-9]+")]
        [Range(0, 9999999999.999999)]
        public Decimal? Price { get; set; }
    }
}
