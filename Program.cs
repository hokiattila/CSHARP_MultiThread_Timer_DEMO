using System;
using System.Threading;

namespace MultiThreadExamDemo
{
    internal class Program
    {
        static void Timer(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Thread.Sleep(1000);
            }
        }

        static void Main(string[] args)
        {
            Thread timerThread = new Thread(() => Timer(5));
            timerThread.Start();

            Console.WriteLine("Mennyi 2x2?");
            Console.WriteLine("\nA.) 4\nB.) 5\nC.) 6\nD.) 7\n");

            while (timerThread.IsAlive && !Console.KeyAvailable)
            {
                Thread.Sleep(100);
            }

            if (!timerThread.IsAlive)
            {
                Console.WriteLine("Idő lejárt!");
                Environment.Exit(0);
            }
            else
            {
                string? input = Console.ReadLine();
                string result = input?.Equals("A", StringComparison.CurrentCultureIgnoreCase) == true ? "Helyes" : "Helytelen";
                Console.WriteLine(result);
                Environment.Exit(0);
            }
            timerThread.Join();
        }
    }
}
