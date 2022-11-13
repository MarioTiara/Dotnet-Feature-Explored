using System.Net.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Async
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string URL= "https://raw.githubusercontent.com/l3oxer/Doggo/main/README.md";
            var taks= new List<Task> {SummonDogLocally(), SummonDogFromURL(URL)};
            await Task.WhenAll(taks);
        }

        static async Task SummonDogLocally(){
            Console.WriteLine("1. Summoning Dog Locally ...");
            
            //read all the text inside the dog.text async
            string dogtext=await File.ReadAllTextAsync("dog.txt");
            
            //display the data inside the txt file
            Console.WriteLine($"2. Dog Summoned Locally \n{dogtext}");

        }

        static async Task SummonDogFromURL (string URL){
            Console.WriteLine("1. Summoning Dog from URL ...");
            using (var httpclient= new HttpClient()){
                string result = await httpclient.GetStringAsync(URL);
                  Console.WriteLine($"2. Dog Summoned url \n{result}");
            }
        }
       
    }


}
