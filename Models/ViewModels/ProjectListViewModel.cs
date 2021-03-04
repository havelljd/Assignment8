using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeAmazon.Models.ViewModels
{
    public class ProjectListViewModel
    {
        public IEnumerable<Project> Projects { get; set; }

        public PagingInfoClass PagingInfo { get; set; }

        //additional attribute to help get the category I want
        public string CurrentCategory { get; set; }
    }
}
