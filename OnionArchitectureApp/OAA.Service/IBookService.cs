using OAA.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAA.Service
{
    public interface IBookService
    {
        void AddBook(Book book);
        List<Book> GetAllBooks();
        Book GetBook(long id);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}
