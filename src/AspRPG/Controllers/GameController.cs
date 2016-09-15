using AspRPG.Data;
using AspRPG.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspRPG.Controllers
{
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;

        public GameController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _db = context;
        }
        public IActionResult Index(int id)
        {
            var player = _db.Players
                .Include(p => p.CurrentRoom).ThenInclude(cr => cr.Monsters)
                .FirstOrDefault(p => p.Id == id);

            return View(player);
        }
        public IActionResult MoveEast(int id)
        {
            MovePlayer(id, 1, 0);
            return RedirectToAction("Index", "Game", new { id = id });
        }
        public IActionResult MoveWest(int id)
        {
            MovePlayer(id, -1, 0);
            return RedirectToAction("Index", "Game", new { id = id });
        }
        public IActionResult MoveNorth(int id)
        {
            MovePlayer(id, 0, -1);
            return RedirectToAction("Index", "Game", new { id = id });
        }
        public IActionResult MoveSouth(int id)
        {
            MovePlayer(id, 0, 1);
            return RedirectToAction("Index", "Game", new { id = id });
        }
        private void MovePlayer(int id, int xMod, int yMod)
        {
            var player = _db.Players.FirstOrDefault(p => p.Id == id);
            var currentRoom = _db.Locations.FirstOrDefault(l => l.Id == player.CurrentRoomId);
            var adjoiningLocation = _db.Locations
                .Where(l => l.X == (currentRoom.X + xMod))
                .Where(l => l.Y == (currentRoom.Y + yMod))
                .FirstOrDefault(l => l.MapId == currentRoom.MapId);
            player.CurrentRoomId = adjoiningLocation.Id;
            _db.Entry(player).State = EntityState.Modified;
            _db.SaveChanges();
        }
        [HttpPost]
        public IActionResult Fight(FormCollection collection)
        {
            var player = _db.Players.FirstOrDefault(p => p.Id == int.Parse(Request.Form["PlayerId"]));
            var monster = _db.Monsters.FirstOrDefault(m => m.Id == int.Parse(Request.Form["MonsterId"]));
            player.Hp -= monster.DmgMod;
            monster.Hp -= player.DmgMod;
            _db.Entry(player).State = EntityState.Modified;
            _db.Entry(monster).State = EntityState.Modified;
            if (monster.Hp < 1)
            {
                _db.Monsters.Remove(monster);
            }
            _db.SaveChanges();
            return RedirectToAction("Index", "Game", new { id = player.Id });
        }
    }
}
