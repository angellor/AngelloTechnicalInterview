using Microsoft.EntityFrameworkCore;

namespace BookAPI.Data.Models
{
   public class BookDbContext : DbContext
   {

      public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
      {
         Database.EnsureCreated();
      }

      public DbSet<Book> Books { get; set; }

      public DbSet<BookCategory> Category { get; set; }

   }
}
