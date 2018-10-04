using Microsoft.EntityFrameworkCore;
using RealtorSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealtorSite.Data
{
    public class RealtorSiteDBContext : DbContext
    {
        public RealtorSiteDBContext(DbContextOptions<RealtorSiteDBContext> options)
    : base(options)
        {
        }
        public DbSet<Listing> Listings { get; set; }
    }
}
