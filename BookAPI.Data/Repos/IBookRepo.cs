using System.Collections.Generic;
using System.Threading.Tasks;
using BookAPI.Data.Models;

namespace BookAPI.Data.Repos
{

   /// <summary>
   /// List of operations that can be performed against the database.
   /// </summary>
   /// 
   public interface IBookRepo
   {
      /// <summary>
      /// Returns all books in a list
      /// </summary>
      /// <returns>A list of all the books</returns>
      Task<IEnumerable<Book>> Get();

      /// <summary>
      /// Get one book based on its Id
      /// </summary>
      /// <param name="id">The Id of the book that will be returned</param>
      /// <returns>The book who's Id was passed in</returns>
      Task<Book> Get(int id);

      /// <summary>
      /// Add a new book to the database. 
      /// </summary>
      /// <param name="book">The data that will be used to create the book</param>
      /// <returns>The newly created book</returns>
      Task<Book> Create(Book book);

      /// <summary>
      /// Update a books details based on Id
      /// </summary>
      /// <param name="bookId">Id of the book to be updated</param>
      /// <param name="updateData">A book structure with the new data that will be used to update a book</param>
      /// <returns>The book with its updated data</returns>
      Task<Book> Update(int bookId, Book updateData);

      /// <summary>
      /// Remove a book from the database based on Id
      /// </summary>
      /// <param name="id"></param>
      /// <returns></returns>
      Task Delete(int id);
   }
}
