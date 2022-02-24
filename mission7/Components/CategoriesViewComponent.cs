using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using mission7.Models;

namespace mission7.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IBooksRepository repo { get; set; }

        public CategoriesViewComponent (IBooksRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {

            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var categories = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
