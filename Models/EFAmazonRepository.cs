using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//this creates the repository and creates the constructor
namespace FakeAmazon.Models
{
    public class EFAmazonRepository : IAmazonRepository
    {
        private FakeAmazonDbContext _context;
        //constructor
        public EFAmazonRepository (FakeAmazonDbContext context)
        {
            _context = context;
        }
        public IQueryable<Project> Projects => _context.Projects;
    }
}
