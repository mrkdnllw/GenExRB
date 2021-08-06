using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.Models
{
    public class MockPropertyRepository : IPropertyRepository
    {
        private readonly List<Property> _propertyList;

        public MockPropertyRepository()
        {
            _propertyList = new List<Property>(){
                new Property(){Id = 1, Name = "Parian", Description="Lorem ipsum..", Featured = false},

                new Property(){Id = 2, Name = "Urgello", Description="Lorem ipsum..", Featured = false},

                new Property(){Id = 3, Name = "Samboan", Description="Lorem ipsum..", Featured = false}

                };
        }// close mockpropertyrepo

        public Property Add(Property property)
        {
            property.Id = _propertyList.Max(e => e.Id) + 1;
            _propertyList.Add(property);
            return property;
        }

        public Property Delete(int id)
        {
            Property property = _propertyList.FirstOrDefault(e => e.Id == id);
            if (property != null)
            {
                _propertyList.Remove(property);

            }
            return property;
        }

        public void DeleteAllPropertyPhotos(int id)
        {
            throw new NotImplementedException();
        }

        public void Detach(Property property)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Property> GetAllProperties()
        {
            return _propertyList;
        }

        public IEnumerable<Property> GetAllPropertiesByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public Property GetProperty(int Id)
        {
            return _propertyList.FirstOrDefault(e => e.Id == Id);
        }

        public Property Update(Property propertyChanges)
        {
            Property property = _propertyList.FirstOrDefault(e => e.Id == propertyChanges.Id);
            if (property != null)
            {
                property.Name = propertyChanges.Name;
                property.Description = propertyChanges.Description;
                property.Featured = propertyChanges.Featured;
               // property.Address = propertyChanges.Address;
               // property.City = propertyChanges.City;

            }

            return property;

        }
    }
}
