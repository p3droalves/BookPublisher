using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Model;
using Microsoft.EntityFrameworkCore;

namespace BookPublisher.Data
{
    public class AuthorRepository : IAuthorRepository
    {

        private readonly BookContext _context;

        public AuthorRepository(BookContext context)
        {

            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _context.Author.ToListAsync();
        }

        public async Task<Author> Get(int id)
        {
            var author = await _context.Author.FindAsync(id);
            return author;
        }

        public async Task<bool> Update(Author author)
        {
            var existentAuthor = await _context.Author.FindAsync(author.Id);

            if (existentAuthor is null)
            {
                return false;
            }
            _context.Entry(existentAuthor).State = EntityState.Detached;

            _context.Entry(author).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Add(Author author)
        {
            _context.Author.Add(author);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var author = _context.Author.Find(id);
            _context.Author.Remove(author);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
