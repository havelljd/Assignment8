using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//this model gets and sets the values necessary to create the database using the code first approach, using a regex for the ISBN number, and makes the BookId the Key, and All fields are required (except middle name, that's allowed to be nullable in my non-atomic database)

namespace FakeAmazon.Models
{
    public class Project
    {
        [Required]
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]

        public string AuthorFirst { get; set; }

        public string AuthorMiddle { get; set; }
        [Required]

        public string AuthorLast { get; set; }
        [Required]

        public string Publisher { get; set; }
        [Required]
        [RegularExpression(@"^(?:ISBN(?:-10)?:?●)?(?=[0-9X]{10}$|(?=(?:[0-9]+[-●]){1})[-●0-9X]{14}$)")]

        public string ISBN { get; set; }
        [Required]

        public string Category { get; set; }
        [Required]

        public string Classification { get; set; }
        [Required]

        public double Price { get; set; }
        [Required]

        public int Pages { get; set; }

    }
}
