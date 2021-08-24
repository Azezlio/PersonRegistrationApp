using System;
using System.ComponentModel.DataAnnotations;

namespace PersonRegistrationShared
{
    public class Person
    {
        public int PersonId { get; set; }
     
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        public string City { get; set; }
        
    }
}
