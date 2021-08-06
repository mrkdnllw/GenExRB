using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //this.ChangeTracker.LazyLoadingEnabled = false;

        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Photo> Photos { get; set; }

        public DbSet<Location> Location { get; set; }
        public DbSet<AmenitiesPreference> AmenitiesPreference { get; set; }
        public DbSet<FeaturesPreference> FeaturesPreference { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            //modelBuilder.Seed();

            //one to one rel
            modelBuilder.Entity<Property>()
        .HasOne(a => a.Amenities)
        .WithOne(b => b.Property)
        .HasForeignKey<AmenitiesPreference>(b => b.PropertyRef);

            //one to one rel
            modelBuilder.Entity<Property>()
        .HasOne(a => a.Features)
        .WithOne(b => b.Property)
        .HasForeignKey<FeaturesPreference>(b => b.PropertyRef);

            //one to one rel
            modelBuilder.Entity<Property>()
        .HasOne(a => a.Location)
        .WithOne(b => b.Property)
        .HasForeignKey<Location>(b => b.PropertyRef);



        }

	}// close class
}
