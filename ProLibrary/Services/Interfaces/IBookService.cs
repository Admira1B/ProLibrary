using ProLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProLibrary.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetBooks();
        Task<Book> GetBook(int id);
        Task<List<Book>> GetFiltredBooks(string filter);
        Task DeleteBook(int id);
        Task AddNewBook(Book book);
    }
}