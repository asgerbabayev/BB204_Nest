using BB204_Nest_Web_App.DAL;
using BB204_Nest_Web_App.Models;
using BB204_Nest_Web_App.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BB204_Nest_Web_App.ViewComponents;

public class CommentViewComponent : ViewComponent
{
    private readonly AppDbContext _appDbContext;
    private readonly UserManager<ApplicationUser> _userManager;

    public CommentViewComponent(AppDbContext appDbContext, UserManager<ApplicationUser> userManager)
    {
        _appDbContext = appDbContext;
        _userManager = userManager;
    }

    public async Task<IViewComponentResult> InvokeAsync(int id)
    {
        CommentVM vm = new CommentVM();
        if (User.Identity.IsAuthenticated)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            vm = new CommentVM() { ProductId = id, ApplicationUserId = user.Id };
            return View(vm);
        }
        return View(vm);
    }
}
