using Data.DataContext;
using Microsoft.EntityFrameworkCore;
using ProLibrary.Models;
using ProLibrary.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProLibrary.Services
{
    public class LoanOfBookService : ILoanOfBookService
    {
        private readonly DataContext _dbContext = new();

        public async Task<LoanOfBook> GetLoanOfBook(int id)
        {
            var dbLoanOfBook = await _dbContext.LoanOfBooks.
                Include(l => l.BookObj).Include(l => l.ReaderObj).SingleOrDefaultAsync(l => l.Id == id);

            return dbLoanOfBook;
        }

        public async Task<List<LoanOfBook>> GetLoanOfBooks()
        {
            var dbLoanOfBooks = await _dbContext.LoanOfBooks.
                Include(l => l.BookObj).Include(l => l.ReaderObj)
                .ToListAsync();

            return dbLoanOfBooks;
        }

        public async Task<List<LoanOfBook>> GetFiltredLoans(string filter)
        {
            filter = filter.ToLower();

            var filtredDbLoans = await _dbContext.LoanOfBooks.Where(
                l => l.Id.ToString().Contains(filter) ||
                l.ReaderObj.FirstName.ToLower().Contains(filter) ||
                l.ReaderObj.LastName.ToLower().Contains(filter)).
                Include(l => l.ReaderObj).Include(l => l.BookObj).
                ToListAsync();

            return filtredDbLoans;
        }

        public async Task AddLoanOfBook(LoanOfBook loanOfBook)
        {
            await _dbContext.LoanOfBooks.AddAsync(loanOfBook);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateLoanOfBook(int id, DateTimeOffset dateOfReturning)
        {
            var dbLoanOfBook = await _dbContext.LoanOfBooks.FindAsync(id);
            string dateString = dateOfReturning.ToString().Substring(0, 10);

            if (dbLoanOfBook != null)
                dbLoanOfBook.ReturningDate = dateString;

            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveLoanOfBook(int id)
        {
            var loanOfBook = await _dbContext.LoanOfBooks.FindAsync(id);
            _dbContext.LoanOfBooks.Remove(loanOfBook);
            await _dbContext.SaveChangesAsync();
        }
    }
}