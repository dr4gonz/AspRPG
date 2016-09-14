using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspRPG.Data;
using AspRPG.Models;

namespace AspRPG.Controllers
{
    public class MapsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public MapsController(ApplicationDbContext context)
        {
            _db = context;    
        }

        // GET: Maps
        public async Task<IActionResult> Index()
        {
            return View(await _db.Map.ToListAsync());
        }

        // GET: Maps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var map = await _db.Map
                .Include(m => m.Locations)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (map == null)
            {
                return NotFound();
            }

            return View(map);
        }

        // GET: Maps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Maps/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Map map)
        {
            if (ModelState.IsValid)
            {
                _db.Add(map);
                for (int x = 0; x < 10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        Location location = new Location(map.Id, x, y);
                        _db.Locations.Add(location);
                    }
                }
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(map);
        }

        // GET: Maps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var map = await _db.Map.SingleOrDefaultAsync(m => m.Id == id);
            if (map == null)
            {
                return NotFound();
            }
            return View(map);
        }

        // POST: Maps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Map map)
        {
            if (id != map.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(map);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MapExists(map.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(map);
        }

        // GET: Maps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var map = await _db.Map.SingleOrDefaultAsync(m => m.Id == id);
            if (map == null)
            {
                return NotFound();
            }

            return View(map);
        }

        // POST: Maps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var map = await _db.Map.SingleOrDefaultAsync(m => m.Id == id);
            _db.Map.Remove(map);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MapExists(int id)
        {
            return _db.Map.Any(e => e.Id == id);
        }
    }
}
