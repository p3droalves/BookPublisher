using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Data;
using BookPublisher.Model;

namespace BookPublisher.Service
{
    public class AuthorService : IAuthorService
    {


        private readonly IAuthorRepository authorRepository;
        public AuthorService(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;

        }


        public async Task<IEnumerable<Author>> GetAll()
        {
            return await authorRepository.GetAll();
        }

        public async Task<Author> Get(int id)
        {
            return await authorRepository.Get(id);
        }
        public async Task<bool> Update(Author author)
        {
            return await authorRepository.Update(author);
        }


        public async Task<bool> Add(Author author)
        {
            return await authorRepository.Add(author);
        }

        public async Task<bool> Delete(int id)
        {
            return await authorRepository.Delete(id);
        }
    }
}
