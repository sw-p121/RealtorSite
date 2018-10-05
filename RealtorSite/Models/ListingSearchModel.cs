using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealtorSite.Models
{
    public class ListingSearchModel
    {
        public string City { get; set; }
        public int? Bedrooms { get; set; }
        public int? Bathrooms { get; set; }
        public int? SquareFeetFrom { get; set; }
        public int? SquareFeetTo { get; set; }
    }
}
