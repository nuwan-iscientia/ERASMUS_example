using System;
using System.Threading.Tasks;

namespace example
{
    class Program
    {
        static void Main(string[] args)
        {
            //var example = new Example1();
            var example = new Example2();
            example.Run().Wait();
            //Task.Run(async () => await example.Run());
            Console.ReadLine();
        }
    }
}
