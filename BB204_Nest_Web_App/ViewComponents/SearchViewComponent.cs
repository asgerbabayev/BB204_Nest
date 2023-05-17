using BB204_Nest_Web_App.DAL;
using BB204_Nest_Web_App.ViewModels.SearchVms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BB204_Nest_Web_App.ViewComponents;

public class SearchViewComponent : ViewComponent
{
    private readonly AppDbContext _context;

    public SearchViewComponent(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        SearchVM vm = new SearchVM();
        vm.Categories = await _context.Categories.Where(x => !x.IsDeleted).ToListAsync();
        return View(vm);
    }
}
