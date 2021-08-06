using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.Models
{
    public class AmenitiesPreference
    {
        [Key()]
        [ForeignKey("Property")]
        public int Id { get; set; }

        public bool Amenity1 { get; set; }
        public bool Amenity2 { get; set; }
        public bool Amenity3 { get; set; }
        public bool Amenity4 { get; set; }
        public bool Amenity5 { get; set; }

        public int PropertyRef { get; set; }

        //Navigation Property
        //public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
