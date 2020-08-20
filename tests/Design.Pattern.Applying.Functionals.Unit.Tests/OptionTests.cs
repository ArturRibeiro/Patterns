using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Design.Pattern.Applying.Functionals.Extensions;
using FluentAssertions;
using Xunit;

namespace Design.Pattern.Applying.Functionals.Unit.Tests
{
    public class OptionTests
    {
        [Theory]
        [InlineData("Artur", "Santos", "Ribeiro", Occupation.Trainee, 19)]
        [InlineData("Fernnando", "souza", "Correia", Occupation.Junior, 22)]
        [InlineData("Marcos", "Silva", "Mello", Occupation.Analyst, 25)]
        [InlineData("Nicolas", "Nascimento", "Cardoso", Occupation.Senior, 30)]
        [InlineData("Sabrina", "Fernandes", "Souza", Occupation.Architect, 39)]
        public async Task Option_try(string name, string middleName, string lastName, Occupation occupation, int age)
        {
            //Arrange's
            var repo = new PersonRepository();

            //Act
            var option = repo.GetPerson(Guid.NewGuid())
                .OnTry(x => x.ChangingName(name))
                .OnTry(x => x.ChangingMiddleName(middleName))
                .OnTry(x => x.ChangingLastName(lastName))
                .OnTry(x => x.ChangingOccupation(occupation))
                .OnTry(x => x.ChangingAge(age))
                .OnTry(x => x.ChangingAge(age))
                .OnValidation(x=> x.Validation())
                //.Catch(x => x.Error)
                .Finally();


            //Assert's
            option.IsNone.Should().BeFalse();
            option.IsSome.Should().BeTrue();
            option.Message.Should().BeNull();

            option.Value.Should().NotBeNull();
            option.Value.Name.Should().Be(name);
            option.Value.MiddleName.Should().Be(middleName);
            option.Value.LastName.Should().Be(lastName);
            option.Value.Occupation.Should().Be(occupation);
            option.Value.Age.Should().Be(age);
        }
    }
}