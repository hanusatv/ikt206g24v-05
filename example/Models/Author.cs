using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Example.Models
{
    public class Author
    {
        public Author()
        {
            // Generate a new unique identifier for this Author instance.
            Id = Guid.NewGuid();
        }

        public Author(string firstName, string lastName, DateTime birthdate)
            : this() // Call the default constructor to initialize the Id
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate.ToUniversalTime();
        }

        [Required]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("First name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [DisplayName("Last name")]
        public string LastName { get; set; } = string.Empty;

        private DateTime _birthdate;
        [DataType(DataType.Date)]
        [DisplayName("Birthdate")]
        public DateTime Birthdate
        {
            get => _birthdate;
            set => _birthdate = value.ToUniversalTime(); // Convert to UTC
        }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
