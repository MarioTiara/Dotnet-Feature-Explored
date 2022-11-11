using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccessLibrary.Models
{
    public class Person
    {
        int Id { get; set; }    
        public string FirstName { get; set; }
        public int LastName { get; set; }
        public int Age { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
