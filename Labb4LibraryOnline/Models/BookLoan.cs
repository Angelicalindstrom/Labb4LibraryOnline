using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Labb4LibraryOnline.Models
{
    public enum LoanStatus
    {
        //0,1
        Returned, NotReturned
    }
    public class BookLoan
    {
        [Key]
        public int BookLoanId { get; set; }


        [ForeignKey("Customer")]
        public int FkCustomerId { get; set; }
        public Customer? Customer { get; set; }



        [ForeignKey("Book")]
        public int FkBookId { get; set; }
        public Book? Book { get; set; }



        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BookLoanDate { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BookReturnDate { get; set; }

        public LoanStatus Status { get; set; }
    }
}
