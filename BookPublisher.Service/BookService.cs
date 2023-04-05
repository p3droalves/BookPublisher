using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookPublisher.Data;
using BookPublisher.Model;
using Microsoft.EntityFrameworkCore;

namespace BookPublisher.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
            
        
        }


        public async Task<IEnumerable<Book>> GetAll()
        {
            return await bookRepository.GetAll();   
        }

        public async Task<Book> Get(int id)
        {
            return await bookRepository.Get(id);    
        }
        public async Task<bool> Update(Book book)
        {
           return await bookRepository.Update(book);
        }


        public async Task<bool> Add(Book book)
        {
            return await bookRepository.Add(book);  
        }

        public async Task<bool> Delete(int id)
        {
            return await bookRepository.Delete(id);   
        }
    }

}


