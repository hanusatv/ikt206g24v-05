using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Example.Models
{
    public class Author
    {
        public Author() {}
        
        public Author(string firstName, string lastName, DateTime birthdate)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("First name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [DisplayName("Last name")]
        public string LastName { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [DisplayName("Birthdate")]
        public DateTime Birthdate { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
