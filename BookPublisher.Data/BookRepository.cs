using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Model;
using Microsoft.EntityFrameworkCore;

namespace BookPublisher.Data
{
    public class BookRepository : IBookRepository
    {

        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {

            _context = context;




        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _context.Book.ToListAsync();


        }

        public async Task<Book> Get(int id)
        {

            var book = await _context.Book.FindAsync(id);






            return book;



        }

        public async Task<bool> Update(Book book)        
        {

            var existentBook = await _context.Book.FindAsync(book.Id);

            if (existentBook is null)
            {
                return false;
            }
            _context.Entry(existentBook).State = EntityState.Detached;

            _context.Entry(book).State = EntityState.Modified;


            await _context.SaveChangesAsync();

            return true;





        }


        public async Task<bool> Add(Book book)
        {

            _context.Book.Add(book);
            await _context.SaveChangesAsync();

            return true;    



        }

        public async Task<bool> Delete(int id)
        {


            var book = _context.Book.Find(id); 
            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            return true;


        }


    }
}
