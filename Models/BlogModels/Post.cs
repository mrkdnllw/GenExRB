using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.Models
{
    public class Post
    {

        public int Id { get; set; }

        public string Title { get; set; }

        //contains the html
        public string Content { get; set; }

        //Navigation Property
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
