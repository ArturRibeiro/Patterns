using System;
using System.Collections.Generic;

namespace Design.Pattern.Applying.Functionals.Unit.Tests
{
    public enum Occupation : short
    {
        Trainee = 0,
        Junior = 1,
        Analyst = 2,
        Senior = 3,
        Architect = 4
    }
    
    public class Person
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public Occupation Occupation { get; private set; } = Occupation.Trainee;
        public int Age { get; private set; } = 0;
        public bool IsValid { get; private set; }
        
        public IList<string> Error { get; set; }

        public Person ChangingName(string name)
        {
            this.Name = name;
            return this;
        }

        public Option<Person> ChangingMiddleName(string middleName)
        {
            this.MiddleName = middleName;
            return this;
        }

        public Person ChangingLastName(string lastName)
        {
            this.LastName = lastName;
            return this;
        }

        public void ChangingOccupation(Occupation occupation) => this.Occupation = occupation;
        
        
        public int ChangingAge(int age)
        {
            this.Age = age;
            return this.Age;
        }

        public void Validation()
        {
            this.IsValid = true;
        }

        
    }
}