using ProLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProLibrary.Services.Interfaces
{
    public interface ILoanOfBookService
    {
        Task AddLoanOfBook(LoanOfBook loanOfBook);
        Task<LoanOfBook> GetLoanOfBook(int id);
        Task<List<LoanOfBook>> GetLoanOfBooks();
        Task<List<LoanOfBook>> GetFiltredLoans(string filter);
        Task RemoveLoanOfBook(int id);
        Task UpdateLoanOfBook(int id, DateTimeOffset dateOfReturning);
    }
}