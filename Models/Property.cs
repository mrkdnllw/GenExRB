#nullable enable
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.Models
{
    public class Property
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string? Description { get; set; }
        //[NotMapped]
        public List<Photo>? Photos { get; set; }
        public bool Featured { get; set; }

        public string? FloorArea { get; set; }//for display raman so string

        public string? LotArea { get; set; }//for display
        public string? ReservationFee { get; set; }//for display
    
        public Location? Location { get; set; }// mao ni sha ang address
        public AmenitiesPreference? Amenities { get; set; }// list ni, ang value ani depende sa ui, hard coded nalang ni sha sa ui, lessen stress sa db
        public FeaturesPreference? Features { get; set; }//checklist ni, hard coded sa ui, json string nalang ni sha
        public string? Bedroom { get; set; }//number ni, for informational so string
        public bool ToiletAndBatch { get; set; }//true or false lang 
        public bool CarPark { get; set; }//t or f lang
        //category1, only one should be true, so iset ang uban to false when one is true; refactor ni later
        public Cat1 Category1 { get; set; }
        public bool Preselling { get; set; }
        public bool Preowned { get; set; }
        public bool New { get; set; }

        //category2
        public bool HouseAndLot { get; set; }
        public bool Condo { get; set; }
        public bool Lot { get; set; }
        
        public Decimal? Price { get; set; }

        public bool Buy { get; set; }
        public bool Rent { get; set; }
        //district category
        public string? District { get; set; }


    }

    public enum Cat1 { 
        Preselling,
        Preo,
        New
    }
}
