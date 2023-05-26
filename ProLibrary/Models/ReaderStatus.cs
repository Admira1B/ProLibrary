using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProLibrary.Models
{
    public class ReaderStatus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string StatusName { get; set; }
        public virtual ICollection<Reader> Readers { get; set; }
    }
}
