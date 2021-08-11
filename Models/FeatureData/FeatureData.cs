using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.Models.CustomData
{
    public class FeatureData
    {
        public int Id { get; set; }
        public string Key { get; set; }//checkbox ni niya ang value kay basi sa key options
        //pwede ba array of something?
        // ay one to many
       
        public bool Value1{ get; set; }
        //one to many sha
        //Navigation Property
        public int PropertyId { get; set; }
        public virtual Property Property { get; set; }
    }
}
