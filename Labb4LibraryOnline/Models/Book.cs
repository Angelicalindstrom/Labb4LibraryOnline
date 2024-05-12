using System.ComponentModel.DataAnnotations;

namespace Labb4LibraryOnline.Models
{
    public enum BookGenre
    {
        //0,1,2,3,4,5,6,7
        Adventure, Fantasy, History, Horror, Mystery, Thriller, Romance, SciFi
    }
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string BookTitle { get; set; }
        [Required]
        public string BookAuthor { get; set; }

        [Required]
        public BookGenre BookGenre { get; set; }

        [Required]
        public int NumberOfCopies { get; set; }

        public virtual ICollection <BookLoan>? BookLoans { get; set; }
    }
}
