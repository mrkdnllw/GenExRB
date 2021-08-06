using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.Models
{
    //pareho ba ang user og author?
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string username { get; set; }
        public string pw { get; set; }

        public IEnumerable<Post> Posts { get; set; }
    }
}
