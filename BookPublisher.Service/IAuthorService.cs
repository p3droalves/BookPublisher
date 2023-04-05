using BookPublisher.Data;
using BookPublisher.Model;

namespace BookPublisher.Service
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author> Get(int id);

        Task<bool> Update(Author author);
        Task<bool> Add(Author author);

        Task<bool> Delete(int id);
    }
}