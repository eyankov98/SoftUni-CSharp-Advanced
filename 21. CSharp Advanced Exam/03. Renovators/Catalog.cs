using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public Catalog(string name, int neededRenovators, string project)
        {
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
            Renovators = new List<Renovator>();
        }

        public List<Renovator> Renovators { get; set; }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }

        public int Count => Renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return $"Invalid renovator's information.";
            }
            else if (Renovators.Count == NeededRenovators)
            {
                return $"Renovators are no more needed.";
            }
            else if (renovator.Rate > 350)
            {
                return $"Invalid renovator's rate.";
            }
            else // if (Renovators.Count > NeededRenovators)
            {
                Renovators.Add(renovator);

                return $"Successfully added {renovator.Name} to the catalog.";
            }
        }

        public bool RemoveRenovator(string name)
            => Renovators.Remove(Renovators.FirstOrDefault(r => r.Name == name));

        public int RemoveRenovatorBySpecialty(string type)
        {
            int countRemoveRenovators = 0;

            while (Renovators.FirstOrDefault(r => r.Type == type) != null)
            {
                var targetRenovator = Renovators.FirstOrDefault(r => r.Type == type);

                Renovators.Remove(targetRenovator);

                countRemoveRenovators++;
            }

            return countRemoveRenovators;
        }

        public Renovator HireRenovator(string name)
        {
            var targetRenovator = Renovators.FirstOrDefault(r => r.Name == name);

            if (targetRenovator == null)
            {
                return null;
            }

            targetRenovator.Hired = true;

            return targetRenovator;
        }

        public List<Renovator> PayRenovators(int days)
        {
            List<Renovator> payRenovators = new List<Renovator>();

            foreach (var renovator in Renovators.Where(r => r.Days >= days))
            {
                payRenovators.Add(renovator);
            }

            return payRenovators;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {Project}:");

            foreach (var item in Renovators.Where(r => r.Hired == false))
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}