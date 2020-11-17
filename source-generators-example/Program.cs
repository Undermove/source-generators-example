using System;

namespace source_generators_example
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorldGenerated.HelloWorld.SayHello(); // calls Console.WriteLine("Hello World!") and then prints out syntax trees
        }
    }
}
