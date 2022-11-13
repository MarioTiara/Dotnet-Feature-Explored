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
        static async Task  Main(string[] args)
        {
            // await SummonDogRun();
            await DoNotBlockThread();
            Console.WriteLine("======================================");
            await Taskconcurrently();
           
        }

        static async Task DoNotBlockThread(){
             Coffee cup = AsyncBreakfast.PourCoffe();
            Console.WriteLine("coffee is ready");

            
            Egg eggs = await AsyncBreakfast.FryEggsAsync(2);
            Console.WriteLine("eggs are ready");

            Bacon bacon =await AsyncBreakfast.FryBaconAsync(3);
            Console.WriteLine("bacon is ready");

            Toast toast = await AsyncBreakfast.ToastBreadAsync(2);
            AsyncBreakfast.ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        static async Task Taskconcurrently(){
            Coffee cup = AsyncBreakfast.PourCoffe();
            Console.WriteLine("Coffee is ready");

            Task<Egg> eggTask= AsyncBreakfast.FryEggsAsync(2);
            Egg eggs= await eggTask;
            Console.WriteLine("Eggs are ready");

            Task<Bacon> baconTask= AsyncBreakfast.FryBaconAsync(3);
            Bacon bacon = await baconTask;
            Console.WriteLine("Bacon is ready");

            Task<Toast> toastTask= AsyncBreakfast.ToastBreadAsync(2);
            Toast toast=await toastTask;
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("Toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("Oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        static async Task SummonDogRun(){
            string URL= "https://raw.githubusercontent.com/l3oxer/Doggo/main/README.md";
            var taks= new List<Task> {SummonDog.SummonDogLocally(), SummonDog.SummonDogFromURL(URL)};
            await Task.WhenAll(taks);
        }
       
    }


}
