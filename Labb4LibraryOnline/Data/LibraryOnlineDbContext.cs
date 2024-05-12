using Microsoft.EntityFrameworkCore;
using Labb4LibraryOnline.Models;

namespace Labb4LibraryOnline.Data
{
    public class LibraryOnlineDbContext : DbContext
    {
        public LibraryOnlineDbContext(DbContextOptions<LibraryOnlineDbContext> options) : base(options) 
        {

        }
        public DbSet <Customer> Customers { get; set; }
        public DbSet <Book> Books { get; set; }
        public DbSet <BookLoan> Loans { get; set; }
    }
}
