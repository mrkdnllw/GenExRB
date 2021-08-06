using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.Models
{
    public interface IPropertyRepository
    {
        Property GetProperty(int Id);

        Property Add(Property property);

        Property Update(Property propertyChanges);

        Property Delete(int id);
        IEnumerable<Property> GetAllProperties();
        IEnumerable<Property> GetAllPropertiesByKeyword(string keyword);
        void Detach(Property property);
        void DeleteAllPropertyPhotos(int id);
    }
}
