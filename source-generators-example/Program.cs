using System;
using System.Net.Http;
using System.Text;
namespace source_generators_example
{
    class Program
    {
        static void Main(string[] args)
        {
            HelloWorldGenerated.HelloWorld.SayHello();
            
            #region api_example
            // var generated = new FromApiGenerator.GeneratedFromApi()
            // {
            //     Name = "Jon Snow"
            // };
            // Console.WriteLine("You know nothing " + generated.Name);
            #endregion api_example
        }
    }
}
