using Data.DataContext;
using Microsoft.EntityFrameworkCore;
using ProLibrary.Models;
using ProLibrary.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProLibrary.Services
{
    public class ReaderStatusService : IReaderStatusService
    {
        private readonly DataContext _dbContext = new();

        public async Task<List<ReaderStatus>> GetStatuses()
        {
            var dbGenre = await _dbContext.ReaderStatus.ToListAsync();

            return dbGenre;
        }
    }
}
