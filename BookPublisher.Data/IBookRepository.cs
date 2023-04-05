using BookPublisher.Model;

namespace BookPublisher.Data
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> Get(int id);

        Task<bool> Update(Book book);
        Task<bool> Add(Book book);

        Task<bool> Delete(int id);



    }
}