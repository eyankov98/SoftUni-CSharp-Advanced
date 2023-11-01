using Microsoft.Win32;
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
            if (Registry.Count < Capacity)
            {
                Registry.Add(child);

                return true;
            }

            return false;
        }

        public bool RemoveChild(string childFullName) =>
            Registry.Remove(Registry.FirstOrDefault(ch => ch.FirstName == childFullName.Split(" ")[0] && ch.LastName == childFullName.Split(" ")[1]));

        public int ChildrenCount => Registry.Count;

        public Child GetChild(string childFullName) =>
            Registry.FirstOrDefault(ch => ch.FirstName == childFullName.Split(" ")[0] && ch.LastName == childFullName.Split(" ")[1]);

        public string RegistryReport()
        {
            var sortedChildren = Registry.OrderByDescending(ch => ch.Age).ThenBy(ch => ch.LastName).ThenBy(ch => ch.FirstName).ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Registered children in {Name}:");

            foreach (var child in sortedChildren)
            {
                sb.AppendLine(child.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}