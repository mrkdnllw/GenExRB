using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.Models
{
    public class PhotoService
    {
        private readonly AppDbContext context;

        public PhotoService(AppDbContext context)
        {

            this.context = context;
        }


        //get photopath
        public Photo Add(Photo photo)
        {
            context.Photos.Add(photo);
            context.SaveChanges();
            return photo;

        }

        public Photo Update(Photo photoChanges) {
            
            var photo = context.Photos.Attach(photoChanges);
            photo.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return photoChanges;
        }

        public void DeletePhotosOfProperty(int propertyId) {
            //var photo = new Photo() { PropertyId = propertyId };
            //context.Photos.Remove(photo);

            context.Photos.RemoveRange(context.Photos.Where(x => x.PropertyId == propertyId));
            context.SaveChanges();

        }

        public IEnumerable<Photo> GetAllPhotosOfProperty(int propertyId) {
            var photos = context.Photos.Where(x => x.PropertyId == propertyId);

            return photos;
        }

        

        

        //add photopath

        //update photopath

        //delete photopath

        //getall photos


    }
}
