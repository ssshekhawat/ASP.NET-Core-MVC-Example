using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OAA.Service;
using OAA.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using OAA.Data;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OAA.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        private readonly IAuthorService authorService;

        public BookController(IBookService bookService, IAuthorService authorService)
        {
            this.bookService = bookService;
            this.authorService = authorService;
        }

        public IActionResult Index()
        {
            List<BookListingViewModel> model = new List<BookListingViewModel>();
            model = bookService.GetAllBooks().Select(b =>
            new BookListingViewModel
            {
                Id = b.Id,
                BookName = b.Name,
                Publisher = b.Publisher,
                ISBN = b.ISBN,
                AuthorName = $"{b.Author?.FirstName} {b.Author?.LastName}"
            }).ToList();
            return View("Index", model);
        }

        public PartialViewResult EditBook(long id)
        {
            EditBookViewModel model = new EditBookViewModel();
            model.Authors = authorService.GetAuthors().Select(a => new SelectListItem
            {
                Text = $"{a.FirstName} {a.LastName}",
                Value = a.Id.ToString()
            }).ToList();
            Book book = bookService.GetBook(id);
            if (book != null)
            {
                model.BookName = book.Name;
                model.ISBN = book.ISBN;
                model.Publisher = book.Publisher;
                model.AuthorId = book.AuthorId;
            }
            return PartialView("_EditBook", model);
        }
        [HttpPost]
        public ActionResult EditBook(long id, EditBookViewModel model)
        {
            Book book = bookService.GetBook(id);
            if (book != null)
            {
                book.Name = model.BookName;
                book.ISBN = model.ISBN;
                book.Publisher = model.Publisher;
                book.AuthorId = model.AuthorId;
                book.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                book.ModifiedDate = DateTime.UtcNow;
                bookService.UpdateBook(book);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public PartialViewResult DeleteBook(long id)
        {
            Book book = bookService.GetBook(id);
            return PartialView("_DeleteBook", book?.Name);
        }
        [HttpPost]
        public ActionResult DeleteBook(long id, IFormCollection form)
        {
            Book book = bookService.GetBook(id);
            if (book != null)
            {
                bookService.DeleteBook(book);
            }
            return RedirectToAction("Index");
        }
    }
}
