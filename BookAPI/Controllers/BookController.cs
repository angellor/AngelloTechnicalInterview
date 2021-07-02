using BookAPI.Data.Models;
using BookAPI.Data.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
   [Route("api/book")]
   [ApiController]
   public class BookController : ControllerBase
   {
      private readonly IBookRepo _bookRepo;

      public BookController(IBookRepo bookRepo)
      {
         _bookRepo = bookRepo;
      }


      [HttpGet]
      public async Task<IEnumerable<Book>> GetBook()
      {
         return await _bookRepo.Get();
      }


      [HttpGet("{id}")]
      public async Task<Book> GetBooks(int id)
      {
         return await _bookRepo.Get(id);
      }


      [Route("create")]
      [HttpPost]
      public async Task<int> Create([FromBody] Book bookToCreate)
      {
         var newBook = await _bookRepo.Create(bookToCreate);

         return newBook.Id;
      }


      [Route("{bookId}/update")]
      [HttpPut]
      public async Task<ActionResult<Book>> Update(int bookId, [FromBody] Book bookData)
      {
         try
         {
            //Ensure the Id passed in matches the update data sent in
            if (bookData.Id != bookId)
            {
               return BadRequest();
            }

            // Ensure the book exists
            var bookUpdate = await _bookRepo.Get(bookId);
            if (bookUpdate == null)
            {
               return NotFound();
            }

            return await _bookRepo.Update(bookId, bookData);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, $" Status {StatusCodes.Status500InternalServerError} - Error {ex.Message}");
         }
      }

      [HttpDelete("{id}")]
      public async Task<ActionResult> Delete(int id)
      {
         
         // Ensure the book exists
         var bookUpdate = await _bookRepo.Get(id);
         if (bookUpdate == null)
         {
            return NotFound();
         }

         try
         {
            await _bookRepo.Delete(id);
         }
         catch (Exception ex)
         {
            return StatusCode(StatusCodes.Status500InternalServerError, $" Status {StatusCodes.Status500InternalServerError} - Error {ex.Message}");
         }

         return NoContent();
      }
   }
}
