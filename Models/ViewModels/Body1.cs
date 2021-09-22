using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.ViewModels
{
    public class Body1
    {
        public string content { get; set; }
        public string id { get; set; }
        public IFormFile img { get; set; }
    }
}
