using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookAPI.Data.Models
{
   public class Book
   {
      [Key]
      public int Id { get; set; }
      public string Name { get; set; }
      public string Author { get; set; }
      public DateTime RegistrationTimeStamp { get; set; }

      [ForeignKey("Category")]
      public int CategoryId { get; set; }
      public virtual BookCategory Category { get; set; }
      public string Description { get; set; }
   }
}
