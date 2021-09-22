using GenExRB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.ViewModels
{
    //dto ni sha, mas flexible, so ang viewmodel kay dto sa model og other data
    public class HomeDetailsViewModel
    {
        public Property Property { get; set; }
        public string PageTitle { get; set; }
    }
}
