using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace boo.Models
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname  { get; set; }

        [Required]
        public DateTime? BirthDate { get; set; }

       public List<Book> Books { get; set; }

      
        
    }
}