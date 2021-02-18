using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//creates the database context!
namespace FakeAmazon.Models
{
    public class FakeAmazonDbContext : DbContext
    {
        public FakeAmazonDbContext (DbContextOptions<FakeAmazonDbContext> options) : base (options)
        {

        }
        public DbSet<Project> Projects { get; set; }
    }
}
