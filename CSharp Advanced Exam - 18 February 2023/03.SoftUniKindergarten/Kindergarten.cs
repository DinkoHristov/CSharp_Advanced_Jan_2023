using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniKindergarten
{
    public class Kindergarten
    {
        public Kindergarten(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Registry = new List<Child>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public List<Child> Registry { get; set; }

        public bool AddChild(Child child)
        {
            if (this.Registry.Count < this.Capacity)
            {
                this.Registry.Add(child);

                return true;
            }

            return false;
        }

        public bool RemoveChild(string childFullName)
        {
            string[] splittedName = childFullName.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstName = splittedName[0];
            string lastName = splittedName[1];

            Child child = this.Registry
                .FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

            if (child != null)
            {
                this.Registry.Remove(child);

                return true;
            }    

            return false;
        }

        public int ChildrenCount { get { return this.Registry.Count;} }

        public Child GetChild(string childFullName)
        {
            string[] splittedName = childFullName.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string firstName = splittedName[0];
            string lastName = splittedName[1];

            Child child = this.Registry
                .FirstOrDefault(c => c.FirstName == firstName && c.LastName == lastName);

            if (child != null)
            {
                return child;
            }

            return null;
        }

        public string RegistryReport()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Registered children in {Name}:");

            foreach (Child child in this.Registry
                .OrderByDescending(c => c.Age)
                .ThenBy(c => c.LastName)
                .ThenBy(c => c.FirstName))
            {
                result.AppendLine(child.ToString());
            }

            return result.ToString().Trim();
        }
    }
}
