using Data.DataContext;
using Microsoft.EntityFrameworkCore;
using ProLibrary.Models;
using ProLibrary.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProLibrary.Services
{
    public class BookService : IBookService
    {
        private readonly DataContext _dbContext = new();

        public async Task<Book> GetBook(int id) 
        {
            var dbBook = await _dbContext.Books.FindAsync(id);
            return dbBook;
        }
        public async Task<List<Book>> GetBooks()
        {
            var dbBooks = await _dbContext.Books.Include(b => b.AuthorObj).Include(b => b.OfficeObj).ToListAsync();
            return dbBooks;
        }

        public async Task<List<Book>> GetFiltredBooks(string filter)
        {
            filter = filter.ToLower();

            var filtredDbBooks = await _dbContext.Books.Where(
                b => b.Title.ToLower().Contains(filter) ||
                b.AuthorObj.Name.ToLower().Contains(filter)).
                Include(b => b.AuthorObj).Include(b => b.OfficeObj).
                ToListAsync();

            return filtredDbBooks;
        }

        public async Task AddNewBook(Book book) 
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
        }
    }
}
