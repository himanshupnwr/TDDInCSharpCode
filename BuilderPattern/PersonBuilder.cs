using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public sealed class PersonBuilder
    {
        private int Age { get; }
        private string Name { get; } = null!;
        private IReadOnlyCollection<string> Phones { get; } = null!;

        public PersonBuilder()
        {
        }

        public PersonBuilder(int age, string name, IReadOnlyCollection<string> phones)
        {
            Age = age;
            Name = name;
            Phones = phones;
        }

        public PersonBuilder WithName(string name)
        {
            return new PersonBuilder(Age, name, Phones);
        }

        public PersonBuilder WithAge(int age)
        {
            return new PersonBuilder(age, Name, Phones);
        }

        public PersonBuilder WithPhones(IReadOnlyCollection<string> phones)
        {
            return new PersonBuilder(Age, Name, phones);
        }
    }

    public class PersonClient
    {
        public static void Run()
        {
            var jon = new PersonBuilder(name: null!, age: 30,
                phones: new ReadOnlyCollection<string>(new List<string>() { "12345", { "678910" } }));

            var jonBuilder = new PersonBuilder();
            var realJon = jonBuilder.WithName("Jon Skeet")
                                   .WithAge(30)
                                   .WithPhones(new List<string>() { "12345", { "678910" } });
        }
    }
}
