using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.Models
{
    public class Photo
    {
		public int Id { get; set; }
		public string Title { get; set; }
		public string? PhotoPath { get; set; }



		//Navigation Property
		public  int PropertyId { get; set; }
		public  virtual Property Property { get; set; }
	}
}
