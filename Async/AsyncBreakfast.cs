using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async
{
    public class AsyncBreakfast
    {
        public class Bacon { }
        public class Coffee { }
        public class Egg { }
        public class Juice { }
        public class Toast { }

        public static Juice PourOJ(){
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        public static void ApplyJam(Toast toast)=> 
                    Console.WriteLine("Putting jam on the toast");

        public static Toast ToastBread(int slices){
            for (int slice=0; slice<slices;slice++){
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting ..");
            Task.Delay(3000).Wait();
            Console.WriteLine("remove toas from toaster");
            return new Toast();
        }

        public static Bacon FryBacon (int slices){
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        public static Egg FryEgg (int howMany){
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        public static Coffee PourCoffe(){
            Console.WriteLine("Pouring coffe");
            return new Coffee();
        }

        

       
    }
}