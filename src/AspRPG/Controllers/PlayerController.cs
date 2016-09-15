using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspRPG.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using AspRPG.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace AspRPG.Controllers
{
    public class PlayerController : Controller
    {
        private readonly ApplicationDbContext _db;
        private UserManager<ApplicationUser> _userManager;

        public PlayerController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _db = context;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var players = _db.Players.Where(p => p.User.Id == userId);

            return View(players);
        }
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost, Authorize]
        public async Task<IActionResult> Create(Player player)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            player.User = currentUser;
            _db.Players.Add(player);
            _db.SaveChanges();
            return RedirectToAction("Index", "Maps");
        }
    }
}