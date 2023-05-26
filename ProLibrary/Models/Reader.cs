using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProLibrary.Models
{
    public class Reader
    {
        [Key]
        public int LibraryCardNumber { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        public string TelephoneNumber { get; set; } = "Не указан";
        public virtual ICollection<LoanOfBook> Loans { get; set; }
        public virtual ReaderStatus StatusObj { get; set; }
        public int ReaderStatusId { get; set; }
    }
}