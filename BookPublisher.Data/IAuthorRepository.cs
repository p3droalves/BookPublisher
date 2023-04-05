using BookPublisher.Model;

namespace BookPublisher.Data
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author> Get(int id);

        Task<bool> Update(Author author);
        Task<bool> Add(Author author);

        Task<bool> Delete(int id);



    }

}