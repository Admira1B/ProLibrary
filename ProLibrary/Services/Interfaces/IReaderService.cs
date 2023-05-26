using ProLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProLibrary.Services.Interfaces
{
    public interface IReaderService
    {
        Task AddReader(Reader reader);
        Task<Reader> GetReader(int id);
        Task<List<Reader>> GetReaders();
        Task<List<Reader>> GetFiltredReaders(string filter);
        Task RemoveReader(int id);
        Task UpdateReader(int id, int statusId);
    }
}