using GenExRB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.ViewModels
{
    public class PropertyVM2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Photo>? Photos { get; set; }
        public Decimal? Price { get; set; }
        public bool Featured { get; set; }

        public bool Buy { get; set; }
        public bool Rent { get; set; }
        public string? District { get; set; }

    }
}
