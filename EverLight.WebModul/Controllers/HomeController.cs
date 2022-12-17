using EverLight.WebModul.Models;
using Microsoft.AspNetCore.Mvc;
using EverLight.BusinessLayer;
using EverLight.DTOs;
using System.Diagnostics;

namespace EverLight.WebModul.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BusinessLogic webBusinessLogic;

        public HomeController(ILogger<HomeController> logger, BusinessLogic webBusinessLogic)
        {
            _logger = logger;
            this.webBusinessLogic = webBusinessLogic;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateOrder(int PostCode, string City, string addres)
        {
            var order = new Order()
            {
                PostCode = PostCode,
                City = City,
                Address = addres,
                Opened = DateTime.Now
            };
            ViewData["ordernumber"] = webBusinessLogic.CreateOrder(order);
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