using ProLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProLibrary.Services.Interfaces
{
    public interface IReaderStatusService
    {
        Task<List<ReaderStatus>> GetStatuses();
    }
}