using AutoMapper;
using static System.Console;

namespace AutomapperConsole
{
    class Sample_08
    {
        static void Main()
        {
            //Without CallMeJackJones

            //Mapper.Initialize(cfg => cfg.CreateMap<Person, PersonDto>()
            //                            .BeforeMap((src, dest) => src.Age = src.Age + 10 )
            //                            .AfterMap((src, dest) => dest.Name =  $"Jack {dest.Name}"));




            // With CallMeJackJones

            Mapper.Initialize(cfg => cfg.CreateMap<Person, PersonDto>()
                                        .BeforeMap((src, dest) => src.Age = src.Age + 10)
                                        .AfterMap<CallMeJackJones>());

            var destination = Mapper.Map<PersonDto>(new Person { Name = "Jones" });

            WriteLine(destination.Name == "Jack Jones");
            WriteLine(destination.Age == 10);

            ReadLine();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class PersonDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class CallMeJackJones : IMappingAction<Person, PersonDto>
    {
        public void Process(Person source, PersonDto destination)
        {
            destination.Name = $"Jack {destination.Name}";
        }
    }
}
