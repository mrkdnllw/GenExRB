using System;

namespace GenExRB.Models.Repositories
{
    public class AmenitiesPreferenceService
    {
        private readonly AppDbContext context;

        public AmenitiesPreferenceService(AppDbContext context)
        {

            this.context = context;
        }
        public AmenitiesPreference Add(AmenitiesPreference amenPref)
        {
            context.AmenitiesPreference.Add(amenPref);
            context.SaveChanges();
            return amenPref;

        }

        public AmenitiesPreference Update(AmenitiesPreference amenitiesPreferenceChanges)
        {
            var amenitiesPreference = context.AmenitiesPreference.Attach(amenitiesPreferenceChanges);
            amenitiesPreference.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return amenitiesPreferenceChanges;
        }
    }
}