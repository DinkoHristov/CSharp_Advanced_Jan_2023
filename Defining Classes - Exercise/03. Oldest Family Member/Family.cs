using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        public List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }
        public List<Person> People { get { return this.people; } set { this.people = value; } }

        public void AddMember(Person member)
        {
            this.people.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldestPerson = this.people
                .OrderByDescending(person => person.Age)
                .FirstOrDefault();

            return oldestPerson;
        }
    }
}
