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
            //await DoNotBlockThread();
          
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

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var BreakfastTasks= new List<Task> {eggsTask, baconTask, toastTask};
            while(BreakfastTasks.Count>0){
                Task finishedTask= await Task.WhenAny(BreakfastTasks);
                if (finishedTask==eggsTask){
                    Console.WriteLine("eggs are ready");
                }else if(finishedTask==baconTask){
                    Console.WriteLine("bacon is ready");
                }else if (finishedTask==toastTask){
                    Console.WriteLine("toast is ready");
                }
                BreakfastTasks.Remove(finishedTask);
            }
            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        static async Task SummonDogRun(){
            string URL= "https://raw.githubusercontent.com/l3oxer/Doggo/main/README.md";
            var taks= new List<Task> {SummonDog.SummonDogLocally(), SummonDog.SummonDogFromURL(URL)};
            await Task.WhenAll(taks);
        }
       
    }


}
