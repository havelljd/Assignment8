using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FakeAmazon.Infrastructure;
using FakeAmazon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FakeAmazon.Pages
{
    public class AddCartModel : PageModel
    {

        private IAmazonRepository repository;

        //Constructor
        public AddCartModel(IAmazonRepository repo, Cart cartService)
        {
            repository = repo;
            Cart = cartService;
        }

        //Properties
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        //Methods

        //public void OnGet(string returnUrl)
        //{
        //    ReturnUrl = returnUrl ?? "/";
        //    Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        //}

        //public IActionResult OnPost(long bookId, string returnUrl)
        //{
        //    Project project = repository.Projects.FirstOrDefault(p => p.BookId == bookId);
        //    Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

        //    Cart.AddItem(project, 1);

        //    HttpContext.Session.SetJson("cart", Cart);

        //    return RedirectToPage(new { returnUrl = returnUrl });
        //}
        public IActionResult OnPost(long bookId, string returnUrl)
        {
            Project product = repository.Projects
                .FirstOrDefault(p => p.BookId == bookId);
            Cart.AddItem(product, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Book.BookId == bookId).Book);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
