using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GenExRB.Models
{
    public class SQLPropertyRepository : IPropertyRepository
    {

        private readonly AppDbContext context;

        public SQLPropertyRepository(AppDbContext context)
        {

            this.context = context;
        }

        public Property Add(Property property)
        {
            context.Properties.Add(property);
            context.SaveChanges();
            return property;

        }

        public Property Delete(int id)
        {
            Property property = context.Properties.Find(id);
            if (property != null)
            {
                context.Properties.Remove(property);
                context.SaveChanges();

            }
            return property;
        }

        public IEnumerable<Property> GetAllProperties()
        {
            //return context.Properties;
            // return context.Properties.Include(x => x.Photos).Include(y => y.Location).Include(y => y.Amenities); 
            return context.Properties.Include(x => x.Photos).Include(y => y.Amenities);
        }

        public Property GetProperty(int Id)
        {
            // return context.Properties.Include(x => x.Photos).Include(x => x.Location).Include(x => x.Amenities).Include(x => x.Features).FirstOrDefault<Property>(a => a.Id == Id);
            return context.Properties.Include(x => x.Photos).Include(x => x.Amenities).Include(x => x.Features).FirstOrDefault<Property>(a => a.Id == Id);
        }

        public Property Update(Property propertyChanges)
        {

            var property = context.Properties.Attach(propertyChanges);
            property.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return propertyChanges;
        }

        public void Detach(Property property) {
            context.Entry(property).State = EntityState.Detached;
        }


        
        public IEnumerable<Property> GetAllPropertiesByKeyword(string keyword)
        {
            //var properties = context.Properties.Where(a => a.Name.Contains(keyword)).Where(a => a.Description.Contains(keyword)).Where(a => a.Address.Contains(keyword));

            var properties = context.Properties.Where(a => a.Name.Contains(keyword) || a.Description.Contains(keyword));//commented code:  || a.Address.Contains(keyword))

            return properties;
        }

        //buhat og search nga new 

        //public IEnumerable<Property> GetAllPropertiesByX(string keyword) {
            
        //}

        public void DeleteAllPropertyPhotos(int id)
        {
            //throw new NotImplementedException();
            var property = context.Properties.Include(x => x.Photos).Where(a => a.Id == id).FirstOrDefault<Property>();
            
            foreach (var photo in property.Photos) {
                context.Photos.Remove(photo);

            }
            context.SaveChanges();
        }
    }
}
