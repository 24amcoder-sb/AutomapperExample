using AutoMapper;
using static System.Console;

namespace AutomapperConsole
{
    class Sample_02
    {
        static void Main()
        {
            //static mapper
            Mapper.Initialize(cfg => cfg.CreateMap<Source, Destination>());
            var destination = Mapper.Map<Destination>(new Source());



            //instance mapper
            var config = new MapperConfiguration(
                cfg => cfg.CreateMap<Source, Destination>()
            );
            var mapper = new Mapper(config);
            //Or
            var mapper1 = config.CreateMapper();




            ReadLine();
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
}