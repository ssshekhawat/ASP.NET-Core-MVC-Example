using Microsoft.EntityFrameworkCore;
using OAA.Data;
using OAA.Repo;
using System.Collections.Generic;
using System.Linq;

namespace OAA.Service
{
    public class BookService : IBookService
    {
        private IRepository<Book> bookRepository;

        public BookService(IRepository<Book> bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public List<Book> GetAllBooks()
        {
            return bookRepository.GetQueryable().Include(b => b.Author).ToList();
        }

        public void AddBook(Book book)
        {
            bookRepository.Insert(book);
        }

        public Book GetBook(long id)
        {
            return bookRepository.Get(id);
        }

        public void UpdateBook(Book book)
        {
            bookRepository.Update(book);
        }

        public void DeleteBook(Book book)
        {
            bookRepository.Delete(book);
        }
    }
}
