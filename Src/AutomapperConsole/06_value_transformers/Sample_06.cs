using AutoMapper;
using static System.Console;

namespace AutomapperConsole
{
    class Sample_06
    {
        static void Main()
        {
            Mapper.Initialize(cfg => {
                    cfg.CreateMap<Source, Destination>();
                    cfg.ValueTransformers.Add<string>(val => val + "!!");
                });

            var destination = Mapper.Map<Destination>(new Source { Greeting = "Hello" });

            //testing
            WriteLine(destination.Greeting == "Hello!!");

            ReadLine();
        }
    }

    public class Source
    {
        public string Greeting { get; set; }
    }
    public class Destination
    {
        public string Greeting { get; set; }
    }
}
