using GreenWorld.Data;
using GreenWorld.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GreenWorld.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public CategoryController(ILogger<CategoryController> logger, AppDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var item = await _context.Categories.AsNoTracking().ToListAsync();
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrUpdate(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Id == 0) 
                {
                    _context.Categories.Add(category);
                }
                else 
                {
                    _context.Categories.Update(category);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View("Create", category); 
        }

      

    }
}
