using System.Collections.Generic;
using System.Threading.Tasks;
using BookAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Data.Repos
{
   public class BookRepo : IBookRepo
   {
      private readonly BookDbContext _dbContext;
      
      public BookRepo(BookDbContext dbContext)
      {
         _dbContext = dbContext;
      }

      public async Task<IEnumerable<Book>> Get()
      {
         return await _dbContext.Books
            .Include(c => c.Category)
            .ToListAsync();
      }

      public async Task<Book> Get(int id)
      {
         return await _dbContext.Books
            .Include(c => c.Category)
            .FirstOrDefaultAsync(b => b.Id == id);
      }

      public async Task<Book> Create(Book newBook)
      {
         _dbContext.Books.Add(newBook);
         await _dbContext.SaveChangesAsync();

         return newBook;
      }


      public async Task<Book> Update(int bookId, Book dataToUpdate)
      {
         var book = await Get(bookId);

         var entry = _dbContext.Entry(book);

         _dbContext.Entry(book).CurrentValues.SetValues(dataToUpdate);
         
         //block registration date form being changed, as this date should never be changed
         entry.Property(nameof(book.RegistrationTimeStamp)).IsModified = false;
        
         await _dbContext.SaveChangesAsync();
         
         return await Get(book.Id);
      }

      public async Task Delete(int id)
      {
         var bookToDelete = await _dbContext.Books.FindAsync(id);
         _dbContext.Books.Remove(bookToDelete);
         await _dbContext.SaveChangesAsync();

      }

   }
}
