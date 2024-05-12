using System.ComponentModel.DataAnnotations;

namespace Labb4LibraryOnline.Models
{
    public enum FavGenre
    {
        //0,1,2,3,4,5,6,7
        Adventure, Fantasy, History, Horror, Mystery, Thriller, Romance, SciFi
    }
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "CustomerName can't be longer than 50 characters.")]
        public string CustomerName { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "CustomerAdress can´t be shorter than 5 characters")]
        [MaxLength(40, ErrorMessage = "CustomerAdress Max 100 characters")]
        public string CustomerAdress { get; set; }

        [Required]
        [MaxLength(45, ErrorMessage = "CustomerAdress Max 100 characters")]
        public string CustomerMail { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "PhonNumber must be at least 10 digits")]
        [MaxLength(12, ErrorMessage = "PhonNumber must be at least 10 digits")]
        public string CustomerPhoneNumber { get; set; }

        public FavGenre? FavGenre { get; set; }

        public virtual ICollection<BookLoan>? BookLoans { get; set; }

    }
}
