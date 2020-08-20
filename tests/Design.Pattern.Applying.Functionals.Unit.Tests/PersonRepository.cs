using System;
using System.Threading.Tasks;
using Bogus;

namespace Design.Pattern.Applying.Functionals.Unit.Tests
{
    public class PersonRepository
    {
        public Option<Person> Save(Person person)
        {
            return person;
        }

        public Option<Person> GetPerson(Guid personId)
        {
            return new Faker<Person>()
                .RuleFor(x => x.Id, faker => personId)
                .Generate();
        }
    }
}