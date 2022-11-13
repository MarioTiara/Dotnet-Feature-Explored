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
            var taks= new List<Task> {SummonDog.SummonDogLocally(), SummonDog.SummonDogFromURL(URL)};
            await Task.WhenAll(taks);
        }
       
    }


}
