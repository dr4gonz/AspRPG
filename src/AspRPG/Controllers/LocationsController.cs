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
        public IActionResult AddDoor(FormCollection collection)
        {
            var location = _db.Locations.SingleOrDefault(l => l.Id == int.Parse(Request.Form["Id"]));
            if (Request.Form["WestDoor"] == "On")
            {
                ChangeDoors(location, -1, 0);

            }
            if (Request.Form["EastDoor"] == "On")
            {
                ChangeDoors(location, 1, 0);

            }
            if (Request.Form["NorthDoor"] == "On")
            {
                ChangeDoors(location, 0, -1);

            }
            if (Request.Form["SouthDoor"] == "On")
            {
                ChangeDoors(location, 0, 1);
            }
            return RedirectToAction("Details", "Maps", new { id = location.MapId });
        }

        private void ChangeDoors(Location location, int xMod, int yMod)
        {
            var adjoiningLocation = _db.Locations
                .Where(l => l.X == (location.X + xMod))
                .Where(l => l.Y == (location.Y + yMod))
                .FirstOrDefault(l => l.MapId == location.MapId);
            adjoiningLocation.HasRoom = true;
            if (xMod == 1)
            {
                adjoiningLocation.WestDoor = true;
                location.EastDoor = true;
            }
            else if (xMod == -1)
            {
                adjoiningLocation.EastDoor = true;
                location.WestDoor = true;
            }
            else if (yMod == 1)
            {
                adjoiningLocation.SouthDoor = true;
                location.NorthDoor = true;
            }
            else if (yMod == -1)
            {
                adjoiningLocation.NorthDoor = true;
                location.SouthDoor = true;
            }
            _db.Entry(adjoiningLocation).State = EntityState.Modified;
            _db.SaveChanges();
        }

    }
}
