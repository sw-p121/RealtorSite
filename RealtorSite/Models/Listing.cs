using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealtorSite.Models
{
    public class Listing
    {
        [Key]
        public int Id { get; set; }
        public int Mls { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public string Neighborhood { get; set; }
        public double SalesPrice { get; set; }
        public DateTime DateListed { get; set; }
        public int Bedrooms { get; set; }
        public string Photos { get; set; }
        public int Bathrooms { get; set; }
        public int GarageSize { get; set; }
        public int SquareFeet { get; set; }
        public int LotSize { get; set; }
        public string Description { get; set; }

    }
}
