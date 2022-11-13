using System.Net.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using static Async.AsyncBreakfast;

namespace Async
{
    class Program
    {
        static void  Main(string[] args)
        {
            // string URL= "https://raw.githubusercontent.com/l3oxer/Doggo/main/README.md";
            // var taks= new List<Task> {SummonDog.SummonDogLocally(), SummonDog.SummonDogFromURL(URL)};
            // await Task.WhenAll(taks);

            Coffee cup = AsyncBreakfast.PourCoffe();
            Console.WriteLine("coffee is ready");

            Egg eggs =AsyncBreakfast.FryEggs(2);
            Console.WriteLine("eggs are ready");

            Bacon bacon =AsyncBreakfast.FryBacon(3);
            Console.WriteLine("bacon is ready");

            Toast toast = ToastBread(2);
            AsyncBreakfast.ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }
       
    }


}
