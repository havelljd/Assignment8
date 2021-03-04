using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeAmazon.Models;

namespace FakeAmazon.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {

        private IAmazonRepository repository;

        public NavigationMenuViewComponent(IAmazonRepository r)
        {
            repository = r;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];


            return View(repository.Projects
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}
