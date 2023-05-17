using BB204_Nest_Web_App.DAL;
using BB204_Nest_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BB204_Nest_Web_App.Areas.NestAdmin.Controllers;
[Area("NestAdmin")]
public class TagsController : Controller
{
    private readonly AppDbContext _context;

    public TagsController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Tags.ToListAsync());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Tag tag)
    {
        if (!ModelState.IsValid) return View();
        await _context.Tags.AddAsync(tag);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
