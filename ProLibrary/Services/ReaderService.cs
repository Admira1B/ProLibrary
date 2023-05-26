using Data.DataContext;
using Microsoft.EntityFrameworkCore;
using ProLibrary.Models;
using ProLibrary.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProLibrary.Services
{
    public class ReaderService : IReaderService
    {
        private readonly DataContext _dbContext = new();

        public async Task<Reader> GetReader(int id)
        {
            var dbReader = await _dbContext.Readers.Include(r => r.StatusObj).Where(r => r.LibraryCardNumber == id).SingleOrDefaultAsync();

            if (dbReader is null) 
            {
                return null; 
            }

            return dbReader;
        }

        public async Task<List<Reader>> GetReaders()
        {
            var dbReaders = await _dbContext.Readers.Include(r => r.StatusObj).ToListAsync();
            return dbReaders;
        }

        public async Task<List<Reader>> GetFiltredReaders(string filter)
        {
            filter = filter.ToLower();

            var filtredDbReaders = await _dbContext.Readers.Include(r => r.StatusObj).Where(
                r => r.LibraryCardNumber.ToString().Contains(filter) ||
                r.FirstName.ToLower().Contains(filter) ||
                r.LastName.ToLower().Contains(filter)).
                ToListAsync();

            return filtredDbReaders;
        }

        public async Task AddReader(Reader reader)
        {
            await _dbContext.Readers.AddAsync(reader);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateReader(int id, int statusId)
        {
            var dbReader = await GetReader(id);

            if (dbReader != null)
                dbReader.ReaderStatusId = statusId;

            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveReader(int id)
        {
            var reader = await GetReader(id);
            _dbContext.Readers.Remove(reader);
            await _dbContext.SaveChangesAsync();
        }
    }
}