using System;

namespace GenExRB.Models.Repositories
{
    public class FeaturesPreferenceService
    {
        private readonly AppDbContext context;

        public FeaturesPreferenceService(AppDbContext context)
        {

            this.context = context;
        }
        public FeaturesPreference Add(FeaturesPreference featuresPref)
        {
            context.FeaturesPreference.Add(featuresPref);
            context.SaveChanges();
            return featuresPref;

        }

        public FeaturesPreference Update(FeaturesPreference featuresPreferenceChanges)
        {
            var featuresPreference = context.FeaturesPreference.Attach(featuresPreferenceChanges);
            featuresPreference.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return featuresPreferenceChanges;
        }
    }
}