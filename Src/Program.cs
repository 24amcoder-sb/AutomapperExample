using AutoMapper;
using static System.Console;

namespace AutomapperConsole
{
    class Program
    {
        static void Main()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Source, Destination>());

            var source = new Source() { Value = 101 };
            var destination = Mapper.Map<Destination>(source);
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
