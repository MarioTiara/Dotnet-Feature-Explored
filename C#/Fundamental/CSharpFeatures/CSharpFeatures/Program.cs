using System;

namespace CSharpFeatures
{
    class Program
    {
        
        static void Main(string[] args)
        {
             Records.Person person = new("Nancy", "Davolio");
             Console.WriteLine(person);
        }
    }
}
