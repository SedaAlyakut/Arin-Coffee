using Buisness.Abstract;
using DataAccess.Concrete.EntityFramwork;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WEBUI.Models;

namespace WEBUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICardService _cardService;
        private readonly IProductService _productService;
        public HomeController(ILogger<HomeController> logger, ICardService cardService, IProductService productService)
        {
            _logger = logger;
            _cardService = cardService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            var val = _cardService.GetList();
                return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Menu()
        {
            var model = _productService.GetList();
            return View(model);
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Shop()
        {
            return View();
        }

        public IActionResult Checkout ()
        {
            return View();
        }

        public IActionResult Faq()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Gallery()
        {
            return View();
        }

        public IActionResult ProductDetails()
        {
            return View();
        }

        public IActionResult Story()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult BlogDetails()
        {
            return View();

        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Wishlist()
        {
            return View();
        }

        public IActionResult MyAccount()
        {
            return View();
        }
    }
}