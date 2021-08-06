using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.Models.JobModels
{
    public class JobPost
    {
        public int Id { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string Salary { get; set; }
    }
}
