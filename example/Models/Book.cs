using System.ComponentModel.DataAnnotations;

namespace Example.Models
{
    public class Book
    {
        public Book() {}

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [StringLength(1000)]
        public string Summary { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime Published { get; set; }
    }
}
