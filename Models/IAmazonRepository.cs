using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Queries the project list 
namespace FakeAmazon.Models
{
    public interface IAmazonRepository
    {
        IQueryable<Project> Projects { get; }
    }
}
