using HomeTaskTo02._19.Data.Context;
using HomeTaskTo02._19.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeTaskTo02._19.Services
{
    public class BookService : IBookService
    {
        private readonly MainDbContext _db;

        public BookService(MainDbContext bookDbContext)
        {
            _db = bookDbContext;
        }

        public async Task<List<Book>> GetAll()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<Book> Get(int id)
        {
            var existingBook = await _db.Books.FirstOrDefaultAsync(x => x.Id == id);
            return existingBook;
        }

        public async Task<Book> Create(Book book)
        {
            await _db.Books.AddAsync(book);
            await _db.SaveChangesAsync();
            return book;
        }

        public async Task<Book> Update(int id, Book book)
        {
            var existingBook = _db.Books.FirstOrDefault(x => x.Id == id);
            if (existingBook == null) throw new Exception();
            existingBook.Name = book.Name;
            existingBook.Address = book.Address;
            await _db.SaveChangesAsync();
            return existingBook;
        }

        public async Task Remove(int id)
        {
            var existingBook = _db.Books.FirstOrDefault(x => x.Id == id);
            if (existingBook == null) throw new Exception();
            _db.Books.Remove(existingBook);
            await _db.SaveChangesAsync();
        }


    }
}
