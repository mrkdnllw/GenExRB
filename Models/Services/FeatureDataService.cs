using GenExRB.Models.CustomData;
using System;
using System.Collections.Generic;

namespace GenExRB.Models.Repositories
{
    public class FeatureDataService
    {
        private readonly AppDbContext _context;

        public FeatureDataService(AppDbContext context)
        {

            this._context = context;
        }
        public FeatureData Add(FeatureData featureData)
        {
            _context.FeatureData.Add(featureData);
            _context.SaveChanges();
            return featureData;

        }

        public FeatureData Update(FeatureData featureDataChanges)
        {
            var featureData = _context.FeatureData.Attach(featureDataChanges);
            featureData.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return featureDataChanges;
        }

        public IEnumerable<FeatureData> GetAllFeatureData()
        {
            return _context.FeatureData;
        }      



    }
}