using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFDataAccessLibrary.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public int LastName { get; set; }
        [Required]
        public int Age { get; set; }
        public List<Address> Addresses { get; set; }= new List<Address>();
        public List<Email> Emails { get; set; }= new List<Email>(); 
    }
}
