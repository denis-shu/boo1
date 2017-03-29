using System.ComponentModel.DataAnnotations;

namespace boo.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int NofP { get; set; }

        public int AuthorId { get; set; }

        public int GenreId { get; set; }   
        
        public Genre Genre { get; set; }

        

    }
}