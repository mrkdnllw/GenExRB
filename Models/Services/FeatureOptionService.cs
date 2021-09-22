using GenExRB.Models.CustomData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenExRB.Models.Repositories
{
    public class FeatureOptionService
    {
        private readonly AppDbContext _context;

        public FeatureOptionService(AppDbContext context)
        {

            this._context = context;
        }
        public FeatureOption Add(FeatureOption featureOption)
        {
            _context.FeatureOptions.Add(featureOption);
            _context.SaveChanges();
            return featureOption;

        }

        public FeatureOption Update(FeatureOption featureOptionChanges)
        {
            var featureOption = _context.FeatureOptions.Attach(featureOptionChanges);
            featureOption.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return featureOptionChanges;
        }

        public IEnumerable<FeatureOption> GetAllFeatureOption()
        {
            return _context.FeatureOptions;
        }


        public void DeleteFeature(int id)
        {
            //throw new NotImplementedException();
            var featureOption = _context.FeatureOptions.Where(a => a.Id == id).FirstOrDefault<FeatureOption>();

            //foreach (var photo in property.Photos)
            //{
                _context.FeatureOptions.Remove(featureOption);

            //}
            _context.SaveChanges();
        }




    }//e class
}// e ns