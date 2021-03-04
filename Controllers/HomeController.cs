using FakeAmazon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FakeAmazon.Models.ViewModels;

namespace FakeAmazon.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //creating private property of controller
        private IAmazonRepository _repository;
        //new variable for pagination
        public int ItemsPerPage = 5;
        public HomeController(ILogger<HomeController> logger, IAmazonRepository repository)
        {
            //sets private equals to non private
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index(string category, int page = 1)
        {

            return View(
                new ProjectListViewModel
                {
                    Projects = _repository.Projects
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.BookId)
                    .Skip((page - 1) * ItemsPerPage)
                    .Take(ItemsPerPage),

                    PagingInfo = new PagingInfoClass
                    {
                        CurrentPage = page,
                        ItemsPerPage = ItemsPerPage,
                        TotalNumItems = category == null ? _repository.Projects.Count() : _repository.Projects.Where(x => x.Category == category).Count()
                    },
                    CurrentCategory = category
                }
                ) ;
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
