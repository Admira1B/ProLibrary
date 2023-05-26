using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProLibrary.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public virtual ICollection<Book> Books { get; set; }
    }
}
