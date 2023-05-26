using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProLibrary.Models
{
    public class LoanOfBook
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CreationDate { get; set; } = string.Empty;
        public string ReturningDate { get; set; } = string.Empty;
        public virtual Reader ReaderObj { get; set; }
        public int ReaderId { get; set; }
        public virtual Book BookObj { get; set; }
        public int BookId { get; set; }
    }
}
