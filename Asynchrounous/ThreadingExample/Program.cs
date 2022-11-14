using System;
using System.Threading;
namespace ThreadingExample
{
    class Program
    {
        static void Main(string[] args)
        {
             Thread t1 = new Thread (()=>Job.PrintB());
			 t1.Start ();
             for (int i=0; i<1000; i++){
                Console.Write("A");
             }

        }
    }
}
