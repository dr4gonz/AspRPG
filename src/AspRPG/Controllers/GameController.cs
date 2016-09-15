using AspRPG.Data;
using AspRPG.Models;
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
                .Include(p => p.CurrentRoom)
                .FirstOrDefault(p => p.Id == id);

            return View(player);
        }
        public IActionResult MoveEast(Player player)
        {
            MovePlayer(player, 1, 0);
            return RedirectToAction("Index", "Game", new { id = player.Id });
        }
        public IActionResult MoveWest(Player player)
        {
            MovePlayer(player, -1, 0);
            return RedirectToAction("Index", "Game", new { id = player.Id });
        }
        public IActionResult MoveNorth(Player player)
        {
            MovePlayer(player, 0, -1);
            return RedirectToAction("Index", "Game", new { id = player.Id });
        }
        public IActionResult MoveSouth(Player player)
        {
            MovePlayer(player, 0, 1);
            return RedirectToAction("Index", "Game", new { id = player.Id });
        }
        private void MovePlayer(Player player, int xMod, int yMod)
        {
            var currentRoom = _db.Locations.FirstOrDefault(l => l.Id == player.CurrentRoomId);
            var adjoiningLocation = _db.Locations
                .Where(l => l.X == (currentRoom.X + xMod))
                .Where(l => l.Y == (currentRoom.Y + yMod))
                .FirstOrDefault(l => l.MapId == currentRoom.MapId);
            player.CurrentRoomId = adjoiningLocation.Id;
            _db.Entry(player).State = EntityState.Modified;
            _db.SaveChanges();
        }
    }
}
