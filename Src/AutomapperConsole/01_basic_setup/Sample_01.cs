using AutoMapper;
using static System.Console;

namespace AutomapperConsole
{
    class Sample_01
    {
        static void Main()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Source, Destination>());

            var source = new Source() { Value = 101 };
            var destination = Mapper.Map<Destination>(source); //verify the value of 'Value' (set debugger)

            ReadLine();
        }
    }

    public class Source
    {
        public int Value { get; set; }
    }

    public class Destination
    {
        public int Value { get; set; }
    }
}
