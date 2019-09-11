using AutoMapper;
using System;
using static System.Console;

namespace AutomapperConsole
{
    class Sample_03
    {
        static void Main()
        {
            WriteLine("Welcome to Automapper Samples");

            var source = new Source { Date = new DateTime(2019, 3, 3, 3, 3, 3) };

            Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());

            var dest = Mapper.Map<Destination>(source);

            WriteLine(dest.Hour == source.Date.Hour);
            WriteLine(dest.Minute == source.Date.Minute);
            WriteLine(dest.Hour == source.Date.Hour);

            ReadLine();
        }
    }

    public class Source
    {
        public DateTime Date { get; set; }
    }

    public class Destination
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Source, Destination>()
                .ForMember(dest => dest.Hour, opt => opt.MapFrom(src => src.Date.Hour))
                .ForMember(dest => dest.Minute, opt => opt.MapFrom(src => src.Date.Minute))
                .ForMember(dest => dest.Second, opt => opt.MapFrom(src => src.Date.Second));
        }

    }

}
