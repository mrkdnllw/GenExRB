using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
			//modelBuilder.Entity<Property>().HasData(
			//new Property
			//{
			//	Id = 1,
			//	Name = "test1",
			//	Description = "test1",
			//	Featured = true,
			//	//Address = "test1",
			//	//City = Cities.Compostela

			//},

			//new Property
			//{
			//	Id = 2,
			//	Name = "test2",
			//	Description = "test2",
			//	Featured = false,
			//	//Address = "test2",
			//	//City = Cities.Minglanilla

			//});

		}// close void seed
    } // close class
}
