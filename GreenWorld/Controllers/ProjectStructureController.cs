using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using GreenWorld.Data;
using GreenWorld.Models;

namespace GreenWorld.Controllers
{
    public class ProjectStructureController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProjectStructureController(ILogger<PostController> logger, AppDbContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            return View();
        }

    }
}
