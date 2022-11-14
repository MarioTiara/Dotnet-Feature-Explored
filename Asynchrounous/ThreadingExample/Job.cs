using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ThreadingExample
{
    public class Job
    {
        public  const int REPETITIONS=1000;
        public static void PrintB(){
            for (int i=0; i<REPETITIONS; i++){
                Console.Write("B");
            }
        }

         public static void PrintA(){
            for (int i=0; i<REPETITIONS; i++){
                Console.Write("A");
            }
        }

    }
}