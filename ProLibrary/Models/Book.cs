using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProLibrary.Models
{
    public class Book
    {
        [Key]
        public int InventoryCode { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public int Year { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author AuthorObj { get; set; }
        [ForeignKey("OfficeId")]
        public virtual PublishigOffice OfficeObj { get; set; }
        public virtual ICollection<LoanOfBook> Loans { get; set; }
    }
}