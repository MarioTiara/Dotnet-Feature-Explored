using System;

namespace CSharpFeatures
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var phoneNumbers = new string[2];
            Records.Person person1 = new("Nancy", "Davolio", phoneNumbers);
            Records.Person person2 = new("Nancy", "Davolio", phoneNumbers);
            Console.WriteLine(person1==person2);

            person1.PhoneNumbers[0] = "555-212";
            Console.WriteLine(person1 == person2);

            Console.WriteLine(ReferenceEquals(person1, person2));

        }
    }
}
