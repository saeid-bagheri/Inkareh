using App.Domain.Core.AppServices.Services.Queries;
using App.EndPoints.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace App.EndPoints.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetServiceCategories _getServiceCategories;

        public HomeController(IGetServiceCategories getServiceCategories)
        {
            _getServiceCategories = getServiceCategories;
        }


        public IActionResult Index()
        {
            var result = _getServiceCategories.Execute();
            return View(result);
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