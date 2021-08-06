using GenExRB.Models;
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

        [StringLength(5, ErrorMessage = "Name length can't be more than 8.")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string? Description { get; set; }
        //public Photos {get; set;} // list of photo paths ni sha 

        public IFormFileCollection? PropertyPictures { get; set; }
        public List<Photo>? Photos { get; set; }
        public bool Featured { get; set; }

        public string? FloorArea { get; set; }//for display raman so string

        public string? LotArea { get; set; }//for display
        public string? ReservationFee { get; set; }//for display

        //public string Amenities { get; set; }// list ni, ang value ani depende sa ui, hard coded nalang ni sha sa ui, lessen stress sa db
        //public string Features { get; set; }//checklist ni, hard coded sa ui, json string nalang ni sha
        public string? Bedroom { get; set; }//number ni, for informational so string
        public bool ToiletAndBath { get; set; }//true or false lang 
        public bool CarPark { get; set; }//t or f lang
        public int LocationId { get; set; }
        public string? City { get; set; }
        public string? Zip { get; set; }
        public string? StreetAddress { get; set; }
        public string? Brgy { get; set; }

        public int AmenPrefId { get; set; }
        //AmenPref
        public bool Amenity1 { get; set; }
        public bool Amenity2 { get; set; }
        public bool Amenity3 { get; set; }
        public bool Amenity4 { get; set; }
        public bool Amenity5 { get; set; }


        public int FeaturesPrefId { get; set; }

        //FeaturesPref
        public bool Feature1 { get; set; }
        public bool Feature2 { get; set; }
        public bool Feature3 { get; set; }
        public bool Feature4 { get; set; }
        public bool Feature5 { get; set; }



        //category1, only one should be true, so iset ang uban to false when one is true; refactor ni later
        public bool Preselling { get; set; }
        public bool Preowned { get; set; }
        public bool New { get; set; }

        //category2

        public Decimal? Price { get; set; }


       // public bool Buy { get; set; }
        //public bool Rent { get; set; }

        public Cat3? Category3 { get; set; }
        public Cat1? Category1 { get; set; }
        public Cat2? Category2 { get; set; }


    }
}
