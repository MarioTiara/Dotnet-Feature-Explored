using System;
using System.IO;
using System.Threading.Tasks;
namespace Async
{
    class Program
    {
        static void Main(string[] args)
        {
            SummonDogLocally();
        }

        static async Task SummonDogLocally(){
            Console.WriteLine("1. Summoning Dog Locally ...");
            
            //read all the text inside the dog.text async
            string dogtext=await File.ReadAllTextAsync("dog.txt");
            
            //display the data inside the txt file
            Console.WriteLine($"2. Dog Summoned Locally \n{dogtext}");

        }
       
    }


}
