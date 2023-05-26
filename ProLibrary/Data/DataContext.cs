using Microsoft.EntityFrameworkCore;
using ProLibrary.Models;

namespace Data.DataContext
{
    public class DataContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<LoanOfBook> LoanOfBooks { get; set; }
        public DbSet<PublishigOffice> PublishigOffices { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<ReaderStatus> ReaderStatus { get; set; }

        public string connectionString = "Server = localhost; Port = 5432; User Id = postgres; Password = 5276387ipv546; DataBase = PostgreSQLServer;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}