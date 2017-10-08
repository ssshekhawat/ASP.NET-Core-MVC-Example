using Microsoft.EntityFrameworkCore;
using OAA.Data;
using OAA.Repo;
using System.Collections.Generic;
using System.Linq;

namespace OAA.Service
{
    public class AuthorService : IAuthorService
    {
        private IRepository<Author> authorRepository;

        public AuthorService(IRepository<Author> authorRepository)
        {
            this.authorRepository = authorRepository;
        }

        public List<Author> GetAllAuthors()
        {
            return authorRepository.GetQueryable().Include(c => c.Books).ToList();
        }
        public List<Author> GetAuthors()
        {
            return authorRepository.GetAll().ToList();
        }

        public void AddAuthor(Author author)
        {
            authorRepository.Insert(author);
        }

        public Author GetAuthor(long id)
        {
            return authorRepository.Get(id);
        }

        public void UpdateAuthor(Author author)
        {
            authorRepository.Update(author);
        }
    }
}
