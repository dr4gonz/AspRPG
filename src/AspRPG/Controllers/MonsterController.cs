using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspRPG.Data;
using Microsoft.AspNetCore.Identity;
using AspRPG.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AspRPG.Controllers
{
    public class MonsterController : Controller
    {
        private readonly ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;

        public MonsterController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _db = context;
        }
        public IActionResult Edit(int id)
        {
            var monster = _db.Monsters.FirstOrDefault(m => m.Id == id);

            return View(monster);
        }
        [HttpPost]
        public IActionResult AddWeapon(Monster monster)
        {
            var newWeapon = new Weapon(int.Parse(Request.Form["MonsterId"]), Request.Form["Description"], int.Parse(Request.Form["DmgMod"]));
            _db.Weapons.Add(newWeapon);
            _db.SaveChanges();
            return RedirectToAction("Edit", "Locations", new { id = int.Parse(Request.Form["LocationId"]) });
        }
    }
}