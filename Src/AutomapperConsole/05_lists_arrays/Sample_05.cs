using AutoMapper;
using System.Collections.Generic;
using static System.Console;

namespace AutomapperConsole
{
    class Sample_05
    {
        static void Main()
        {
            Mapper.Initialize(cfg => 
                             {
                                 cfg.CreateMap<ParentSource, ParentDestination>()
                                    .Include<Source, Destination>();

                                 cfg.CreateMap<Source, Destination>();
                             });

            var sources = new[] { new Source { Value = 201 , Value1 = 102} };

            var arrayDestination = Mapper.Map<Source[], Destination[]>(sources);
            var listDestination = Mapper.Map<Source[], List<Destination>>(sources);

            ReadLine();
        }   
    }

    public class Source : ParentSource
    {
        public int Value { get; set; }
    }

    public class Destination : ParentDestination
    {
        public int Value { get; set; }
    }

    public class ParentSource
    {
        public int Value1 { get; set; }
    }

    public class ParentDestination
    {
        public int Value1 { get; set; }
    }

}
