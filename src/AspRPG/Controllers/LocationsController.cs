using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspRPG.Data;
using AspRPG.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspRPG.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public LocationsController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Create(int id)
        {
            ViewBag.MapId = id;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Location newLocation)
        {
            newLocation.Id = 0;
            _db.Locations.Add(newLocation);
            _db.SaveChanges();
            return RedirectToAction("Details", "Maps", new { id = newLocation.MapId });
        }

    }
}
