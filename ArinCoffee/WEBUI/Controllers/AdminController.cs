using Buisness.Abstract;
using Entities.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WEBUI.Entities;

namespace WEBUI.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        private UserManager<CustomIdentityUser> _userManager;
        private readonly IWebHostEnvironment _env2;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public AdminController
            (UserManager<CustomIdentityUser> userManager, IWebHostEnvironment env2, IProductService productService, IOrderService orderService)
        {           
            _userManager = userManager;
            _env2 = env2;
            _productService = productService;
            _orderService = orderService;
        }


        public async Task<IActionResult> Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.products = _productService.GetList();
            model.orders = _orderService.GetList();
            return View(model);
        }

    }
}
