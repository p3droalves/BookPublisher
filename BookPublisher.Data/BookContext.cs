using BookPublisher.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BookPublisher.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions options) : base(options) 
        {
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().HasKey(x => new {x.AuthorId, x.BookId}); 
        }  
        public DbSet<Author> Author { get; set; }
     
        public DbSet<Book> Book { get; set; }

        public DbSet<BookAuthor> BookAuthor { get; set; }   

       
    }
}
    