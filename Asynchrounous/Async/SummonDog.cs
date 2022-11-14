using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Async
{
    public class SummonDog
    {
        public static async Task SummonDogLocally(){
            Console.WriteLine("1. Summoning Dog Locally ...");
            
            //read all the text inside the dog.text async
            string dogtext=await File.ReadAllTextAsync("dog.txt");
            
            //display the data inside the txt file
            Console.WriteLine($"2. Dog Summoned Locally \n{dogtext}");

        }

        public static async Task SummonDogFromURL (string URL){
            Console.WriteLine("1. Summoning Dog from URL ...");
            using (var httpclient= new HttpClient()){
                string result = await httpclient.GetStringAsync(URL);
                  Console.WriteLine($"2. Dog Summoned url \n{result}");
            }
        }
    }
}