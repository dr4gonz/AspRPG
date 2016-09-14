using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspRPG.Data;
using AspRPG.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost]
        public IActionResult CreateRoom(Location location)
        {
            var foundLocation = _db.Locations.FirstOrDefault(l => location.Id == l.Id);
            foundLocation.HasRoom = true;
            _db.SaveChanges();
            return RedirectToAction("Details", "Maps", new { id = foundLocation.MapId });

        }
        public IActionResult Edit(int id)
        {
            var location = _db.Locations.SingleOrDefault(l => l.Id == id);
            return View(location);
        }
        [HttpPost]
        public IActionResult Edit(FormCollection collection)
        {
            var location = _db.Locations.SingleOrDefault(l => l.Id == int.Parse(Request.Form["Id"]));
            if (Request.Form["WestDoor"] == "On")
            {
                location.WestDoor = true;
                var westLocation = _db.Locations
                    .Where(l => l.X == (location.X + 1))
                    .Where(l => l.Y == location.Y)
                    .FirstOrDefault(l => l.MapId == location.MapId);
                _db.Entry(westLocation).State = EntityState.Modified;
                westLocation.HasRoom = true;
                westLocation.EastDoor = true;
                _db.SaveChanges();
            }
            if (Request.Form["EastDoor"] == "On")
            {
                location.EastDoor = true;
                var eastLocation = _db.Locations
                    .Where(l => l.X == (location.X - 1))
                    .Where(l => l.Y == location.Y)
                    .FirstOrDefault(l => l.MapId == location.MapId);
                _db.Entry(eastLocation).State = EntityState.Modified;
                eastLocation.HasRoom = true;
                eastLocation.WestDoor = true;
                _db.SaveChanges();
            }
            if (Request.Form["NorthDoor"] == "On")
            {
                location.NorthDoor = true;
                var northLocation = _db.Locations
                    .Where(l => l.X == location.X)
                    .Where(l => l.Y == (location.Y + 1))
                    .FirstOrDefault(l => l.MapId == location.MapId);
                _db.Entry(northLocation).State = EntityState.Modified;
                northLocation.HasRoom = true;
                northLocation.SouthDoor = true;
                _db.SaveChanges();
            }
            if (Request.Form["SouthDoor"] == "On")
            {
                location.SouthDoor = true;
                var southLocation = _db.Locations
                    .Where(l => l.X == location.X)
                    .Where(l => l.Y == (location.Y -1))
                    .FirstOrDefault(l => l.MapId == location.MapId);
                _db.Entry(southLocation).State = EntityState.Modified;
                southLocation.HasRoom = true;
                southLocation.NorthDoor = true;
                _db.SaveChanges();
            }
            return RedirectToAction("Details", "Maps", new { id = location.MapId });
        }

    }
}
