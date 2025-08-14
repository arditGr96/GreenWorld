using System.Diagnostics;
using GreenWorld.Data;
using GreenWorld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public HomeController(ILogger<PostController> logger, AppDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            var items = await _context.Post.Include(x => x.Category).AsNoTracking().ToListAsync();
            return View(items);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> PostById(int id)
        {
            var item = await _context.Post.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return NotFound();

            return View(item); 
        }

        public async Task<IActionResult> PostByCategoryId(int id)
        {
            var item = await _context.Post.Where(x => x.CategoryId == id)
                .AsNoTracking()
                .ToListAsync();

            if (item == null)
                return NotFound();
            return View(item);
        }
    }
}
