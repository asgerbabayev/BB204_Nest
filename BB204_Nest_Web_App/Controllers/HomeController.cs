using BB204_Nest_Web_App.DAL;
using BB204_Nest_Web_App.Models;
using BB204_Nest_Web_App.ViewModels;
using BB204_Nest_Web_App.ViewModels.SearchVms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BB204_Nest_Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            //HttpContext.Session.SetString("name", "Aysel");
            //Response.Cookies.Append("surname", "Memmedova", new CookieOptions { MaxAge = TimeSpan.FromSeconds(10) });
            HomeVM viewModel = new HomeVM()
            {
                Sliders = await _context.Sliders.ToListAsync(),
                PopularCategories = await _context.Categories.Where(x => x.IsDeleted == false).OrderByDescending(x => x.Products.Count).ToListAsync(),
                RandomCategories = await _context.Categories.Where(x => x.IsDeleted == false).OrderBy(x => Guid.NewGuid()).ToListAsync(),
                TopRatedProducts = await _context.Products.Include(x => x.ProductImages).Where(x => x.IsDeleted == false).OrderByDescending(p => p.Rating).Take(3).ToListAsync(),
                RecentProducts = await _context.Products.Include(x => x.ProductImages).Where(x => x.IsDeleted == false).OrderByDescending(x => x.Id).Take(3).ToListAsync()

            };
            return View(viewModel);
        }

        //public IActionResult Test()
        //{
        //    //var result = HttpContext.Session.GetString("name");
        //    var result = Request.Cookies["surname"];

        //    return Json(result);
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id == null) return NotFound();
            Product? product = await _context.Products.FindAsync(id);
            if (product == null) return BadRequest();
            List<BasketVM> basket = GetBasket();

            UpdateBasket(product.Id, basket);
            return RedirectToAction("Index", "Home");
        }

        private List<BasketVM> GetBasket()
        {
            List<BasketVM> basket;
            if (Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["basket"]);
            }
            else basket = new List<BasketVM>();
            return basket;
        }
        private void UpdateBasket(int id, List<BasketVM> basket)
        {
            BasketVM basketVM = basket.Find(x => x.Id == id);

            if (basket.Any(x => x.Id == id))
            {
                basketVM.Count++;
            }
            else
            {
                basket.Add(new BasketVM
                {
                    Id = id,
                    Count = 1
                });
            }
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
        }

        public IActionResult DeleteBasketItem(int id)
        {
            List<BasketVM> basket = GetBasket();
            BasketVM basketVM = basket.Find(x => x.Id == id);
            basket.Remove(basketVM);
            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));
            return RedirectToAction(nameof(Cart));
        }

        public IActionResult Cart()
        {
            return View();
        }


        public async Task<IActionResult> Search(SearchVM search)
        {
            if (string.IsNullOrEmpty(search.ProductName)) return View();

            var allCategory = await _context.Products
                .Include(x => x.Category)
                .Include(x => x.ProductImages)
                .Where(x => !x.IsDeleted &&
                x.Name.Trim().ToLower().StartsWith(search.ProductName.ToLower().Trim())).ToListAsync();

            var specificCategory = await _context.Products
                .Include(x => x.Category)
                .Include(x => x.ProductImages)
                .Where(x => x.CategoryId == search.CategoryId && !x.IsDeleted &&
                x.Name.Trim().ToLower().StartsWith(search.ProductName.ToLower().Trim())).ToListAsync();

            return View(search.CategoryId == null ? allCategory : specificCategory);
        }
    }
}
