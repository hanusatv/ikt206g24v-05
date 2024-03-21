using System.ComponentModel.DataAnnotations;

namespace Example.Models
{
    public class Review
    {
        Review() {}
        
        public int Id { get; set; }

        [Range(1, 5)]
        public int Stars { get; set; }

        [StringLength(1000)]
        public string Text { get; set; } = string.Empty;
        
        public int AuthorId { get; set; }
        
        public Author? Author { get; set; }
    }
}
