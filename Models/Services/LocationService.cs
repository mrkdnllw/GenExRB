using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.Models.Repositories
{
    public class LocationService
    {
        private readonly AppDbContext context;

        public LocationService(AppDbContext context)
        {

            this.context = context;
        }


        //get photopath
        public Location Add(Location location)
        {
            context.Location.Add(location);
            context.SaveChanges();
            return location;

        }

        public Location Update(Location locationChanges)
        {

            var property = context.Location.Attach(locationChanges);
            property.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return locationChanges;
        }
    }
}
