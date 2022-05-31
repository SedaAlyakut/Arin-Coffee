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
        public HomeController(ILogger<HomeController> logger, ICardService cardService)
        {
            _logger = logger;
            _cardService = cardService;
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
    }
}