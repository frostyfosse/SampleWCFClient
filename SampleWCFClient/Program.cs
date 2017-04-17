using SampleWCFClient.DataSourceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWCFClient
{
    class Program
    {
        static string[] FirstNames = new[] { "Bill", "Sally", "Will", "Jack", "Sarah", "Brian", "Becky" };
        static string[] LastNames = new[] { "Jones", "Smith", "Wilkins", "Snapple", "Franklin" };
        static string[] Suffixes = new[] { "Jr", "Sr", "PhD", "II", "III", "" };

        static void Main(string[] args)
        {
            var client = new DataSourceServiceClient();
            var persons = new List<Person>();
            var randomizer = new Random();

            Console.WriteLine("Generating Person Data");
            for (int i = 1; i <= 5; i++)
            {
                persons.Add(new Person()
                {
                    Id = $"{nameof(Person)}.{nameof(Person.Id)}.{i}",
                    DateOfBirth = DateTime.Today.AddMonths(-(randomizer.Next(500))),
                    FirstName = FirstNames[randomizer.Next(FirstNames.Length)],
                    LastName = LastNames[randomizer.Next(LastNames.Length)],
                    MiddleName = FirstNames[randomizer.Next(FirstNames.Length)],
                    Suffix = Suffixes[randomizer.Next(Suffixes.Length)]
                });
            }

            //Saving Persons
            Console.WriteLine("Saving Person Data");
            foreach (var person in persons)
                client.SavePerson(person);

            //Deleting Persons
            Console.WriteLine("Deleting Person Data");
            foreach (var personId in persons.Select(x => x.Id))
                client.DeletePerson(personId);
        }
    }
}
