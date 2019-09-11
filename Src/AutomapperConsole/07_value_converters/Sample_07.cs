using static System.Console;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace AutomapperConsole
{
    class Sample_07
    {
        static void Main()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Source, Destination>()
                   .ForMember(dest => dest.Percentage,
                              opt => opt.ConvertUsing(new PercentageFormatter(), src => src.Percentage));
            });

            var source = new Source { Percentage = 1 };
            var destination = Mapper.Map<Destination>(source);

            WriteLine(destination.Percentage == "100.0%");

            ReadLine();
        }
    }

    public class PercentageFormatter : IValueConverter<decimal, string>
    {
        public string Convert(decimal sourceMember, ResolutionContext context) => sourceMember.ToString("p1");        
    }

    public class Source { public decimal Percentage { get; set; } }
    public class Destination { public string Percentage { get; set; } }


}
