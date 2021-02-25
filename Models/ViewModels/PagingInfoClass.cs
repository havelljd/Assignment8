using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//this class takes and creates the right amount of pages for my pagination

namespace FakeAmazon.Models.ViewModels
{
    public class PagingInfoClass
    {
        public int TotalNumItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages => (int) (Math.Ceiling((decimal)TotalNumItems / ItemsPerPage));
    }
}
