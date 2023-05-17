using BB204_Nest_Web_App.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BB204_Nest_Web_App.ViewComponents;

public class ProductViewComponent : ViewComponent
{
    private readonly AppDbContext _context;

    public ProductViewComponent(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync(int take)
    {
        return View(await _context.Products.
            Include(x => x.Category).
            Include(x => x.ProductImages).Take(take).ToListAsync());
    }
}
