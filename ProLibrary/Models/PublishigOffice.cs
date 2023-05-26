using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProLibrary.Models
{
    public class PublishigOffice
    {
        [Key]
        public int OfficeId { get; set; }
        [Required]
        public string OfficeName { get; set; } = string.Empty;
        public virtual ICollection<Book> Books { get; set; }
    }
}
