using OAA.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OAA.Service
{
    public interface IAuthorService
    {
        List<Author> GetAllAuthors();
        void AddAuthor(Author author);
        Author GetAuthor(long id);
        void UpdateAuthor(Author author);
        List<Author> GetAuthors();
    }
}
