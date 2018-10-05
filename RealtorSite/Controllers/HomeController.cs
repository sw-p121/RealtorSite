using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealtorSite.Data;
using RealtorSite.Models;

namespace RealtorSite.Controllers
{
    public class HomeController : Controller
    {
        private RealtorSiteDBContext _db;
        public HomeController(RealtorSiteDBContext db)
        {
            _db = db;
        }

        //public async Task<IActionResult> Index(string searchString)
        //{
        //    var listings = from l in _db.Listings
        //                   select l;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        listings = listings.Where(s => s.City.Contains(searchString));
        //    }
        //    return View(await listings.ToListAsync());
        //}
        public async Task<IActionResult> Index(ListingSearchModel searchModel)
        {
            var listings = GetListings(searchModel).ToList();
            return View(listings);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Create()
        {
            var listing = new Listing
            {
                DateListed = DateTime.Now
            };
            return View(listing);
        }
        [HttpPost]
        public IActionResult Create(Listing model)
        {
            _db.Listings.Add(model);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listing = await _db.Listings.FindAsync(id);
            if (listing == null)
            {
                return NotFound();
            }
            return View(listing);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Mls,Street1,Street2,City,State,Zipcode,Neighborhood,SalesPrice,DateListed,Bedrooms,Photos,Bathrooms,GarageSize,SquareFeet,LotSize,Description")] Listing listing)
        {
            if (id != listing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(listing);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(listing);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listing = await _db.Listings.FindAsync(id);
            if (listing == null)
            {
                return NotFound();
            }
            return View(listing);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id, Listing listing)
        {
            if (id != listing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Remove(listing);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(listing);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listing = await _db.Listings.FindAsync(id);
            if (listing == null)
            {
                return NotFound();
            }
            return View(listing);
        }


        public IQueryable<Listing> GetListings(ListingSearchModel searchModel)
        {
            var result = _db.Listings.AsQueryable();
            if (searchModel != null)
            {
                if (!string.IsNullOrEmpty(searchModel.City))
                    result = result.Where(x => x.City.Contains(searchModel.City));
                if (searchModel.Bedrooms.HasValue)
                    result = result.Where(x => x.Bedrooms == searchModel.Bedrooms);
                if (searchModel.Bathrooms.HasValue)
                    result = result.Where(x => x.Bathrooms == searchModel.Bathrooms);
                if (searchModel.SquareFeetFrom.HasValue)
                    result = result.Where(x => x.SquareFeet >= searchModel.SquareFeetFrom);
                if (searchModel.SquareFeetTo.HasValue)
                    result = result.Where(x => x.SquareFeet <= searchModel.SquareFeetTo);
            }
            return result;
        }
    }
}
