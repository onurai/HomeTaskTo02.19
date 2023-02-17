using HomeTaskTo02._19.Data.Entities;


namespace HomeTaskTo02._19.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAll();
        Task<Book> Get(int id);
        Task<Book> Create(Book book);
        Task<Book> Update(int id, Book book);
        Task Remove(int id);
    }
}
