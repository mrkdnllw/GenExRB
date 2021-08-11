#nullable enable
using GenExRB.Models.CustomData;
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
        public string Description { get; set; }
        //[NotMapped]
        public List<Photo>? Photos { get; set; }
        
        //plural ni nga data
        public List<FeatureData>? FeatureData { get; set; }
        public bool Featured { get; set; }

        public string? FloorArea { get; set; }//for display raman so string

        public string? LotArea { get; set; }//for display
        public string? ReservationFee { get; set; }//for display
    
        public Location? Location { get; set; }// mao ni sha ang address
        
        public string? Bedroom { get; set; }//number ni, for informational so string
        public bool ToiletAndBath { get; set; }//true or false lang 
        public bool CarPark { get; set; }//t or f lang
        //category1, only one should be true, so iset ang uban to false when one is true; refactor ni later
        /* cat1
          Preselling,
        Preo,
        New
         */
        public Cat1? Category1 { get; set; }


        /* cat2
          HouseAndLot,
        Condo,
        Lot
         */


        public Cat2? Category2 { get; set; }
        
        public Decimal? Price { get; set; }

        /* cat3
         Buy,
        Rent
         
         */
        public Cat3? Category3 { get; set; }

        //district category
        /*
         * North,
        South, 
        CC,
        Mandaue,
        Lapulapu
         
         */
        public District? District { get; set; }
        
        //gamiton ni para sa map data
        public string? Long { get; set; }
        public string? Lat { get; set; }
        
    }

    public enum Cat1 { 
        Preselling,
        Preo,
        New
    }
    public enum Cat2
    {
        HouseAndLot,
        Condo,
        Lot
    }

    public enum Cat3
    {
        Buy,
        Rent
    }

    public enum District
    {
        North,
        South, 
        CC,
        Mandaue,
        Lapulapu
    }
}
