using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.Models
{
    public class FeaturesPreference
    {
        [Key()]
        [ForeignKey("Property")]
        public int Id { get; set; }

        public bool Feature1 { get; set; }
        public bool Feature2 { get; set; }
        public bool Feature3 { get; set; }
        public bool Feature4 { get; set; }
        public bool Feature5 { get; set; }


        //Navigation Property
        //public int PropertyId { get; set; }
        public int PropertyRef { get; set; }
        public Property Property { get; set; }
    }
}
