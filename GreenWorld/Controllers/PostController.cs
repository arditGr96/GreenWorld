using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using GreenWorld.Data;
using GreenWorld.Models;

namespace GreenWorld.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public PostController(ILogger<PostController> logger, AppDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
            _context = context;
        }



        public async Task<IActionResult> Index()
        {
            var items = await _context.Post.AsNoTracking().ToListAsync();
            return View(items);
        }


        public IActionResult Create()
        {
            ViewBag.Category = _context.Categories.AsNoTracking().ToList();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Post post, IFormFile imageFile)
        {
           
                if (imageFile != null && imageFile.Length > 0)
                {
                    string uploads = Path.Combine(_env.WebRootPath, "uploads");
                    if (!Directory.Exists(uploads))
                        Directory.CreateDirectory(uploads);

                    string fileName = Guid.NewGuid() + Path.GetExtension(imageFile.FileName);
                    string filePath = Path.Combine(uploads, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    post.ImagePath = "/uploads/" + fileName;
                }

                _context.Add(post);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Delete(int id)
        {
            var post = await _context.Post.FindAsync(id);
            if (post == null) return NotFound();
            return View(post);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.Post.FindAsync(id);
            if (post != null)
            {
                _context.Post.Remove(post);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
