using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.Models
{
	public class Location
	{
		[Key()]
		[ForeignKey("Property")]
		public int Id { get; set; }
		public string? StreetAddress { get; set; }

		public string? City { get; set; }
		public string? Zip { get; set; }// gabase sa city
		public string? Brgy { get; set; }//static nalang ni para simple
										 //District will be collection of cities lang, sa front end nani or sa controller

		//Navigation Property
		//public  int PropertyId { get; set; }
		public int PropertyRef { get; set; }
		public  virtual Property Property { get; set; }
	}
}
