#nullable enable
using GenExRB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenExRB.ViewModels
{
    //dto ni sha, mas flexible, so ang viewmodel kay dto sa model og other data
    public class HomeVM
    {
        //ilisan ni sha og property details
        //so pwede jud diay vm within vm, smart
        public IEnumerable<PropertyVM2> Properties { get; set; }
        public string PageTitle { get; set; }

        public string? Message { get; set; }
        public string keyword { get; set; }

        public int CurrentPageIndex { get; set; }

        ///<summary>
        /// Gets or sets PageCount.
        ///</summary>
        public int PageCount { get; set; }

        public string Section { get; set; }
    }
}
